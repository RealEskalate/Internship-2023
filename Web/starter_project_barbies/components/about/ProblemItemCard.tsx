import { ProblemItemProps } from '@/types/AboutTypes'
import Image from 'next/image'

const ProblemItemCard = ({ Item }: ProblemItemProps) => {
  return (
    <div className="p-3">
      <Image className="my-5" src={Item.icon} width={50} height={50} alt="" />
      <div className="max-w-md text-gray-400">{Item.description}</div>
    </div>
  )
}

export default ProblemItemCard
