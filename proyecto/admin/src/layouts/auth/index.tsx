import { useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import routes from 'routes/routes';
import SignIn from 'views/auth/signIn';

// Chakra imports
import { Box, useColorModeValue } from '@chakra-ui/react';

// Layout components
import { SidebarContext } from 'contexts/SidebarContext';

// Custom Chakra theme
const Auth = () => {
	// states and functions
	const [toggleSidebar, setToggleSidebar] = useState(false);
	const authBg = useColorModeValue('white', 'navy.900');
	document.documentElement.dir = 'ltr';
	return (
		<Box>
			<SidebarContext.Provider
				value={{
					toggleSidebar,
					setToggleSidebar
				}}>
				<Box
					bg={authBg}
					float='right'
					minHeight='100vh'
					height='100%'
					position='relative'
					w='100%'
					transition='all 0.33s cubic-bezier(0.685, 0.0473, 0.346, 1)'
					transitionDuration='.2s, .2s, .35s'
					transitionProperty='top, bottom, width'
					transitionTimingFunction='linear, linear, ease'>
					<Box mx='auto' minH='100vh'>
						<SignIn />
					</Box>
				</Box>
			</SidebarContext.Provider>
		</Box>
	);
}

export default Auth;
