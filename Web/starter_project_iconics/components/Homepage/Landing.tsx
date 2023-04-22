import Image from 'next/image'
import { BsArrowRightShort } from 'react-icons/bs'

const Landing = () => {
  return (
    <div className="flex flex-row justify-between p-16">
      <div className="flex flex-col items-center justify-between basis-5/12">
        <div className="flex flex-col items-center justify-between">
          <h1 className="text-7xl font-extrabold">
            Africa to <span className="text-[#264FAD]">Silicon Valley</span>
          </h1>
          <p className="text-secondary-text text-3xl py-5">
            A2SV up-skills high-potential university students, connects them
            with opportunities at top tech companies
          </p>
          <div className="flex flex-row items-center justify-between">
            <button className="rounded-lg mx-5 px-6 py-2 border-2 border-blue-500 text-blue-500 hover:bg-blue-600 hover:text-blue-100 duration-300">
              Get started
            </button>
            <button className="flex flex-row items-center rounded-lg px-6 py-2 bg-primary text-blue-100 hover:bg-blue-600 duration-300">
              Primary <BsArrowRightShort size={30} />
            </button>
          </div>
        </div>
      </div>
      <Image
        src="/LandingPage.png"
        alt="Landing page picture"
        className="basis-6/12"
        width={500}
        height={300}
        priority
      />
    </div>
  )
}

export default Landing
