import Image from 'next/image'
import { FiMessageSquare } from 'react-icons/fi'
import { TbClockFilled } from 'react-icons/tb'
import { Blog } from '../../types/blog/blog'
interface Props {
  blog: Blog
}

const BlogCard: React.FC<Props> = ({ blog }) => {
  const numberFormater = (num: number) => {
    if (num >= 1e6) return +(num / 1e6).toFixed(1) + 'm'
    if (num >= 1e3) return +(num / 1e3).toFixed(1) + 'k'
    if (num < 1e3) return num
  }

  return (
    <div className="max-w-sm rounded-sm shadow hover:shadow-lg">
      <Image
        className="rounded object-cover h-52 w-full"
        width={400}
        height={400}
        src={blog.img}
        alt={blog.title}
      />

      <div className="p-4">
        <h5 className="mb-4 text-primary-text text-sm font-semibold">
          {blog.title}
        </h5>
        <div className="flex space-x-2 text-gray-400 items-center text-[0.6rem] mb-4">
          <Image
            className="rounded-full object-cover h-5 w-5 items-center"
            width={10}
            height={10}
            src={blog.img}
            alt={blog.title}
          />
          <p>by</p>
          <p className="font-semibold text-primary-text">{blog.authorName} </p>
          <p>
            <span className="pr-2">|</span>
            {blog.date}
          </p>
        </div>

        <div className="flex flex-row space-x-2 my-3">
          {blog.skills.map((skill, index) => {
            return (
              <div
                key={index}
                className="rounded-full bg-neutral-100 uppercase text-[0.6rem] font-semibold text-secondary-text py-1 px-3"
              >
                {skill}
              </div>
            )
          })}
        </div>
        <p className="my-5 text-xs text-secondary-text ">
          {blog.description.slice(0, 85)}
        </p>
        <div className="flex justify-between border-t pt-4">
          {blog.isPending ? (
            <div className="flex space-x-1 font-semibold text-orange-400 items-center text-xs">
              <TbClockFilled /> <p>Pending</p>
            </div>
          ) : (
            <div className="flex space-x-2 items-center text-secondary-text">
              <FiMessageSquare />

              <p className="text-xs text-primary-text font-semibold">
                {numberFormater(blog.likes)} Likes
              </p>
            </div>
          )}
          <button
            className="text-indigo-700 text-xs font-semibold"
            onClick={() => null}
          >
            Read More
          </button>
        </div>
      </div>
    </div>
  )
}

export default BlogCard
