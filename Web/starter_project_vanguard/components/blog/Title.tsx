import Text from './Text'

import 'typeface-montserrat'

function Title() {
  return (
    <div>
      {/* <Text size="2xl" family="montserrat" children={'Yididya Kebede'} color="black"></Text> */}

      <Text
        size="2xl"
        children={'The essential guide to Competitive Programming, '}
        weight="bold"
      />
      <br />
      <Text
        size="2xl"
        children={'Tab System On React : 3 ways to do it.'}
        weight="bold"
      />
    </div>
  )
}

export default Title
