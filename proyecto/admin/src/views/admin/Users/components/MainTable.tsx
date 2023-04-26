import { Box, Button, Table, TableCaption, Tbody, Td, Tfoot, Th, Thead, Tr, useDisclosure } from "@chakra-ui/react";
import { useEffect, useState } from "react";
import { useTypedDispatch, useTypedSelector } from "store/hooks";
import { thunkDeleteUser, thunkGetUsers } from "store/thunk/Users";
import UserForm from "./UserForm";

interface IFormData {
  isOpen: boolean;
  editUser: boolean;
  userData?: IUser;
  title: string;
}

const MainTable = () => {

  const users = useTypedSelector<Array<IUser>>(state => state.users);
  const dispatch = useTypedDispatch();

  const { isOpen, onOpen, onClose } = useDisclosure();
  const [fd, setFormData] = useState<IFormData>(undefined);


  useEffect(() => {
    dispatch(thunkGetUsers());
  }, []);
  const handleCreate = () => {
    setFormData({
      isOpen: true,
      editUser: false,
      title: 'Create User'
    });
    onOpen();
  }
  const handleEdit = (id: string) => {
    const editUserData = users.find((user: IUser) => user.id === id);
    setFormData({
      isOpen: true,
      editUser: true,
      userData: editUserData,
      title: 'Edit User'
    });
    onOpen();
  }
  const handleDelete = (id: string) => {
    dispatch(thunkDeleteUser(id));
  }
  return (
    <Box display='flex' flexDirection='column'>
      <Button colorScheme="green" onClick={handleCreate} alignSelf='flex-end' me='50px' my='10px'>Add User</Button>
      <Table variant="striped" colorScheme="brand">
        <TableCaption>Users allowed to use admin dashboard</TableCaption>
        <Thead>
          <Tr>
            <Th>Name</Th>
            <Th>UserName</Th>
            <Th>email</Th>
            <Th display='flex' justifyContent='center'>
              Actions
            </Th>
          </Tr>
        </Thead>
        <Tbody>
          {
            users.map((user: IUser) => (
              <Tr key={user.id}>
                <Td>{user.name}</Td>
                <Td>{user.username}</Td>
                <Td>{user.email}</Td>
                <Td display='flex' justifyContent='space-evenly'>
                  <Button colorScheme="blue" mr="4" onClick={() => handleEdit(user.id)}>
                    Edit
                  </Button>
                  <Button colorScheme="red" onClick={() => handleDelete(user.id)}>Delete</Button>
                </Td>
              </Tr>
            ))
          }
        </Tbody>
      </Table>
      <UserForm isOpen={isOpen} onClose={onClose} editUser={fd?.editUser} userData={fd?.userData} title={fd?.title} />
    </Box>
  );
};



export default MainTable;
