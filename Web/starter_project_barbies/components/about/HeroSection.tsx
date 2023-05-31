import Image from 'next/image'

const HeroSection: React.FC = () => {
  return (
    <div
      className="flex justify-center gap-10 flex-wrap"
      test-id="hero-section"
    >
      <div className="flex flex-col justify-center">
        <div className="font-bold md:text-2xl sm:text-xl lg:text-3xl xl:text-4xl p-3">
          <span className="text-primary">Africa </span>to Silicon Valley
        </div>
        <p className=" pt-7 p-3 max-w-md">
          A2SV is a social enterprise that enables high-potential university
          students to create digital solutions to Africa’s most pressing
          problems.
        </p>
        <button className="bg-primary py-5 px-10 rounded-xl text-white my-10 ">
          Meet Our Team
        </button>
        <p className=" max-w-md text-sm text-gray-500 p-3">
          A2SV is a social enterprise that enables high-potential university
          students to create digital solutions to Africa’s most pressing
          problems.
        </p>
      </div>
      <div className="gap-2">
        <div className="mb-10 font-bold p-3 text-xs sm:text-sm md:text-md lg:text-lg xl:text-xl">
          Group Activities
        </div>
        <div className="flex gap-2 flex-wrap">
          <div className="relative flex-1">
            <Image
              src="/img/about/hero/education-process.png"
              alt="education"
              style={{ width: 'auto', height: 'auto' }}
              width={300}
              height={50}
            />
            <div className="text-white text-xs sm:text-sm md:text-md lg:text-lg xl:text-xl text-center absolute inset-0 mx-auto my-auto w-36 h-fit">
              The Education Process
            </div>
          </div>
          <div className="relative flex-1">
            <Image
              src="/img/about/hero/development-phase.png"
              alt="development"
              style={{ width: 'auto', height: 'auto' }}
              width={300}
              height={50}
            />
            <div className="text-white text-xs sm:text-sm md:text-md lg:text-lg xl:text-xl text-center absolute inset-0 mx-auto my-auto w-36 h-fit">
              Development Phase
            </div>
          </div>
        </div>
        <div className="flex justify-end items-center rounded-lg w-full h-32 bg-gray-900 mt-3 pr-10">
          <div className="w-48 text-right text-white text-xs sm:text-sm md:text-md lg:text-lg ">
            <div className="font-bold mb-3"> 20% percent growth</div>
            <div>180% students growth 20% faster learning track</div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default HeroSection
