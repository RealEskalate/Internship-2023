import 'tailwindcss/base.css'
import Image from 'next/image'
import { Blog } from '../../types/blog/blog'
import Link from 'next/link'
import { Tags } from '../common/Tags'

interface BlogProps {
  blog: Blog
}

const BlogsCard: React.FC<BlogProps> = ({
  blog: {
    authorPhoto,
    authorName,
    img,
    descriptionTitle,
    skills,
    date,
    title,
    profession,
  },
}) => {
  return (
    <div className="flex flex-wrap justify-center w-6/5">
      <div className="flex border-t-2 w-3/4 border-gray-300 pl-10">
        <div className="items-start w-3/5 pt-4 pb-4 pr-0">
          <div className="flex items-start">
            <div className="items-start my-4 mx-0">
              <div>
                <Image
                  src={authorPhoto}
                  alt={''}
                  width={50}
                  height={50}
                  className={`rounded-full object-cover`}
                />
              </div>
            </div>
            <div className="self-center mx-3">
              <div className="flex flex-col justify-center">
                <span className="text-sm text-black font-semibold block">
                  {authorName}
                </span>
                <span className="text-sm text-gray-500 flex font-medium">
                  {profession.toUpperCase()}
                </span>
              </div>
            </div>
            <div className="items-end self-center mx-5">
              <span className="text-sm text-black font-light">{date}</span>
            </div>
          </div>

          <div className="flex flex-wrap">
            <div>
              <div>
                <span className="text-2xl font-bold">{title}</span>
              </div>
            </div>
            <div>
              {' '}
              <div className="pt-4 w-2/3">
                <span className="text-gray-500 font-light text-lg">
                  {descriptionTitle}
                </span>
              </div>
            </div>
          </div>
          <div className="justify-start items-end">
            <Tags tags={skills} />
          </div>
        </div>

        <div className="flex justify-center items-center w-1/4 pl-0">
          <Link href={""} passHref>
            <Image
              src={img}
              className={`object-cover rounded`}
              alt={''}
              width={350}
              height={350}
            />
          </Link>
        </div>
      </div>
    </div>
  )
}

export default BlogsCard
