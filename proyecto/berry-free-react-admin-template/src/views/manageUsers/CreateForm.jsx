// material-ui
import { Modal, Button, Typography, Grid, FormControl, TextField, FormLabel, CardContent } from '@mui/material';
import MainCard from 'ui-component/cards/MainCard';
import { useDispatch } from 'react-redux';
import { POST_CREATE_USERS } from 'store/actions';

const EditForm = ({ user, open, handleClose }) => {
    const dispatch = useDispatch();
    const handleChange = (e) => {
        user[e.target.id] = e.target.value;
    };
    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(user);
        dispatch({ type: POST_CREATE_USERS, user });
        handleClose();
    };

    return (
        <Modal open={open} onClose={handleClose} sx={{ display: 'flex', justifyContent: 'center', alignContent: 'center' }}>
            <MainCard content={false} sx={{ height: '600px', width: '600px', marginTop: '100px' }}>
                <CardContent>
                    <Grid container>
                        <Grid item xs={12}>
                            {/* <Typography id="modal-modal-title" variant="h6" component="h2">
                                {user.name || 'name not found'}
                            </Typography> */}
                            <form onSubmit={handleSubmit} onChange={handleChange}>
                                <FormControl fullWidth={true}>
                                    <FormLabel>Name</FormLabel>
                                    <TextField id="name" type="text" defaultValue={user.name} />
                                    <FormLabel>Email</FormLabel>
                                    <TextField id="email" type="text" defaultValue={user.email} />
                                    <FormLabel>Password</FormLabel>
                                    <TextField id="password" type="text" defaultValue={user.password} />
                                    <Button type="submit">Create User</Button>
                                </FormControl>
                            </form>
                        </Grid>
                    </Grid>
                </CardContent>
            </MainCard>
        </Modal>
    );
};

export default EditForm;
