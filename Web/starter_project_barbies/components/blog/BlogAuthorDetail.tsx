import { Blog } from "@/types/blog"
import Image from 'next/image'

interface BlogAuthorDetailProps {
  author: Blog['author']
}

export const BlogAuthorDetail: React.FC<BlogAuthorDetailProps> = ({ author: {name, image, profession, userName} }) => {
  return (
    <div className='text-xs font-extralight font-montserrat'>

      {/* Author image */}
      <div className="flex items-center justify-center">
        <Image src={image} alt={name} width={38} height={38} className="rounded-full" />
      </div>

      {/* Author name & profession */}
      <div className='grid grid-cols-3 mt-2' style={{ gridTemplateColumns: `400px 20px 400px` }}>
        <div className='text-end'>{name.toUpperCase()}</div>
        <div className='text-center'>|</div>
        <div>{profession.toUpperCase()}</div>
      </div>

      {/* Author username */}
      <div className='flex items-center justify-center text-blue-500 font-medium mt-1'>
        <div className='text-blue'>{userName.toUpperCase()}</div>
      </div>

    </div>
  )
}