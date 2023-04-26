import React from 'react'
import SuccessStoryCard from './SuccessStoryCard'
import SuccessStorys from './SuccessStoryDataSets'
const SuccessStory = () => {
  return (
    <div className = "flex flex-col mx-10 my-10 gap-10 Profile-container">
        {SuccessStorys.map((successStory, index)=>
        
        {
            return <SuccessStoryCard key = {index} successStory = {successStory}/>;
        })}
      
    </div>
  )
}

export default SuccessStory
