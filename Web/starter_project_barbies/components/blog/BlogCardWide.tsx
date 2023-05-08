import { Blog } from "@/types/blog";
import moment from "moment";
import Image from "next/image";
import { TagList } from "../common/TagList";
import Link from 'next/link';

interface BlogCardWideProps {
  blog: Blog
}

export const BlogCardWide: React.FC<BlogCardWideProps> = ({ blog }) => {
  return (
    <Link href={`blogs/${blog.blogID}`}>

      <div className="mb-6">
        {/* Horizontal divider */}
        <hr className="mx-4 h-2" />

        <div className='grid grid-cols-2' style={{ gridTemplateColumns: `70% 30%` }}>
          <div className="flex mt-6">
            <div className="flex flex-col">
              {/* Author details */}
              <BlogCardAuthorDetail blog={blog} />
              {/* Blog title */}
              <div className="mt-4 font-semibold text-xl me-40">
                {blog.title}
              </div>
              {/* Blog description */}
              <div className="mt-6 me-28 text-sm font-extralight">
                {blog.shortDescription}
              </div>
              {/* Blog tags */}
              <div className="mt-6">
                <TagList tags={blog.tags} />
              </div>
            </div>
          </div>
          {/* Blog image */}
          <div className='flex items-center justify-center'>
            <Image className="rounded-lg" src={blog.blogImage} alt={blog.title} width={300} height={180} />
          </div>
        </div>
      </div>
      
    </Link>
  )
}

const BlogCardAuthorDetail: React.FC<BlogCardWideProps> = ({ blog }) => {
  return (
    <div className='grid grid-cols-2' style={{ gridTemplateColumns: `60px auto` }}>

      {/* Author image */}
      <Image src={blog.author.image} alt={blog.author.name} width={50} height={50} className="rounded-full" />
      
      <div className='flex flex-col justify-center ms-2'>
        <div className="flex justify-start">
          {/* Author name and blog date */}
          <div className="flex gap-2 justify-center items-center">
            <div className="font-medium" style={{ fontSize: `15px` }}>
              {blog.author.name}
            </div>
            <div>●</div>
            <div className="flex items-center">
              <div className="text-xs font-extralight text-secondary-text" style={{ fontSize: `10px` }}>
                {formatDate(blog.date)}
              </div>
            </div>
          </div>
        </div>
        {/* Author profession */}
        <div className="text-xs mt-1 text-secondary-text" style={{ fontSize: `10px` }}>
          {blog.author.profession.toUpperCase()}
        </div>
      </div>
      
    </div>
  )
}

const formatDate = (dateString: string): string => {
  const date = moment(dateString);
  return date.format('MMM DD, YYYY');
}
