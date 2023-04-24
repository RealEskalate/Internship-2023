import React from 'react';

type GlassImageProps = {
  image: string;
  name: string;
  job: string;
  location: string;
};

const GlassImage: React.FC<GlassImageProps> = ({ image, name, job, location }) => {
  return (
    <div className="relative inline-block sm:max-w-md md:max-w-md lg:w-auto">
      <img src={image} alt="image"  />
      <div className="absolute bottom-0 left-0 right-0 backdrop-filter backdrop-blur-md rounded-xl w-full z-10">
        <div className="lg:m-4 lg:py-2">
          <p className="lg:pt-4 px-4 font-poppins text-2xl font-bold text-gray-50">{name}</p>
          <p className="px-4 py-2 font-poppins text-xl font-semibold text-gray-50">{job}</p>
          <p className="px-4 pb-4 font-poppins text-xl text-gray-50">{location}</p>
        </div>
      </div>
    </div>
  );
};

export default GlassImage;


