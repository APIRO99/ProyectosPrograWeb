import { StarIcon } from "@chakra-ui/icons"
import { Badge, Box, Image } from "@chakra-ui/react"
import { cursorTo } from "readline";

interface ICardProps extends IProperty {
  onClick: () => void;
}

const Card = (props: ICardProps) => {
  const { id, name, address, city, state, photo, status, beds, baths, weekRent, model } = props;
  const { onClick } = props;

  const formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
  });
  return (
    <Box 
      maxW="sm"
      borderWidth="1px"
      borderRadius="lg"
      overflow="hidden"
      margin='10px'
      onClick={onClick}
    >
      <Image 
        src={process.env.REACT_APP_STATIC_FILES_URL + photo} 
        alt="Property Image"
         w='382px' 
         h='215px'
         objectFit='cover'
      />

      <Box p="6">
        <Box d="flex" alignItems="baseline">
          <Badge 
            borderRadius="full" 
            px="2" 
            colorScheme={status==='available' ? 'green' : 'brand'}
          >
            {status}
          </Badge>
          <Box
            color="gray.500"
            fontWeight="semibold"
            letterSpacing="wide"
            fontSize="xs"
            textTransform="uppercase"
            ml="2"
          >
            {beds} beds &bull; {baths} baths
          </Box>
        </Box>

        <Box
          mt="1"
          fontWeight="semibold"
          as="h4"
          lineHeight="tight"
          isTruncated
        >
          {name}
        </Box>

        <Box>
          {formatter.format(weekRent)}
          <Box as="span" color="gray.600" fontSize="sm">
            / wk
          </Box>
        </Box>

        {/* <Box d="flex" mt="2" alignItems="center">
          {Array(5)
            .fill("")
            .map((_, i) => (
              <StarIcon
                key={i}
                color={i < rating ? "brand.500" : "gray.300"}
              />
            ))}
          <Box as="span" ml="2" color="gray.600" fontSize="sm">
            {reviewCount} reviews
          </Box>
        </Box> */}
      </Box>
    </Box>
  )
}

export default Card;