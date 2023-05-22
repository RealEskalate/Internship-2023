import { AppDispatch } from '@/store'
import { selectStory } from '@/store/features/home/impact-stories/impact-stories-slice'
import { ImpactStory } from '@/types/home/impact-story'
import Image from 'next/image'
import React from 'react'

interface ImpactProps {
  story: ImpactStory
  currentStory: ImpactStory
  dispatch: AppDispatch
}

const ImpactImage: React.FC<ImpactProps> = ({
  story,
  currentStory,
  dispatch,
}) => {
  const handleClick = () => {
    dispatch(selectStory(story))
  }
  return (
    <div
      className={`transition-all duration-1000 ${
        story.id === currentStory.id
          ? 'border-dashed border-2 border-sky-500 rounded rotate-6'
          : 'hover:animate-wiggle'
      } hover:drop-shadow-lg hover:cursor-pointer`}
      onClick={() => handleClick()}
    >
      <Image
        src={story.image}
        alt="impact stories gallery image"
        className=""
        width={1000}
        height={1000}
      />
    </div>
  )
}

export default ImpactImage
