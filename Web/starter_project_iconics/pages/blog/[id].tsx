import Image from 'next/image'
import { useRouter } from 'next/router'
import React from 'react'
import blogs from '../../data/blog/blog-detail'
import BlogDetail from '../../types/blog/blog-detail'

interface Props {
  id: string
}
const SingleBlog: React.FC<Props> = () => {
  const router = useRouter()
  const { id } = router.query
  const blog: BlogDetail[] = blogs
  const currBlog = blog.filter((item) => item.blogId === id)
  const blogDetail: BlogDetail = currBlog[0]
  return (
    <div className="bg-white">
      <h2 className="text-center pt-4 font-imfell font-normal text-3xl text-primary-text">
        {blogDetail && blogDetail.blogTitle}
      </h2>
      <p className="text-center uppercase font-montserrat font-thin tracking-widest leading-9 text-xs text-primary-text">
        {blogDetail && blogDetail.smallBlogTitle}
      </p>
      <div className="flex h-auto w-5/6 justify-center items-center mx-auto p-8">
        <Image
          src={`/img/blog/${blogDetail && blogDetail.blogImgUrl}`}
          className="mx-auto"
          alt="blog image"
          width={800}
          height={450}
        />
      </div>

      <div className="mx-auto p-4">
        <Image
          src={`/img/blog/${blogDetail && blogDetail.author.imageUrl}`}
          className="mx-auto p-4 rounded-full w-28 h-28"
          alt="author image"
          width={100}
          height={100}
        />
        <div className="">
          <p className="mx-auto text-center uppercase font-thin text-sm font-montserrat tracking-widest leading-9 text-primary-text">
            {blogDetail && blogDetail.author.name} |{' '}
            {blogDetail && blogDetail.author.profession}
          </p>
          <a className="text-center " href="#">
            <p className="text-center uppercase font-semibold text-sm text-primary font-montserrat tracking-widest leading-9">
              {blogDetail && blogDetail.author.socialMediaLink}
            </p>
          </a>
        </div>
      </div>
      <div className="mx-auto pt-8 text-left w-4/6 font-imfell font-medium text-xl text-primary-text leading-10">
        <b className="bold-text">{blogDetail && blogDetail.heading}</b>
        {blogDetail &&
          blogDetail.paragraphs.map((text, index) => (
            <div className="mt-4" key={index}>
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
