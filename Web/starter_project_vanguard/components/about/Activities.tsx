import ImageTextStack from '@/components/about/ImageTextStack'
import Image from 'next/image'
import developmentImage from '../../public/aboutus/development_phase.svg'
import educationImage from '../../public/aboutus/education_process.svg'
import growthRateImage from '../../public/aboutus/growth_rate.svg'

function Activities({ studentGrowthRate, learningRate, growthRate }: any) {
  return (
    <div className="bg-[#FDFEFF] p-7 rounded-lg">
      <div className="grid grid-cols-2 gap-4 bg-[#FDFEFF] text-size">
        <p className="col-span-2 font-semibold bg-[#FDFEFF]">
          Group Activities
        </p>
        <ImageTextStack
          image={educationImage}
          title={'The Education Process'}
        />
        <ImageTextStack
          image={developmentImage}
          title={'The Development Phase'}
        />
        <div className="relative overflow-hidden rounded-lg shadow-lg cursor-pointer col-span-2">
          <Image
            className="object-cover w-full h-48"
            src={growthRateImage}
            alt={''}
          ></Image>
          <div className="absolute top-0 left-0 px-6 py-4 text-white w-[100%] text-right">
            <h4 className="pt-6 text-xl font-semibold">
              {growthRate}% Growth Rate
            </h4>
            <div className="font-light mt-5">
              <p>{studentGrowthRate}% Student Growth Rate</p>
              <p>{learningRate}% Fast Learning Track</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Activities
