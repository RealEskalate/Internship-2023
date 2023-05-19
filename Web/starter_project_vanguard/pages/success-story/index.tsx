import Partners from '@/components/success-story/Partners'
import SuccessDescription from '@/components/success-story/SuccessDescription'
import SuccessImageCard from '@/components/success-story/SuccessImageCard'
import { useFetchSuccessStoryQuery } from '@/store/features/success-story/success-story-api'
import Link from 'next/link'
export default function SucessStory() {
  const { data:successData = [], isFetching } = useFetchSuccessStoryQuery()
  if (isFetching) {
    return (
      <div className=" h-screen flex justify-center items-center">
        <div
          className="inline-block h-8 w-8 animate-spin rounded-full border-4 border-solid border-current border-r-transparent align-[-0.125em] motion-reduce:animate-[spin_1.5s_linear_infinite]"
          role="status"
        >
          <span className="!absolute !-m-px !h-px !w-px !overflow-hidden !whitespace-nowrap !border-0 !p-0 ![clip:rect(0,0,0,0)]">
            Loading...
          </span>
        </div>
      </div>
    )
  }
  if (successData.length === 0) {
    return (
      <section className="flex items-center h-full p-16 dark:bg-gray-900 dark:text-gray-100">
        <div className="container flex flex-col items-center justify-center px-5 mx-auto my-8">
          <div className="max-w-md text-center">
            <h2 className="mb-8 font-extrabold text-9xl dark:text-gray-600">
              <span className="sr-only">Error</span>404
            </h2>
            <p className="text-2xl font-semibold md:text-3xl">
              Sorry, we couldn&apos;t find this page.
            </p>
            <p className="mt-4 mb-8 dark:text-gray-400">
              But dont worry, you can find plenty of other things on our
              homepage.
            </p>
            <Link
              rel="noopener noreferrer"
              href="/"
              className="px-8 py-3 font-semibold rounded dark:bg-violet-400 dark:text-gray-900"
            >
              Back to homepage
            </Link>
          </div>
        </div>
      </section>
    )
  }
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
              {successData.map((successStory, index) => (
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
                      <SuccessDescription
                        key={index}
                        successDescription={story}
                      />
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
