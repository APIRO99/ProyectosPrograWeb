import { Box, Button, FormControl, FormErrorMessage, FormLabel, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay, Image } from "@chakra-ui/react";
import { Field, Form, Formik } from "formik";
import { useEffect, useRef } from "react";
import { useTypedDispatch } from "store/hooks";
import { thunkCreateProperty, thunkUpdateProperty } from "store/thunk/Properties";
import ImageSelector from "./ImageSelector";
import ModelSelector from "./ModelSelector";

interface FormInterface {
  isOpen: boolean;
  editProperty?: boolean;
  propertyData?: IProperty;
  title: string;
  onClose: () => void;
  handleDelete?: (id: number) => void;
}

interface IDataFormProps extends IProperty {
  onClose: () => void;
  handleDelete?: (id: number) => void;
  editProperty?: boolean;
}

interface IFormData extends IProperty {
  image: File;
}

async function createFileFromUrl(url: string, filename: string): Promise<File> {
  const response = await fetch(url);
  const blob = await response.blob();
  return new File([blob], filename);
}


const MyField = ({ label, ...props }: any) => {
  return (
    <Field name={props.name} validate={
      (value: string) => (value) ? "" : "This field is required"
    }>
      {({ field, form }: { field: any, form: any }) => (
        <FormControl isInvalid={form.errors[props.name] && form.touched[props.name]}  {...props} my='5px'>
          <FormLabel htmlFor={props.name}>{label}</FormLabel>
          <Input
            {...field}
            id={props.name}
            placeholder={props.name}
            type={props.type || "text"}
            borderRadius="16px"
            color='white'
          />
          <FormErrorMessage>{form.errors[props.name]}</FormErrorMessage>
        </FormControl>
      )}
    </Field>
  )
}

const DataForm = (props: IDataFormProps) => {

  const dispatch = useTypedDispatch();
  const refImage = useRef(undefined);
  const { id, name, address, baths, beds, city, state, status, weekRent, photo, model } = props;
  const { handleDelete, onClose, editProperty } = props;
  const initialValues: IFormData = {
    name,
    address,
    baths,
    beds,
    city,
    state,
    status,
    weekRent,
    photo,
    model,
    image: null
  };
  const deleteProperty = (id: number): void => {
    handleDelete(id);
    onClose();
  }
  return (
    <Formik
      initialValues={initialValues}
      enableReinitialize={true}
      onSubmit={(values, actions) => {
        let property: IProperty = {
          name: values.name,
          address: values.address,
          baths: values.baths,
          beds: values.beds,
          city: values.city,
          state: values.state,
          status: values.status,
          weekRent: values.weekRent,
          photo: values.photo,
          model: values.model,
          id: (editProperty) ? props.id : Math.random().toString(36).substr(2, 9)
        }
        if (editProperty)
          dispatch(thunkUpdateProperty(property, values.image));
        else
          dispatch(thunkCreateProperty(property, values.image));
        actions.setSubmitting(false)
        onClose();
      }}
    >
      {(props) => (
        <Form>
          <Box display='flex' >
            <Box flex='1' me='10px'>
              <MyField label="Name" name="name" />
              <MyField label="address" name="address" />
              <MyField label="baths" name="baths" type='number' />
              <MyField label="beds" name="beds" type='number' />
            </Box>
            <Box flex='1' ml='10px'>
              <ImageSelector photo={process.env.REACT_APP_STATIC_FILES_URL + photo} name="image" label="image" />
            </Box>
          </Box>

          <Box display='flex' justifyContent='space-between'>
            <MyField label="city" name="city" mx='10px' />
            <MyField label="state" name="state" mx='10px' />
          </Box>
          <Box display='flex' justifyContent='space-between'>
            <MyField label="status" name="status" mx='10px' />
            <MyField label="weekRent" name="weekRent" mx='10px' type='number' />
          </Box>
          <MyField label="model" name="model" />
          <MyField label="model" name="model" />
          {/* <ModelSelector /> */}
          <Button
            mt={4}
            colorScheme="brand"
            isLoading={props.isSubmitting}
            type="submit"
          >
            Submit
          </Button>
          {
            (editProperty) ?
              <Button
                mt={4}
                colorScheme="red"
                isLoading={props.isSubmitting}
                type="button"
                onClick={() => deleteProperty(id)}
                ml='20px'
              >
                Delete
              </Button>
              : null
          }
        </Form>
      )}
    </Formik>
  )
}

const PropertyForm = (props: FormInterface) => {
  const { isOpen, onClose, editProperty, propertyData, title, handleDelete } = props;
  return (
    <>
      <Modal onClose={onClose} isOpen={isOpen} size='6xl'>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>{title}</ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <DataForm
              {...propertyData}
              editProperty={editProperty}
              onClose={onClose}
              handleDelete={handleDelete}
            />
          </ModalBody>
          <ModalFooter>
            <Button onClick={onClose}>Close</Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </>
  )
}

export default PropertyForm;