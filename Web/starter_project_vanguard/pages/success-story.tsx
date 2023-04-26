import Partners from '@/components/success-story/Partners'
import SuccessDescription from '@/components/success-story/SuccessDescription'
import SucessImage from '@/components/success-story/SuccessImage'
import { SuccessStories } from '@/types/success-story'
import Head from 'next/head'

export default function SucessStory() {
  return (
    <>
      <Head>
        <link
          href="https://fonts.googleapis.com/css2?family=Neucha&display=swap"
          rel="stylesheet"
        />
        <link
          href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;600;700;800;900&family=Roboto&display=swap"
          rel="stylesheet"
        />
        <title> Success Stories</title>
      </Head>
      <main>
        <div className="flex justify-center mt-4">
          <h1 className="font-poppins text-5xl font-semibold">
            Impact Stories
          </h1>
        </div>
        <div className="flex justify-center mx-2 mt-2">
          <div className="flex justify-center max-w-xl">
            <p className="text-center font-poppins text-2xl">
              Behind every success is a story. Learn about the stories of
              A2SVians
            </p>
          </div>
        </div>
        <div className="flex justify-center">
          <hr className="border-2 w-10 rounded-sm border-blue-700" />
        </div>
        <div className="flex justify-center">
          <div className="max-w-5xl">
            <div>
              {SuccessStories.map((successStory, index) => (
                <div
                  key={index}
                  className={`flex flex-col lg:flex-row justify-center ml-2 mt-20 ${
                    index % 2 === 1 ? 'lg:flex-row-reverse' : ''
                  }`}
                >
                  <div className="  lg:block">
                    <SucessImage
                      name={successStory.personName}
                      image={successStory.imgURL}
                      category={successStory.role}
                      location={successStory.location}
                    />
                  </div>
                  <div className="mt-0">
                    {successStory.story.map((story, index) => (
                      <SuccessDescription
                        heading={story.heading}
                        paragraph={story.paragraph}
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
