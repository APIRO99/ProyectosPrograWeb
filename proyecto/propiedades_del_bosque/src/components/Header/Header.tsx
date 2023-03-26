import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Button from '@mui/material/Button';
import logo from '@assets/images/logo.svg'
import { Link } from 'react-router-dom';

function Header() {
  return (
    <AppBar position="static">
      <Toolbar>
        <div style={{ flexGrow: 1 }}>
          <img src={logo} alt="Logo" style={{ height: '50px', marginRight: '10px' }} />
        </div>
        <Button component={Link} to="/" color="inherit">Home</Button>
        <Button component={Link} to="/about" color="inherit">About</Button>
        <Button component={Link} to="/contact" color="inherit">Contact</Button>
      </Toolbar>
    </AppBar>
  );
}

export default Header;