import { Blog } from "@/types/blog";
import moment from "moment";
import Image from "next/image";
import { TagList } from "../common/TagList";

interface BlogCardWideProps {
  blog: Blog
}

export const BlogCardWide: React.FC<BlogCardWideProps> = ({ blog }) => {
  return (
    <div className="mb-6">

      <HorizontalDivider />

      <div className='grid grid-cols-2' style={{ gridTemplateColumns: `70% 30%` }}>

        <div className="flex mt-6">
          <div className="flex flex-col">
            <BlogCardAuthorDetail blog={blog} />
            <div className="mt-4 font-black	text-xl me-40">
              {blog.title}
            </div>
            <div className="mt-6 me-28 text-sm font-extralight">
              {blog.shortDescription}
            </div>
            <div className="mt-6">
              <TagList tags={blog.tags} />
            </div>
          </div>
        </div>

        <div className='flex items-center justify-center'>
          <Image className="rounded-lg" src={blog.blogImage} alt={blog.title} width={300} height={180} />
        </div>
        
      </div>

    </div>
  )
}

const BlogCardAuthorDetail: React.FC<BlogCardWideProps> = ({ blog }) => {
  return (
    <div className='grid grid-cols-2' style={{ gridTemplateColumns: `60px auto` }}>
      <Image src={blog.author.image} alt={blog.author.name} width={50} height={50} className="rounded-full" />
      <div className='flex flex-col justify-center ms-2'>
        <div className="flex justify-start">
          <div className="flex gap-2 justify-center">
            <div className="font-black">
              {blog.author.name}
            </div>
            <div>●</div>
            <div className="flex items-center">
              <div className="text-xs font-extralight">
                {formatDate(blog.date)}
              </div>
            </div>
          </div>
        </div>
        <div className="text-xs mt-1 font-extralight">
          {blog.author.profession.toUpperCase()}
        </div>
      </div>
    </div>
  )
}

const HorizontalDivider = () => (
  <hr className="mx-4 h-2" />
)

const formatDate = (dateString: string): string => {
  const date = moment(dateString);
  return date.format('MMM DD, YYYY');
}
