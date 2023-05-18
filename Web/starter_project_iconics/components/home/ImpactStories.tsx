import { RootState } from '@/store'
import { useGetStoriesQuery } from '@/store/features/home/impact-stories/impact-stories-api'
import { selectStory } from '@/store/features/home/impact-stories/impact-stories-slice'
import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import Error from '../common/Error'
import ImpactImage from './ImpactImage'

const ImpactStories: React.FC = () => {
  const dispatch = useDispatch()
  const {
    data: impactStories = [],
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetStoriesQuery()

  const { currentStory } = useSelector(
    (state: RootState) => state.impactStories
  )

  useEffect(() => {
    if (impactStories.length > 0 && !currentStory) {
      dispatch(selectStory(impactStories[0]))
    }
  }, [dispatch, impactStories, currentStory])

  if (isLoading) {
    return (
      <div className="flex flex-col items-center px-20 py-16 gap-20">
        <h2 className="capitalize text-5xl font-bold font-montserrat">
          Impact stories
        </h2>
        <div className="flex flex-row justify-around gap-20 font-poppins w-full animate-pulse">
          <div className="flex flex-col gap-9 w-full md:w-5/12">
            <div className="flex flex-col gap-3">
              <div className="bg-gray-400 h-8 rounded-md w-1/3 mb-2"></div>
              <div className="bg-gray-400 h-8 rounded-md w-1/2 mb-2"></div>
            </div>
            <div className="">
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-8"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[4vw] xl:mr-16"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3.5vw] xl:mr-10"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3.5vw] xl:mr-10"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[5vw] xl:mr-20"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-8"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-16"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-10"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-10"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-20"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-16"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-10"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-10"></div>
              <div className="bg-gray-400 h-6 rounded-md mb-2 mr-[3vw] xl:mr-20"></div>
            </div>
            <div className="bg-gray-400 h-10 rounded-md w-1/3 mb-2"></div>
          </div>
          <div className="flex flex-row gap-[1.2vw] xl:gap-4 w-full md:w-5/12 items-center -mt-6">
            <div className="flex flex-col gap-y-[1.2vw] xl:gap-y-4 w-1/3">
              <div className="bg-gray-400 h-60 w-full rounded-sm"></div>
              <div className="bg-gray-400 h-60 w-full rounded-sm"></div>
            </div>
            <div className="flex flex-col gap-y-[1.2vw] xl:gap-y-4 w-1/3">
              <div className="bg-gray-400 h-60 w-full rounded-sm"></div>
              <div className="bg-gray-400 h-60 w-full rounded-sm"></div>
              <div className="bg-gray-400 h-60 w-full rounded-sm"></div>
            </div>
            <div className="flex flex-col gap-y-[1.2vw] xl:gap-y-4 w-1/3">
              <div className="bg-gray-400 h-60 w-full rounded-sm"></div>
              <div className="bg-gray-400 h-60 w-full rounded-sm"></div>
            </div>
          </div>
        </div>
      </div>
    )
  } else if (
    isError ||
    !isSuccess ||
    !impactStories ||
    !currentStory ||
    error
  ) {
    return <Error />
  }

  return (
    <div className="flex flex-col items-center px-20 py-16 gap-20">
      <h2 className="capitalize text-5xl font-bold font-montserrat text-center">
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
          <p className="text-secondary-text text-[3vw] md:text-xl">
            {currentStory.description}
          </p>
          <button className="text-center rounded w-1/3 px-6 py-2 bg-primary capitalize text-blue-100 hover:bg-blue-600 duration-300">
            See more
          </button>
        </div>
        <div className="flex flex-row gap-[1.2vw] xl:gap-4 w-full md:w-5/12 items-center -mt-6">
          <div className="flex flex-col gap-y-[1.2vw] xl:gap-y-4 w-1/3">
            <ImpactImage
              story={impactStories[0]}
              currentStory={currentStory}
              dispatch={dispatch}
            />
            <ImpactImage
              story={impactStories[1]}
              currentStory={currentStory}
              dispatch={dispatch}
            />
          </div>
          <div className="flex flex-col gap-y-[1.2vw] xl:gap-y-4 w-1/3">
            <ImpactImage
              story={impactStories[2]}
              currentStory={currentStory}
              dispatch={dispatch}
            />
            <ImpactImage
              story={impactStories[3]}
              currentStory={currentStory}
              dispatch={dispatch}
            />
            <ImpactImage
              story={impactStories[4]}
              currentStory={currentStory}
              dispatch={dispatch}
            />
          </div>
          <div className="flex flex-col gap-y-[1.2vw] xl:gap-y-4 w-1/3">
            <ImpactImage
              story={impactStories[5]}
              currentStory={currentStory}
              dispatch={dispatch}
            />
            <ImpactImage
              story={impactStories[6]}
              currentStory={currentStory}
              dispatch={dispatch}
            />
          </div>
        </div>
      </div>
    </div>
  )
}

export default ImpactStories
