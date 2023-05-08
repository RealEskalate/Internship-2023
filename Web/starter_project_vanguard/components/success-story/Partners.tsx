import Image from 'next/image';
import React from 'react';

interface Partner {
  companyName: string;
  imgURL: string;
}

const partners: Partner[] = [
  {
    companyName: 'Google',
    imgURL: 'google.png',
  },
  {
    companyName: 'Palantir',
    imgURL: 'palantir.png',
  },
  {
    companyName: 'InstaDeep',
    imgURL: 'insta-deep.png',
  },
  {
    companyName: 'Meta',
    imgURL: 'meta.png',
  },
  {
    companyName: 'Databricks',
    imgURL: 'databricks.png',
  },
  {
    companyName: 'LinkedIn',
    imgURL: 'linkedIn.png',
  },
];

const Partners: React.FC = () => {
  return (
    <div className="max-w-screen-lg mt-20">
      <h1 className="font-DMSans text-4xl md:text-5xl font-semibold mb-16 text-center">
        Current Interview Partners
      </h1>
      <div className="flex flex-wrap justify-around	 gap-1">
        {partners.map((partner, index) => (
          <Image
            key={index}
            width={251}
        height={110}
        className="max-w-[251px]"
        layout="responsive"
            src={`/images/success-story/companies/${partner.imgURL}`} // Concatenate the common path with imgURL
            alt={partner.companyName}
          />
        ))}
      </div>
    </div>
  );
};

export default Partners;
