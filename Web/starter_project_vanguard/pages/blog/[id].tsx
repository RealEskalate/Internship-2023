import Image from 'next/image'
import { Blog } from '@/types/blog/blog'
import { useRouter } from 'next/router'
import RelatedBlogCard from '@/components/blog/RelatedBlog'
import { useGetSingleBlogQuery } from '@/store/features/blog/single-blog-api'

const SingleBlog:React.FC = () => {
  const router = useRouter()
  let { id } = router.query
  id = id as string
  
  const {data:blog,isLoading} = useGetSingleBlogQuery(id)
  if (isLoading){
    return <div> loading ... </div>
  }
  if (!blog) {
    return <div>Blog not found</div>;
  }
  
  
  
  return (
    <div className="w-3/4 m-auto">
      <div className="text-center mt-10 flex-col">
        <h1 className="text-4xl font-bold font-poppins">
          {blog.title}
        </h1>

        <p className="mt-4 tracking-widest font-montserrat uppercase">
          {blog.tags} | {blog.time} MIN READ
        </p>

        <Image
          className="mt-10 w-full h-96 object-cover ml-auto mr-auto"
          src={blog.img}
          width={400}
          height={100}
          alt="hello"
        />
      </div>

      <div className="card text-center mt-10">
        <Image
          className="w-16 h-16 bg-orange-100 m-auto object-cover rounded-full "
          src={blog.authorPhoto}
          width={200}
          height={200}
          alt="card"
        />
        <div className="font-montserrat mt-5">
          <h4 className="font-montserrat uppercase">
            {blog.authorName} | {blog.profession}
          </h4>
          <h6 className="text-blue-500 font-montserrat uppercase">
            @{blog.authorUserName}
          </h6>
        </div>
      </div>

      <div className="blog text-center m-4 md:m-16 mt-10  ">
        <h2 className="m-auto text-2xl mb-8 text-left font-poppins">
          {blog.descriptionTitle}
        </h2>

        <div className="font-montserrat text-sm text-gray-400 flex  flex-col gap-5 ">
          <p className="text-left">
            {blog.description} 
          </p>
        </div> 
      </div>

      <div>
        <h1 className="text-left pt-16 text-bold text-3xl font-bold">
            Related Blogs
        </h1>

        <div className="grid grid-cols-1 gap-10 mt-10 mb-14 md:grid-cols-3">
          {blog.relatedBlogs.map((item: string) => (
            <RelatedBlogCard key = "item" id={item} />
          ))}
        </div>

      </div>
    </div>
  )
}

export default SingleBlog
