import { Blog } from '@/types/blog'
import Image from 'next/image'
import { RelatedBlogs } from '../../components/blog/RelatedBlogs'
import { BlogAuthorDetail } from '@/components/blog/BlogAuthorDetail'
import { BlogContent } from '@/components/blog/BlogContent'

interface BlogDetailProps {
  blog: Blog
}

const BlogDetail: React.FC<BlogDetailProps> = ({ blog }) => {
  return (
    <div className='bg-white text-black'>

      {/* Blog title */}
      <div className='text-3xl pt-20 flex items-center justify-center'>
        <h1 className="font-french-cannon">{blog.title}</h1>
      </div>

      {/* Tags & read time */}
      <div className='flex items-center justify-center text-xs font-extralight mt-2'>
        <div className="flex items-center gap-3 font-montserrat">
          <div>{blog.tags.join(', ')}</div>
          <div>|</div>
          <div>{blog.readTime} MIN READ</div>
        </div>
      </div>

      {/* Blog image */}
      <div className='flex items-center justify-center h-480 mt-10'>
        <Image src={blog.blogImage} alt={blog.title} width={960} height={480} />
      </div>

      {/* Author details */}
      <div className='flex items-center justify-center mt-6'>
        <BlogAuthorDetail author={blog.author} />
      </div>

      {/* Blog content */}
      <div className='flex items-center justify-center mt-8'>
        <BlogContent content={blog.content} />
      </div>

      {/* Related blogs */}
      <div className='flex items-center justify-center pb-20 font-light'>
        <RelatedBlogs blog={blog} />
      </div>

    </div>
  )
}

export default BlogDetail;
