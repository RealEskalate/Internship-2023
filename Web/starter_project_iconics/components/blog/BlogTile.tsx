import { BlogData } from '@/types/blog/blog'
import Image from 'next/image'
import { GoPrimitiveDot } from 'react-icons/go'

const BlogTile = ({
  name,
  profession,
  profileImg,
  datePosted,
  title,
  description,
  blogImg,
  tags,
}: BlogData) => {
  return (
    <div className="flex flex-col mx-10 md:mx-30 2xl:mx-72 gap-y-4 my-6">
      {/* profile related */}
      <div className="flex gap-x-2 items-center">
        <div className="rounded-full">
          <Image
            src={profileImg}
            alt="blog poster profile"
            width={90}
            height={90}
            className="inline object-cover self-center w-16 h-16 mr-2 rounded-full"
          />
        </div>
        <div>
          <div className="flex gap-4">
            <h1 className="font-bold">{name}</h1>
            <GoPrimitiveDot className="text-sm self-center" />
            <span className="text-secondary-text text-xs self-center">
              {datePosted}
            </span>
          </div>
          <h2 className="text-secondary-text text-sm">{profession}</h2>
        </div>
      </div>
      {/* blog title and descriptions */}
      <div className="flex flex-col lg:flex-row gap-x-12 items-center gap-y-4">
        <div className="flex flex-col gap-4">
          <h1 className="font-extrabold text-xl lg:text-3xl">{title}</h1>
          <p className="text-secondary-text lg:text-lg">{description}</p>
        </div>
        <div className="w-full lg:w-auto">
          <Image
            src={blogImg}
            alt="blog image"
            width={450}
            height={300}
            className="rounded-sm m-auto"
          />
        </div>
      </div>
      {/* tags */}
      <div className="flex gap-x-6">
        {tags.map((name, index) => (
          <div key={index} className="bg-gray-200 py-2 px-4 rounded-full">
            {name}
          </div>
        ))}
      </div>
    </div>
  )
}

export default BlogTile
