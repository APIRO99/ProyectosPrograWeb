// Chakra imports
import { Portal, Box, useDisclosure, Button } from '@chakra-ui/react';
import Footer from 'components/footer/FooterAdmin';
// Layout components
import Navbar from 'components/navbar/NavbarAdmin';
import Sidebar from 'components/sidebar/Sidebar';
import { SidebarContext } from 'contexts/SidebarContext';
import { useEffect, useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import routes from 'routes/routes';
import { useTypedDispatch, useTypedSelector } from 'store/hooks';
import { thunkDeleteProperty, thunkGetProperties } from 'store/thunk/Properties';
import Card from './components/Card';
import PropertyForm from './components/PropertyForm';

interface IFormData {
	isOpen: boolean;
	editProperty: boolean;
	propertyData?: IProperty;
	title: string;
}

const Properties = () => {

	const { isOpen, onClose, onOpen } = useDisclosure();
	const { properties } = useTypedSelector((state) => state);
	const [fd, setFormData] = useState<IFormData>(undefined);
	const dispatch = useTypedDispatch();
	useEffect(() => {
		dispatch(thunkGetProperties());
	}, []);

	const handleCreate = () => {
		setFormData({
			isOpen: true,
			editProperty: false,
			propertyData: undefined,
			title: "Create Property"
		});
		onOpen();
	}

	const handleEdit = (property: IProperty) => {
		setFormData({
			isOpen: true,
			editProperty: true,
			propertyData: property,
			title: "Edit Property"
		});
		onOpen();
	}
	const handleDelete = (id: number) => {
		dispatch(thunkDeleteProperty(id));
	}

	document.documentElement.dir = 'ltr';
	return (
		<Box display='flex' flexDirection='column'>
			<Button colorScheme="green" onClick={handleCreate} alignSelf='flex-end' me='50px' my='10px'>Add Property</Button>
			<Box display='flex' flexWrap='wrap' justifyContent='space-evenly'>
				{
					properties.map((property) => {
						return <Card key={property.id} {...property} onClick={() => handleEdit(property)} handleDelete={handleDelete} />
					})
				}
			</Box>
			<PropertyForm
				isOpen={isOpen}
				onClose={onClose}
				editProperty={fd?.editProperty}
				propertyData={fd?.propertyData}
				title={fd?.title}
				handleDelete={handleDelete}
			/>
		</Box>
	);
}

export default Properties;