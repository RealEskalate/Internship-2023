import BlogCard from '@/components/blog/BlogCard'
import { Blog } from '@/types/blog'
import Image from 'next/image'

interface BlogDetailProps {
  blog: Blog
}

interface BlogAuthorDetailProps {
  author: {
    name: string
    email: string
    image: string
    profession: string
    userName: string
  }
}

interface BlogContentProps {
  content: string
}

interface RelatedBlogsProps {
  blog: Blog
}

export const BlogDetail: React.FC<BlogDetailProps> = ({ blog }) => {
  return (
    <div className='bg-white text-black'>

      {/* Blog title */}
      <div className='text-2xl pt-20 flex items-center justify-center'>
        <h1>{blog.title}</h1>
      </div>

      {/* Tags & read time */}
      <div className='flex items-center justify-center text-xs font-extralight mt-2'>
        <div className="flex items-center gap-3">
          <div className='text-black'>{blog.tags.join(', ')}</div>
          <div className='text-black'>|</div>
          <div className='text-black'>{blog.readTime} MIN READ</div>
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
      <div className='flex items-center justify-center pb-20'>
        <RelatedBlogs blog={blog} />
      </div>

    </div>
  )
}

const BlogAuthorDetail: React.FC<BlogAuthorDetailProps> = ({ author }) => {
  return (
    <div className='text-xs font-extralight'>

      {/* Author image */}
      <div className="flex items-center justify-center">
        <Image src={author.image} alt={author.name} width={38} height={38} className="rounded-full" />
      </div>

      {/* Author name & profession */}
      <div className='grid grid-cols-3 mt-2' style={{ gridTemplateColumns: `400px 20px 400px` }}>
        <div className='text-end'>{author.name.toUpperCase()}</div>
        <div className='text-center'>|</div>
        <div>{author.profession.toUpperCase()}</div>
      </div>

      {/* Author username */}
      <div className='flex items-center justify-center text-blue-500 font-medium mt-1'>
        <p className='text-blue'>{author.userName.toUpperCase()}</p>
      </div>

    </div>
  )
}

const BlogContent: React.FC<BlogContentProps> = ({ content }) => {
  let paragraphs = []
  let key = 0
  for (let line of content.split('\n')) {
    let paragraph = <p key={key++} className={`${'mt-6 ' + ((key == 1) ? 'text-xl' : 'text-base font-thin')}`}>
      {line}
    </p>
    paragraphs.push(paragraph)
  }

  return (
    <div className='mx-96'>
      {paragraphs}
    </div>
  )
}

const RelatedBlogs: React.FC<RelatedBlogsProps> = ({ blog }) => {
  // Fetch related blogs
  let relatedBlogs: Blog[] = new Array(3).fill(blog);

  let blogs = []
  for (let blog of relatedBlogs) {
    blogs.push(BlogCard({ blog }))
  }

  return (
    <div className='bg-white text-black'>

      {/* Title */}
      <div className='text-lg pt-20 flex items-start'>
        <h1>Related Blogs</h1>
      </div>

      {/* Blogs */}
      <div className='flex items-center gap-8 justify-center mt-6 text-sm'>
        {blogs}
      </div>

    </div>
  )
}
