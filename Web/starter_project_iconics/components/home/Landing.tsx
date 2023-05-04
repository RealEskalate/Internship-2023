import Image from 'next/image'
import { BsArrowRightShort } from 'react-icons/bs'

const Landing: React.FC = () => {
  return (
    <div className="flex flex-col gap-20 lg:gap-0 lg:flex-row justify-around p-12">
      <div className="flex flex-col basis-5/12 gap-10">
        <h1 className="text-7xl font-extrabold text-center md:text-left">
          Africa to <span className="text-primary">Silicon Valley</span>
        </h1>
        <p className="text-primary-text leading-normal text-4xl text-center md:text-left">
          A2SV up-skills high-potential university students, connects them with
          opportunities at top tech companies
        </p>
        <div className="flex flex-row gap-4 w-full justify-center md:justify-start">
          <button className="rounded-lg py-2 capitalize w-1/3 border-primary border-[3px] text-xl font-medium text-primary hover:bg-blue-600 hover:border-blue-600 hover:text-blue-100 duration-300">
            Get started
          </button>
          <button className="flex flex-row items-center justify-center gap-1 rounded-lg text-xl font-semibold w-1/3 py-2 bg-primary text-blue-100 hover:bg-blue-600 duration-300 uppercase">
            <p>SUPPORT US</p>
            <BsArrowRightShort className="hidden md:flex" size={30} />
          </button>
        </div>
      </div>
      <div className="w-full lg:w-5/12">
        <Image
          src="/img/home/hero.png"
          alt="landing page image"
          width={1000}
          height={1000}
        />
      </div>
    </div>
  )
}

export default Landing
