// material-ui
import { Modal, Button, Typography, Grid, FormControl, TextField, FormLabel, CardContent } from '@mui/material';
import MainCard from 'ui-component/cards/MainCard';
import { useDispatch } from 'react-redux';
import { POST_CREATE_PROPERTIES } from 'store/actions';

const EditForm = ({ property, open, handleClose }) => {
    const dispatch = useDispatch();
    const handleChange = (e) => {
        property[e.target.id] = e.target.value;
    };
    const handleSubmit = (e) => {
        e.preventDefault();
        dispatch({ type: POST_CREATE_PROPERTIES, property });
        handleClose();
    };

    return (
        <Modal open={open} onClose={handleClose} sx={{ display: 'flex', justifyContent: 'center', alignContent: 'center' }}>
            <MainCard content={false} sx={{ height: '600px', width: '600px', marginTop: '100px' }}>
                <CardContent>
                    <Grid container>
                        <Grid item xs={12}>
                            {/* <Typography id="modal-modal-title" variant="h6" component="h2">
                                {property.name || 'name not found'}
                            </Typography> */}
                            <form onSubmit={handleSubmit} onChange={handleChange}>
                                <FormControl fullWidth={true}>
                                    <FormLabel>Name</FormLabel>
                                    <TextField id="name" type="text" defaultValue={property.name} />
                                    <FormLabel>Address</FormLabel>
                                    <TextField id="address" type="text" defaultValue={property.address} />
                                    <FormLabel>city</FormLabel>
                                    <TextField id="city" type="text" defaultValue={property.city} />
                                    <FormLabel>state</FormLabel>
                                    <TextField id="state" type="text" defaultValue={property.state} />
                                    <FormLabel>photo</FormLabel>
                                    <TextField id="photo" type="text" defaultValue={property.photo} />
                                    <FormLabel>status</FormLabel>
                                    <TextField id="status" type="text" defaultValue={property.status} />
                                    <Button type="submit">Create Property</Button>
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
