import Partners from '@/components/success-story/Partners'
import SuccessDescription from '@/components/success-story/SuccessDescription'
import SuccessImageCard from '@/components/success-story/SuccessImageCard'
import { SuccessStory } from '@/types/success-story'
import successStoryjsonData from '../../data/success-story.json'
export default function SucessStory() {
  const successStories: SuccessStory[] = successStoryjsonData
  return (
    <>
      <main>
        <div className="flex sm:justify-center mt-4 mx-6">
          <h1 className="font-poppins text-4xl md:text-5xl font-semibold">
            Impact Stories
          </h1>
        </div>
        <div className="flex justify-center mx-2 mt-2">
          <div className="flex justify-center max-w-xl">
            <p className="sm:text-center font-poppins text-xl md:text-2xl">
              Behind every success is a story. Learn about the stories of
              A2SVians
            </p>
          </div>
        </div>
        <div className="hidden sm:flex justify-center">
          <hr className="border-2 w-10 rounded-sm border-blue-700" />
        </div>
        <div className="flex justify-center">
          <div className="max-w-5xl">
            <div>
              {successStories.map((successStory, index) => (
                <div
                  key={index}
                  className={`flex flex-col lg:flex-row justify-center lg:items-center ml-2 mt-20 ${
                    index % 2 === 1 ? 'lg:flex-row-reverse' : ''
                  }`}
                >
                  <div className="md:ml-6 lg:block">
                    <SuccessImageCard
                      name={successStory.personName}
                      image={successStory.imgURL}
                      category={successStory.role}
                      location={successStory.location}
                    />
                  </div>
                  <div className="mt-0">
                    {successStory.story.map((story, index) => (
                      <SuccessDescription key={index} successDescription={story} />
                    ))}
                  </div>
                </div>
              ))}
            </div>
            <Partners />
          </div>
        </div>
      </main>
    </>
  )
}
