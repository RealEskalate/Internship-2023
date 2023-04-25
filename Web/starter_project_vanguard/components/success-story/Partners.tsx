import React from "react"

const Partners: React.FC = () => {
  return (
    <div className="max-w-screen-lg mt-20">
      <h1 className="font-DMSans text-5xl font-semibold mb-16 text-center">
        Current Interview Partners
      </h1>
      <div className="flex flex-col sm:flex-row  gap-1">
        <img
          src="/images/success-story/google.png"
          alt="Google logo"
          className="w-full max-w-screen-lg sm:max-w-none"
        />
        <img
          src="/images/success-story/palantir.png"
          alt="Palantir logo"
          className="w-full max-w-screen-lg sm:max-w-none"
        />
        <img
          src="/images/success-story/inst-deep.png"
          alt="InstaDeep logo"
          className="w-full max-w-screen-lg sm:max-w-none"
        />
        <img
          src="/images/success-story/meta.png"
          alt="Meta logo"
          className="w-full max-w-screen-lg sm:max-w-none"
        />
      </div>
      <div className="flex gap-1 flex-col sm:flex-row justify-between mx-0 md:mx-40">
        <img src="/images/success-story/databricks.png" alt="Databricks logo" />
        <img src="/images/success-story/linkedin.png" alt="LinkedIn logo" />
      </div>
    </div>
  )
}

export default Partners
