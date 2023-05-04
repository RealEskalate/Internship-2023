import blogs from '@/data/blog/single-blog'
import { useRouter } from 'next/router'

const SingleBlog: React.FC = () => {
  const router = useRouter()
  const { id } = router.query
  const currBlog = blogs.filter((item) => item.blogId === id)
  const singleBlog = currBlog[0]
  return (
    <div className="bg-white">
      <h2 className="text-center pt-4 font-imfell font-normal text-3xl text-primary-text">
        {singleBlog.blogTitle}
      </h2>
      <p className="text-center uppercase font-montserrat font-thin tracking-widest leading-9 text-xs text-primary-text">
        {singleBlog.smallBlogTitle}
      </p>
      <div className="flex h-auto w-5/6 justify-center items-center mx-auto p-8">
        <img
          src={`/img/blog/${singleBlog.blogImgUrl}`}
          className="mx-auto"
          alt="blog image"
        />
      </div>

      <div className="mx-auto p-4">
        <img
          src={`/img/blog/${singleBlog.author.imageUrl}`}
          className="mx-auto p-4 rounded-full w-28 h-28"
        />
        <div className="">
          <p className="mx-auto text-center uppercase font-thin text-sm font-montserrat tracking-widest leading-9 text-primary-text">
            {singleBlog.author.name} | {singleBlog.author.profession}
          </p>
          <a className="text-center " href="#">
            <p className="text-center uppercase font-semibold text-sm text-primary font-montserrat tracking-widest leading-9">
              {singleBlog.author.socialMediaLink}
            </p>
          </a>
        </div>
      </div>
      <div className="mx-auto pt-8 text-left w-4/6 font-imfell font-medium text-xl text-primary-text leading-10">
        <b className="bold-text">{singleBlog.heading}</b>
        {singleBlog.paragraphs.map((text) => (
          <div className="mt-4">
            <small className="font-light font-montserrat text-base text-secondary-text">
              {text}
            </small>
          </div>
        ))}
      </div>
    </div>
  )
}

export default SingleBlog
