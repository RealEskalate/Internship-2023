import { BlogAuthorDetail } from '@/components/blog/BlogAuthorDetail'
import { BlogContent } from '@/components/blog/BlogContent'
import { RelatedBlogs } from '@/components/blog/RelatedBlogs'
import { LoadingSpinner } from '@/components/common/LoadingSpinner'
import { useGetBlogByIDQuery } from '@/store/blog/blogs-api'
import { useRouter } from 'next/router'
import Image from 'next/image'

const BlogDetail = () => {
  const router = useRouter()
  const blogID = router.query.id as string

  const blogDetailResult = useGetBlogByIDQuery(blogID)

  if (blogDetailResult.isLoading) {
    return <div> <LoadingSpinner /> </div>
  }
  
  if (blogDetailResult.isError) {
    return <div>{blogDetailResult.error.toString()}</div>
  }
  
  if (blogDetailResult.isSuccess) {
    const { title, tags, readTime, blogImage, content, author, relatedBlogs } = blogDetailResult.data

    return (
      <div className='bg-white text-black'>

        {/* Blog title */}
        <div className='text-3xl pt-20 flex items-center justify-center'>
          <h1 className="font-french-cannon">{title}</h1>
        </div>

        {/* Tags & read time */}
        <div className='flex items-center justify-center text-xs font-extralight mt-2'>
          <div className="flex items-center gap-3 font-montserrat">
            <div>{tags.join(', ')}</div>
            <div>|</div>
            <div>{readTime} MIN READ</div>
          </div>
        </div>

        {/* Blog image */}
        <div className='flex items-center justify-center h-480 mt-10'>
          <Image src={blogImage} alt={title} width={960} height={480} />
        </div>

        {/* Author details */}
        <div className='flex items-center justify-center mt-6'>
          <BlogAuthorDetail author={author} />
        </div>

        {/* Blog content */}
        <div className='flex items-center justify-center mt-8'>
          <BlogContent content={content} />
        </div>

        {/* Related blogs */}
        <div className='flex items-center justify-center pb-20 font-light'>
          <RelatedBlogs relatedBlogs={relatedBlogs} />
        </div>

      </div>
    )
  }
}

export default BlogDetail;
