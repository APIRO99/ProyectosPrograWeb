import { Button, FormControl, FormErrorMessage, FormLabel, Input, Modal, ModalBody, ModalCloseButton, ModalContent, ModalFooter, ModalHeader, ModalOverlay } from "@chakra-ui/react";
import { Field, Form, Formik } from "formik";
import { useTypedDispatch } from "store/hooks";
import { thunkCreateUser, thunkUpdateUser } from "store/thunk/Users";

interface FormInterface {
  isOpen: boolean;
  editUser?: boolean;
  userData?: IUser;
  title: string;
  onClose: () => void;
}

interface IDataFormProps extends IUser {
  onClose: () => void;
  editUser?: boolean;
}

const MyField = ({ label, ...props }: any) => {
  return (
    <Field name={props.name} validate={
      (value: string) => (value) ? "" : "This field is required"
    }>
      {({ field, form }: { field: any, form: any }) => (
        <FormControl isInvalid={form.errors[props.name] && form.touched[props.name]}>
          <FormLabel htmlFor={props.name}>{label}</FormLabel>
          <Input
            {...field}
            id={props.name}
            placeholder={props.name}
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
  const { name, username, email, password } = props;
  return (
    <Formik
      initialValues={{ name, username, email, password }}
      onSubmit={(values, actions) => {
        let { editUser, onClose } = props;
        let user: IUser = {
          name: values.name,
          username: values.username,
          email: values.email,
          password: values.password,
          id: (editUser) ? props.id : Math.random().toString(36).substr(2, 9),
          created_at: (editUser) ? props.created_at : new Date(Date.now())
        }
        if (editUser) 
          dispatch(thunkUpdateUser(user));
        else
          dispatch(thunkCreateUser(user));
        actions.setSubmitting(false)
        onClose();
      }}
    >
      {(props) => (
        <Form>
          <MyField label="Name" name="name" />
          <MyField label="Username" name="username" />
          <MyField label="Email" name="email" />
          <MyField label="Password" name="password" />
          <Button
            mt={4}
            colorScheme="brand"
            isLoading={props.isSubmitting}
            type="submit"
          >
            Submit
          </Button>
        </Form>
      )}
    </Formik>
  )
}

const UserForm = (props: FormInterface) => {
  const { isOpen, onClose, editUser, userData, title } = props;
  return (
    <>
      <Modal onClose={onClose} isOpen={isOpen} isCentered>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>{title}</ModalHeader>
          <ModalCloseButton />
          <ModalBody>
            <DataForm
              id={userData?.id}
              name={userData?.name}
              username={userData?.username}
              email={userData?.email}
              password={userData?.password}
              created_at={userData?.created_at}
              editUser={editUser}
              onClose={onClose}
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

export default UserForm;