import React from 'react';

const PartnerLogos: React.FC = () => {
  return (
    <div className="container mx-auto bg-white">
        <h2 className="text-4xl font-semibold text-center mb-6 mt-8 font-DMSans">Current Interview Partners</h2>
        <div className="flex justify-center items-center flex-wrap gap-x-8">
          <div className="w-52 h-36 flex justify-center items-center bg-white rounded-full">
            <img src="/img/success-stories-images/companies/google-logo.png" alt="Google logo" />
          </div>
          <div className="w-52 h-36 flex justify-center items-center bg-white rounded-full">
            <img src="/img/success-stories-images/companies/palantir-logo.png" alt="Palantir logo" />
          </div>
          <div className="w-52 h-36 flex justify-center items-center bg-white rounded-full">
            <img src="/img/success-stories-images/companies/inst-deep-logo.png" alt="Instdeep logo" />
          </div>
          <div className="w-52 h-36 flex justify-center items-center bg-white rounded-full">
            <img src="/img/success-stories-images/companies/meta-logo.png" alt="meta logo" />
          </div>
        </div>
        <div className="flex justify-center items-center flex-wrap space-x-64">
          <div className="w-52 h-36 flex justify-center items-center bg-white rounded-full">
            <img src="/img/success-stories-images/companies/databricks-logo.png" alt="databricks logo" />
          </div>
          <div className="w-52 h-36 flex justify-center items-center bg-white rounded-full">
            <img src="/img/success-stories-images/companies/linkedin-logo.png" alt="linkedin logo" />
          </div>
        </div>
      </div>
  );
};

export default PartnerLogos;
