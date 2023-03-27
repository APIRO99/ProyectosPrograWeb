import Header from '@src/components/Header'
import SubHeader from '@src/components/SubHeader'
import LandingBackground from '@assets/images/LandingBackground.jpg'
import LandingImage from '@assets/images/LandingImage.jpg'
import { Grid } from '@mui/material'

const Home = () => {
  return (
    <>
      <Header />
      <SubHeader backgroundOpacity={0} />
      <Grid container>
        <Grid container item sx={{position: 'absolute', zIndex: '-1', top: 0}}>
          <img src={LandingBackground} alt="Imagen de fondo" style={{height: '80vh', width: '100%', objectFit: 'cover'}}/>
        </Grid>
        <Grid container item>
          <img src={LandingImage} alt="Imagen Principal" style={{height: '400px '}} />
        </Grid>
      </Grid>
    </>
  )
}

export default Home