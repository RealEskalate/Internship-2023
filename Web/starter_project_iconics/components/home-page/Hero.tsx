import Image from 'next/image'
import { BsArrowRightShort } from 'react-icons/bs'
import Button from '../common/Button'

const Hero: React.FC = () => {
  return (
    <div className="flex flex-col gap-20 lg:gap-0 lg:flex-row justify-around p-16">
      <div className="flex flex-col items-center basis-5/12 gap-10">
        <h1 className="text-7xl font-extrabold">
          Africa to <span className="text-primary">Silicon Valley</span>
        </h1>
        <p className="text-secondary-text text-3xl">
          A2SV up-skills high-potential university students, connects them with
          opportunities at top tech companies
        </p>
        <div className="flex flex-row items-center gap-4 w-full">
          <button className="rounded-lg mx-5 py-2 capitalize w-1/3 border-2 border-primary text-primary hover:bg-blue-600 hover:text-blue-100 duration-300">
            Get started
          </button>
          
          <Button label='Support Us' endIcon={<BsArrowRightShort className="hidden md:flex" size={25} />}></Button>
        </div>
      </div>
      <div className="w-full lg:w-6/12">
        <Image
          src="/img/home-page/hero.png"
          alt="landing page image"
          width={1000}
          height={1000}
        />
      </div>
    </div>
  )
}

export default Hero
