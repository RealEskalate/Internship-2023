import Image from 'next/image'
import { BsChatDots } from 'react-icons/bs'

const BuildBetter: React.FC = () => {
  return (
    <div className="flex flex-col items-center justify-center p-16 gap-10">
      <h2 className="text-5xl font-semibold max-w-lg text-center capitalize leading-normal">
        Lets Build a Better Tomorrow
      </h2>
      <p className="text-secondary-text text-2xl text-center">
        A2SV upskills high-potential university students, connects them with
        opportunities at top tech companies around the world, and creates
        digital solutions to urgent problems in their home countries. The
        program is free for students, making the opportunity available for youth
        who have talent but lack the means to use it.
      </p>

      <button className="flex flex-row items-center justify-center font-medium text-2xl rounded px-8 py-3 bg-primary text-blue-100 hover:bg-blue-600 duration-300 gap-3">
        <BsChatDots size={25} /> Connect to our team
      </button>

      <div className="w-full px-[2vw]">
        <Image
          src="/img/home/better-tomorrow.jpg"
          alt="better tomorrow image"
          className="w-full"
          width={1000}
          height={1000}
        />
      </div>
    </div>
  )
}

export default BuildBetter
