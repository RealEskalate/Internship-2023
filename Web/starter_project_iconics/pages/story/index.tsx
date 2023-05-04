import React from 'react'
import { GlassImage, TextSection, PartnerLogos } from '../../components/story/Stories'
import imagesData from "../../data/story/success-stories"

const StoryPage: React.FC = () => {
  return (
    <div className="bg-white text-primary-text flex justify-center flex-col items-center">
      <div className='font-poppins text-center'>
        <div className=" pt-8">
          <h1 className="text-5xl font-semibold">Impact Stories</h1>
        </div>
        <div className=" mx-2 mt-5 max-w-2xl">
          <p className="text-2xl">Behind every success is a story. Learn about the stories of A2SVians</p>
        </div>
        <div className="mt-4">
          <hr className="border-2 w-14  border-blue-700 mx-auto" />
        </div>
      </div>
      
      <div className={`flex flex-col md:flex-row ${imagesData.length % 2 === 1 ? 'md:flex-col' : 'md:flex-row'} justify-center items-center md:items-start mt-8`}>
        {imagesData.map((data, index) => (
          <div key={index} className={`flex flex-col md:flex-row justify-center mt-20 items-center md:justify-start ${index % 2 === 1 ? 'md:flex-row-reverse' : ''}`}>
            <div className="mb-4 md:mb-0 md:mr-8">
              <GlassImage image={data.imageURL} name={data.personName} job={data.role} location={data.location}/>
            </div>
            <div className="md:max-w-xl">
              {data.story.map(text => <TextSection key={text.heading} heading={text.heading} paragraph={text.paragraph}/>)}
            </div>
          </div>
        ))}
      </div>

      <div>
        <PartnerLogos />
      </div>

    </div>
  )
}

export default StoryPage
