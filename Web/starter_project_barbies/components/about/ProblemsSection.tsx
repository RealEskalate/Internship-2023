import problemItemList from '../../data/about/problem-items.json'
import solutionItemList from '../../data/about/solution-items.json'

import { ProblemItem } from '@/types/about'
import Image from 'next/image'

interface ProblemItemCardProps {
  Item: ProblemItem
}

const ProblemItemCard: React.FC<ProblemItemCardProps> = ({ Item:{icon, description} }) => {
  return (
    <div className="p-3">
      <Image className='my-5' src={`/img/about/problems/${icon}`} width={50} height={50} alt='' />
      <div className="max-w-md text-gray-400">{description}</div>
    </div>
  )
}

const ProblemsSection:React.FC = () => {
  return (
    <div>
      <div className="flex gap-24 justify-center items-center mt-16 flex-wrap">
        <div className="flex-initial order-2 md:order-1">
          <div className="font-bold text-center md:text-left lg:text-5xl md:text-4xl sm:text-3xl xs:text-2xl max-w-lg">
            The Problem We <span className="text-primary">Are Solving</span>
          </div>
          {problemItemList.map((Item, index) => (
            <ProblemItemCard key={index} Item={Item} />
          ))}
        </div>
        <Image
          className="p-10 order-1"
          src="/img/about/problems/amico-solve.png"
          alt=""
          width={450}
          height={100}
        />
      </div>
      <div className="flex justify-center gap-24 mt-20 flex-wrap">
        <Image
          className="flex-initial p-10 order-1"
          src="/img/about/problems/amico-puzzle.png"
          alt=""
          width={500}
          height={100}
        />
        <div className="flex-initial order-2">
          <div className="font-bold text-center md:text-left lg:text-5xl md:text-4xl sm:text-3xl xs:text-2xl max-w-lg">
            How We Are <span className="text-primary">Solving it</span>
          </div>
          {solutionItemList.map((Item, index) => (
            <ProblemItemCard key={index} Item={Item} />
          ))}
        </div>
      </div>
    </div>
  )
}

export default ProblemsSection
