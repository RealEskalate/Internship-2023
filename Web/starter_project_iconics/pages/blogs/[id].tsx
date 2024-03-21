import { Blog } from '@/types/blog'
import Image from 'next/image'
import { useRouter } from 'next/router'
import React from 'react'
import blogsData from '../../data/blogs/blogs.json'

const SingleBlog: React.FC = () => {
  const router = useRouter()
  const { id } = router.query
  const blogList = JSON.parse(JSON.stringify(blogsData))
  const currBlog: Blog[] = blogList.filter((item: Blog) => {
    // TODO
    // This Will be fixed on another PR
    return item.id === '1'
  })
  const { title, smallBlogTitle, imgUrl, heading, author, paragraph } =
    currBlog[0]

  if (currBlog[0] == null) {
    return (
      <div>
        <h1>Not Found</h1>
      </div>
    )
  }

  return (
    <div className="bg-white">
      <h2 className="text-center pt-4 font-imfell font-normal text-3xl text-primary-text">
        {title}
      </h2>
      <p className="text-center uppercase font-montserrat font-thin tracking-widest leading-9 text-xs text-primary-text">
        {smallBlogTitle}
      </p>
      <div className="flex h-auto w-5/6 justify-center items-center mx-auto p-8">
        <Image
          src={`/img/blogs/${imgUrl}`}
          className="mx-auto"
          alt="blog image"
          width={1000}
          height={450}
        />
      </div>

      <div className="mx-auto p-4">
        <Image
          src={`/img/blogs/${author.imageUrl}`}
          className="mx-auto p-4 rounded-full w-28 h-28"
          alt="author image"
          width={100}
          height={100}
        />
        <div className="">
          <p className="mx-auto text-center uppercase font-thin text-sm font-montserrat tracking-widest leading-9 text-primary-text">
            {author.name} | {author.profession}
          </p>
          <a className="text-center " href="#">
            <p className="text-center uppercase font-semibold text-sm text-primary font-montserrat tracking-widest leading-9">
              {author.socialMediaLink}
            </p>
          </a>
        </div>
      </div>
      <div className="mx-auto pt-8 text-left w-4/6 font-imfell font-medium text-xl text-primary-text leading-10">
        <b className="bold-text">{heading}</b>
        <div className="mt-4">
          <small className="font-light font-montserrat text-base text-secondary-text">
            <div
              className="content"
              dangerouslySetInnerHTML={{ __html: paragraph }}
            ></div>
          </small>
        </div>
      </div>
    </div>
  )
}

export default SingleBlog
