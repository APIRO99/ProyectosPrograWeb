import Header from '@src/components/Header'
import SubHeader from '@src/components/SubHeader'
import LandingBackground from '@assets/images/LandingBackground.jpg'
import LandingImage from '@assets/images/LandingImage.jpg'
import { Grid, Typography, Button } from '@mui/material'
import palette from '@src/theme/light'

const Modelos = () => {
  return (
    <Grid container 
      justifyContent="center" 
      alignItems="center" 
      textAlign='center' 
      display='flex' 
    >
      <Grid item xs={12} md={6} >
        <Typography variant='h1'>Aqui ira el componente de modelos</Typography>
      </Grid>
    </Grid>
  )
}

const Welcome = () => {
  return (
    <Grid
      container 
      justifyContent="center" 
      alignItems="center"
      textAlign='center'
      display='flex'
      position='absolute'
      sx={{ height: '58%', width: '100%'}}
    >
      <Grid item xs={12} md={6} >
        <Typography variant='h2' color="common.white">Tu camino a</Typography> 
        <Typography variant='h4' color="common.white">La Naturaleza</Typography> 
        <Button color='secondary'>Ver Disponibilidad</Button>
      </Grid>
      <Grid item  xs={12} md={6}>
        <img src={LandingImage} alt="Imagen Principal" style={{ height: '400px' }} />
      </Grid>
    </Grid>
  )
}



const Home = () => {
  return (
    <>
      <Header />
      <SubHeader backgroundOpacity={0} />
      <Grid container>
        <Grid item xs={12}>
          <div style={{ height: '600px', width: '100%', background: palette.palette.primary.main }}>
            <img src={LandingBackground} alt="Imagen de fondo" style={{ height: '100%', width: '100%', objectFit: 'cover', opacity: '0.3' }} />
          </div>
        </Grid>
        <Welcome />
        <Modelos />
      </Grid>
    </>
  )
}

export default Home