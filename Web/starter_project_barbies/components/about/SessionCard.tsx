import { SessionProps } from '@/types/AboutTypes'
import Image from 'next/image'

const SessionCard = ({ session }: SessionProps) => {
  return (
    <div className="rounded-lg border-gray-200 border-2 px-10 py-5">
      <Image
        className="my-5"
        src={session.image}
        width={50}
        height={50}
        alt=""
      />
      <div className="font-bold my-2">{session.session}</div>
      <div>{session.description}</div>
    </div>
  )
}

export default SessionCard
