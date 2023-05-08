import { ImpactStory } from '@/types/home/impact-story'
import Image from 'next/image'
import React from 'react'

interface ImpactProps {
  story: ImpactStory
  stories: ImpactStory[]
  currentStory: ImpactStory
  setCurrentStory: React.Dispatch<React.SetStateAction<ImpactStory>>
}

const ImpactImage: React.FC<ImpactProps> = ({
  story,
  stories,
  currentStory,
  setCurrentStory,
}) => {
  const handleClick = (index: number) => {
    setCurrentStory(stories[index])
  }
  return (
    <div
      className={`${
        story.id === currentStory.id
          ? 'border-dashed border-2 border-sky-500 rounded'
          : ''
      } hover:drop-shadow-lg hover:cursor-pointer hover:animate-wiggle `}
      onClick={() => handleClick(story.id)}
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
