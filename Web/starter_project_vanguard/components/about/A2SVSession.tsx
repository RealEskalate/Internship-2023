import { SessionComponent } from '@/types/about/session-component'
import Image from 'next/image'

const A2SVSession: React.FC<SessionComponent> = ({
  image,
  title,
  content,
}: SessionComponent) => {
  return (
    <div className="shadow-lg rounded p-5 m-3">
      <Image src={image} className="w-[60px]" alt={title}></Image>
      <p className="font-bold my-3 text-2xl">{title}</p>
      <p>{content}</p>
    </div>
  )
}

export default A2SVSession