import 'typeface-montserrat'
import Text from './Text'

function Description() {
  return (
    <div className="pt-4 w-2/3">
      <Text
        children={
          'Lorem ipsum dolor sit amLorem ipsum dolor sit amet consectetur Lorem ipsum dolor sit amet consectetur Lorem ipsum dolor sit amet consectetur et consectetur adipisicing elit. Blanditiis id deserunt dolor.'
        }
        color="gray-500"
        weight="light"
        size="lg"
      />
    </div>
  )
}

export default Description
