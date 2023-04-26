import React, { useEffect, useRef, useState } from 'react';
import { Box, Button, FormControl, FormLabel, Image, Input } from '@chakra-ui/react';
import { Field } from 'formik';

interface IProps {
  photo: string;
  name: string;
  label: string;
}

const ModelSelector = (props: IProps) => {
  const [selectedImage, setSelectedImage] = useState<File | null>(null);
  const fileInputRef = useRef(null);

  useEffect(() => {
    if (props.photo) {
      createFileFromUrl(props.photo, 'property-image')
        .then((file) => setSelectedImage(file));
    }
  }, [props.photo]);

  const handleImageSelect = (event: React.ChangeEvent<HTMLInputElement>) => {
    const selectedFile = event.target.files?.[0];
    setSelectedImage(selectedFile || null);
  };
  const handleClick = () => {
    fileInputRef.current.click();
  };

  return (
    <>
      {/* <Field
        id="image"
        name="image"
        type="file"
        onChange={(event: any) => {
          setSelectedImage(event.currentTarget.files[0]);
        }}
      />
      {selectedImage &&
        <Image src={URL.createObjectURL(selectedImage)} alt="Property Image" w='382px' h='215px' mx='auto' borderRadius='15px' />
      }
      <button type="submit">Upload</button> */}
      <Field 
        name='image' 
        type='file' 
        validate={(value: string) => (value) ? "" : "This field is required"}
      >
        {
          ({ field, form }: { field: any, form: any }) => (
            <FormControl 
              isInvalid={false}  {...props} 
              my='5px'
            >
              <FormLabel htmlFor={props.name}>{props.label}</FormLabel>
              { selectedImage && <Image src={URL.createObjectURL(selectedImage)} alt="Property Image" w='382px' h='215px' mx='auto' borderRadius='15px' objectFit='cover'/> }
              <Box mt='15px' display='flex' flexDir='row-reverse'>
                <Button onClick={handleClick} me='40px' >Select File</Button>
                <FormLabel htmlFor="image"></FormLabel>
                <Input
                  // {...field}
                  id={props.name}
                  type="file"
                  ref={fileInputRef}
                  onChange={(ev: any) => {
                    handleImageSelect(ev);
                    form.setFieldValue('image', ev.currentTarget.files[0]);
                  }}
                display="none"
                />
              </Box>
            </FormControl>
          )
        }
      </Field>

      {/* <FormControl id='image'>
        <Field
          name="image"
          type="file"
          onChange={handleImageSelect}
        />
        <button type="submit">Upload</button>
      </FormControl> */}
    </>

  );
}

async function createFileFromUrl(url: string, filename: string): Promise<File> {
  const response = await fetch(url);
  const blob = await response.blob();
  return new File([blob], filename);
}

export default ModelSelector;
