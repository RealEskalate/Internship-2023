import impactStories from '@/data/home/impact-story.json'
import React, { useState } from 'react'
import ImpactImage from './ImpactImage'

const ImpactStories: React.FC = () => {
  const [currentStory, setCurrentStory] = useState(impactStories[0])

  return (
    <div className="flex flex-col items-center px-20 py-16 gap-20">
      <h2 className="capitalize text-5xl font-bold font-montserrat">
        Impact stories
      </h2>
      <div className="flex flex-row justify-around gap-20 font-poppins">
        <div className="flex flex-col gap-9 w-full md:w-5/12">
          <div className="flex flex-col gap-3">
            <h3 className="text-primary-text font-semibold text-2xl Capitalize">
              {currentStory.name}
            </h3>
            <p className="text-secondary-text text-xl font-medium">
              {currentStory.title}
            </p>
          </div>
          <p className="text-secondary-text text-xl">
            {currentStory.description}
          </p>
          <button className="text-center rounded w-1/3 px-6 py-2 bg-primary capitalize text-blue-100 hover:bg-blue-600 duration-300">
            See more
          </button>
        </div>
        <div className="flex flex-row gap-[1.2vw] w-full md:w-5/12 items-center -mt-6">
          <div className="flex flex-col gap-y-[1.2vw] w-1/3">
            <ImpactImage
              story={impactStories[0]}
              currentStory={currentStory}
              setCurrentStory={setCurrentStory}
            />
            <ImpactImage
              story={impactStories[1]}
              currentStory={currentStory}
              setCurrentStory={setCurrentStory}
            />
          </div>
          <div className="flex flex-col gap-y-[1.2vw] w-1/3">
            <ImpactImage
              story={impactStories[2]}
              currentStory={currentStory}
              setCurrentStory={setCurrentStory}
            />
            <ImpactImage
              story={impactStories[3]}
              currentStory={currentStory}
              setCurrentStory={setCurrentStory}
            />
            <ImpactImage
              story={impactStories[4]}
              currentStory={currentStory}
              setCurrentStory={setCurrentStory}
            />
          </div>
          <div className="flex flex-col gap-y-[1.2vw] w-1/3">
            <ImpactImage
              story={impactStories[5]}
              currentStory={currentStory}
              setCurrentStory={setCurrentStory}
            />
            <ImpactImage
              story={impactStories[6]}
              currentStory={currentStory}
              setCurrentStory={setCurrentStory}
            />
          </div>
        </div>
      </div>
    </div>
  )
}

export default ImpactStories
