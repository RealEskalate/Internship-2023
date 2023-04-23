import { ProblemItemList, SolutionItemList } from '@/data/about'
import Image from 'next/image'
import ProblemItemCard from './ProblemItemCard'

const ProblemSection = () => {
  return (
    <div>
      <div className="flex gap-24 justify-center items-center mt-16 flex-wrap">
        <div className="flex-initial order-2 md:order-1">
          <div className="font-bold text-center md:text-left lg:text-5xl md:text-4xl sm:text-3xl xs:text-2xl max-w-lg">
            The Problem We <span className="text-blue-500">Are Solving</span>
          </div>
          {ProblemItemList.map((Item, index) => (
            <ProblemItemCard key={index} Item={Item} />
          ))}
        </div>
        <Image
          className="p-10 order-1"
          src="/about/amicosolve.png"
          alt=""
          width={450}
          height={100}
        />
      </div>
      <div className="flex justify-center gap-24 mt-20 flex-wrap">
        <Image
          className="flex-initial p-10 order-1"
          src="/about/amicopuzzle.png"
          alt=""
          width={500}
          height={100}
        />
        <div className="flex-initial order-2">
          <div className="font-bold text-center md:text-left lg:text-5xl md:text-4xl sm:text-3xl xs:text-2xl max-w-lg">
            How We Are <span className="text-blue-500">Solving it</span>
          </div>
          {SolutionItemList.map((Item, index) => (
            <ProblemItemCard key={index} Item={Item} />
          ))}
        </div>
      </div>
    </div>
  )
}

export default ProblemSection
