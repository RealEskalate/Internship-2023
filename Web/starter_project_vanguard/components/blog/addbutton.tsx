import React, { useState } from 'react';
import Text from '@/components/blog/text'
interface Props {}

const Button: React.FC<Props> = () => {

  return (
    <div className='w-60 '>
      <button
        className="bg-blue-800 hover:bg-blue-700 text-white py-4 h-16  px-10 rounded-full flex items-center font-montserrat">
        <i>
            <Text children={'+ New Blog'} size='lg' weight='semibold' family='montserrat'/>
        </i>
        
      </button>
    </div>
  );
};

export default Button;
