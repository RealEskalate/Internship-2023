import React from 'react';

const PartnerLogos: React.FC = () => {
  return (
    <div className="container mx-auto bg-white">
        <h2 className="text-3xl font-semibold text-center mb-6 mt-8 font-DMSans">Current Interview Partners</h2>
        <div className="flex justify-center items-center flex-wrap gap-8">
          <div className="w-52 h-52 flex justify-center items-center bg-white rounded-full">
            <img src="/success-stories-images/google.png" alt="Google logo" />
          </div>
          <div className="w-52 h-52 flex justify-center items-center bg-white rounded-full">
            <img src="/success-stories-images/palantir.png" alt="Palantir logo" />
          </div>
          <div className="w-52 h-52 flex justify-center items-center bg-white rounded-full">
            <img src="/success-stories-images/inst-deep.png" alt="Instdeep logo" />
          </div>
          <div className="w-52 h-52 flex justify-center items-center bg-white rounded-full">
            <img src="/success-stories-images/meta.png" alt="meta logo" />
          </div>
        </div>
        <div className="flex justify-center items-center flex-wrap gap-4 mt-0 space-x-64">
          <div className="w-52 h-52 flex justify-center items-center bg-white rounded-full">
            <img src="/success-stories-images/databricks.png" alt="databricks logo" />
          </div>
          <div className="w-52 h-52 flex justify-center items-center bg-white rounded-full">
            <img src="/success-stories-images/linkedin.png" alt="linkedin logo" />
          </div>
        </div>
      </div>
  );
};

export default PartnerLogos;
