import React from 'react';
import { GlassImage, TextSection, PartnerLogos } from '../../components/story/Stories';
import imagesData from "../../data/story/success-stories";

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
        <div className=" pl-80 mt-4">
          <hr className="border-2 w-14  border-blue-700" />
        </div>
      </div>
      
      <div className={`flex ${imagesData.length % 2 === 1 ? 'flex-col' : 'flex-row'} justify-center mt-8`}>
        {imagesData.map((data, index) => (
          <div key={index} className={`flex justify-center mt-20 ${index % 2 === 1 ? 'lg:flex-row-reverse' : ''}`} >
            <div className="lg:block">
            <GlassImage image={data.imageURL} name={data.personName} job={data.role} location={data.location}/>
            </div>
            <div className="mt-0 max-w-xl">
              {data.story.map(text => <TextSection heading={text.heading} paragraph={text.paragraph}/>)}
            </div>
          </div>
        ))}
      </div>

      <div>
        <PartnerLogos />
      </div>

    </div>
  );
};

export default StoryPage;
