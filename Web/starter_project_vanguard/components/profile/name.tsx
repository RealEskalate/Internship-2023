import React from 'react'
import Text from '../common/text'
import "typeface-montserrat";

function Name() {
  return (
    <div >
        <Text  size="sm" family="montserrat" children={'Yididya Kebede'} color="black" weight='semibold'></Text>
        <br></br>
        <Text size="sm" family='montserrat' children={'SOFTWARE ENGINEER'} color='gray-500' />    
        </div>
  )
}

export default Name