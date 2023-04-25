import React from 'react';
import { GlassImage, TextSection, PartnerLogos } from '../../components/story/Stories';

import imagesData from '../../data/story/success-stories';
// type ImageData = {
//   image: string;
//   name: string;
//   job: string;
//   location: string;
// }
const StoryPage: React.FC = () => {
  
  return (
    <div className="bg-white">
      <div className="flex justify-center pt-8">
        <h1 className="font-poppins text-5xl font-semibold">Impact Stories</h1>
      </div>
      <div className="flex justify-center mx-2 mt-5">
        <div className="flex justify-center max-w-2xl ">
          <p className="text-center font-poppins text-2xl">Behind every success is a story. Learn about the stories of A2SVians</p>
        </div>
      </div>
      <div className="flex justify-center mt-2">
        <hr className="border-2 w-14  border-blue-700" />
      </div>
    
      <div className="flex flex-col lg:flex-row justify-center ml-2 mt-28">
        
        {imagesData.map((data, index) => (
          <>
            <div className="lg:block">
              <GlassImage {...data} />
            </div>
            <div className="mt-0 max-w-xl">
              <TextSection/>
            </div>
          </>
        ))}
      
        {/* <div className="mt-0 max-w-xl">
          <TextSection/>
        </div> */}
      </div>

      {/* <div className="flex flex-col lg:flex-row justify-center ml-2 mt-28">
        <div className="lg:block">
          <GlassImage
            image="/img/success-stories-images/people/yishak.png"
            name="Yishak Bogale"
            job="Software Engineering Intern"
            location="Google - Mountain View, CA, USA"
          />
        </div>
        <div className="mt-0 max-w-xl">
          <TextSection/>
        </div>
      </div>

      <div className="flex flex-col lg:flex-row justify-center ml-2 mt-20">
        <div className="mt-0 max-w-xl ">
          <TextSection/>
        </div>
        <div className="lg:block ">
          <GlassImage
            image="/img/success-stories-images/people/lydia.png"
            name="Lydia Gashawtena"
            job="Software Engineering Intern"
            location="Google - Mountain View, CA, USA"
          />
        </div>
      </div>

      <div className="flex flex-col lg:flex-row justify-center ml-2 mt-20">
        <div className="lg:block">
          <GlassImage
            image="/img/success-stories-images/people/biruk.png"
            name="Biruk Ayalew"
            job="Software Engineering Intern"
            location="Google - Mountain View, CA, USA"
          />
        </div>
        <div className="mt-0 max-w-xl ">
          <TextSection/>
        </div>
      </div> */}

      <PartnerLogos />

    </div>
  );
};

export default StoryPage;
