import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Button from '@mui/material/Button';
import logo from '@assets/images/logo.svg'
import { Link } from 'react-router-dom';

function Header() {
  return (
    <AppBar position="static" sx={{ height:'180px', justifyContent: 'center'}}>
      <Toolbar>
        <div style={{ flexGrow: 1, display: 'flex' }}>
          <img src={logo} alt="Logo" style={{ height: '90%', marginRight: '10px', justifyContent: 'center' }} />
        </div>
        <Button component={Link} to="/contact" color="inherit">Contact</Button>
      </Toolbar>
    </AppBar>
  );
}

export default Header;