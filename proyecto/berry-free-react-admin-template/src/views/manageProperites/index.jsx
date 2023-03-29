// React
import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { POPULATE_PROPERTIES } from 'store/actions';

// material-ui
import { Button, Divider, Grid, Typography, Container } from '@mui/material';
// project imports
import MainCard from 'ui-component/cards/MainCard';
import EditForm from './EditForm';
import CreateForm from './CreateForm';

// ==============================|| SAMPLE PAGE ||============================== //

const PropertyManager = () => {
    const dispatch = useDispatch();
    const { properties } = useSelector((state) => state.properties);

    useEffect(() => {
        dispatch({ type: POPULATE_PROPERTIES, properties: [] });
    }, []);
    const [open, setOpen] = useState(false);
    const [create, setCreate] = useState(false);
    const [property, setProperty] = useState({
        id: 0,
        name: '',
        address: '',
        city: '',
        state: '',
        photo: '',
        status: ''
    });
    const handleOpen = (property) => {
        setProperty(property);
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
    const handleCreate = () => {
        setProperty({
            id: 0,
            name: '',
            address: '',
            city: '',
            state: '',
            photo: '',
            status: ''
        });
        setCreate(true);
    };
    const handleCreateClose = () => {
        setCreate(false);
    };

    return (
        <>
            <MainCard title="Your Active Properties">
                <Grid>
                    {properties?.map((property) => (
                        <Grid item xs={12} key={property.id} margin="25px">
                            <Grid container spacing={2}>
                                <Grid item xs={12} md={4} lg={3} xl={2}>
                                    <img
                                        style={{ maxHeight: '300px', maxWidth: '100%', objectFit: 'cover' }}
                                        src={property.photo}
                                        alt={property.name}
                                    />
                                </Grid>
                                <Grid item xs={12} md={8} lg={9} xl={10}>
                                    <Grid container spacing={2}>
                                        <Grid item xs={12} md={6}>
                                            <Typography variant="h6">{property.name}</Typography>
                                            <Typography variant="h5">Address: </Typography>
                                            <Typography variant="body2">{property.address}</Typography>
                                            <Typography variant="body2">
                                                {property.city}, {property.state}
                                            </Typography>
                                        </Grid>
                                        <Grid item xs={12} md={6} textAlign="right">
                                            <Typography variant="body2">Status: {property.status}</Typography>
                                            <Button color="primary" onClick={(ev) => handleOpen(property)}>
                                                Edit Property
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
                <Button onClick={handleCreate}>Add a Property</Button>
            </MainCard>
            <CreateForm property={property} open={create} handleClose={handleCreateClose} />
            <EditForm property={property} open={open} handleClose={handleClose} />
        </>
    );
};

export default PropertyManager;
