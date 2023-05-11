import { BlogAuthorDetail } from '@/components/blog/BlogAuthorDetail'
import { BlogContent } from '@/components/blog/BlogContent'
import { RelatedBlogs } from '@/components/blog/RelatedBlogs'
import { useGetBlogByIDQuery } from '@/store/features/blogs-api'
import { useRouter } from 'next/router'
import Image from 'next/image'

const BlogDetail = () => {
  const router = useRouter()
  const blogID = router.query.id as string

  const result = useGetBlogByIDQuery(blogID)

  if (result.isLoading) {
    return <div>loading...</div>
  }
  
  else if (result.isError) {
    return <div>{result.error.toString()}</div>
  }
  
  else if (result.isSuccess) {
    let blog = result.data

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
          <RelatedBlogs blogs={blog.relatedBlogs} />
        </div>

      </div>
    )
  }
}

export default BlogDetail;
