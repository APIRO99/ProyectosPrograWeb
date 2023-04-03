// React
import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { POPULATE_USERS } from 'store/actions';

// material-ui
import { Button, Divider, Grid, Typography, Container } from '@mui/material';
// project imports
import MainCard from 'ui-component/cards/MainCard';
import EditForm from './EditForm';
import CreateForm from './CreateForm';

// ==============================|| SAMPLE PAGE ||============================== //

const UsersManager = () => {
    const dispatch = useDispatch();
    const { users } = useSelector((state) => state.users);

    useEffect(() => {
        dispatch({ type: POPULATE_USERS, users: [] });
    }, []);
    const [open, setOpen] = useState(false);
    const [create, setCreate] = useState(false);
    const [user, setuser] = useState({
        id: 0,
        name: '',
        email: '',
        password: ''
    });
    const handleOpen = (user) => {
        setuser(user);
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
    const handleCreate = () => {
        setuser({
            id: 0,
            name: '',
            email: '',
            password: ''
        });
        setCreate(true);
    };
    const handleCreateClose = () => {
        setCreate(false);
    };

    return (
        <>
            <MainCard title="Your user content administrators">
                <Grid>
                    {users?.map((user) => (
                        <Grid item xs={12} key={user.id} margin="25px">
                            <Grid container spacing={2}>
                                <Grid item xs={12}>
                                    <Grid container spacing={2}>
                                        <Grid item xs={12} md={6}>
                                            <Typography variant="h6">{user.name}</Typography>
                                            <Typography variant="body2">{user.email}</Typography>
                                        </Grid>
                                        <Grid item xs={12} md={6} textAlign="right">
                                            {/* <Typography variant="body2">Status: {user.status}</Typography> */}
                                            <Button color="primary" onClick={(ev) => handleOpen(user)}>
                                                Edit user
                                            </Button>
                                        </Grid>
                                    </Grid>
                                </Grid>
                            </Grid>
                            <br />
                            <Divider />
                        </Grid>
                    ))}
                </Grid>
                <Button onClick={handleCreate}>Add a user</Button>
            </MainCard>
            <CreateForm user={user} open={create} handleClose={handleCreateClose} />
            <EditForm user={user} open={open} handleClose={handleClose} />
        </>
    );
};

export default UsersManager;
