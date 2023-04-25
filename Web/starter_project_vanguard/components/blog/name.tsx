import React from 'react'
import Text from './text'
import "typeface-montserrat";

function Name() {
  return (
    <div className=" flex flex-col justify-center">
      <Text  size="sm" family="montserrat" children={'Yididya Kebede'} color="black" weight='semibold' className='block'></Text>

      <Text size="sm" family='montserrat' children={'SOFTWARE ENGINEER'} color='gray-500'  className='flex ' />    

        
      
     
        </div>
  )
}

export default Name