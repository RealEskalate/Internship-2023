import React from 'react'

interface Partner {
  companyName: string
  imgURL: string
}

const partners: Partner[] = [
  {
    companyName: 'Google',
    imgURL: '/images/success-story/companies/google.png',
  },
  {
    companyName: 'Palantir',
    imgURL: '/images/success-story/companies/palantir.png',
  },
  {
    companyName: 'InstaDeep',
    imgURL: '/images/success-story/companies/inst-deep.png',
  },
  { companyName: 'Meta', imgURL: '/images/success-story/companies/meta.png' },
  {
    companyName: 'Databricks',
    imgURL: '/images/success-story/companies/databricks.png',
  },
  {
    companyName: 'LinkedIn',
    imgURL: '/images/success-story/companies/linkedIn.png',
  },
]

const Partners: React.FC = () => {
  return (
    <div className="max-w-screen-lg mt-20">
      <h1 className="font-DMSans text-5xl font-semibold mb-16 text-center">
        Current Interview Partners
      </h1>
      <div className="flex flex-wrap justify-around	 gap-1">
        {partners.map((partner, index) => (
          <img key={index} src={partner.imgURL} alt={partner.companyName} />
        ))}
      </div>
    </div>
  )
}

export default Partners
