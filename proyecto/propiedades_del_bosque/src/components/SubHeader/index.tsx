import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Button from '@mui/material/Button';
import { Link } from 'react-router-dom';

interface SubHeaderProps {
  backgroundOpacity?: number;
}

const SubHeader = ({backgroundOpacity =1 }: SubHeaderProps) =>{
  return (
    <AppBar position="static" sx={{ height:'70px', justifyContent: 'center', opacity: { backgroundOpacity }}}>
      <Toolbar>
        <div style={{ flexGrow: 1, display: 'flex' }}>
        </div>
        <Button component={Link} to="/" color="inherit">Home</Button>
        <Button component={Link} to="/models" color="inherit">Models</Button>
      </Toolbar>
    </AppBar>
  );
}

export default SubHeader;
