import { Pagination } from "@/components/common/Pagination";
import { Blog } from "@/types/blog";
import moment from "moment";
import Image from "next/image";
import React from "react";
import { AiOutlinePlus } from 'react-icons/ai';

interface BlogsScreenProps {
  blogs: Blog[]
}

export const BlogsScreen: React.FC<BlogsScreenProps> = ({ blogs }) => {
  return (
    <div className='bg-white text-black font-montserrat'>

      <div className="flex justify-center pt-20">
        <div className='grid grid-cols-3 mt-2 w-full'>

          <div className="flex items-center">
            <div className='ps-28 text-xl font-black'>
              Blogs
            </div>
          </div>
          <div className='flex justify-center'>
            <SearchForm />
          </div>
          <div />

        </div>
      </div>

      <div className="mt-10 px-56">
        <BlogsList blogs={blogs} />
      </div>

      <Pagination numberOfPages={5} />

    </div>
  )
}

const BlogsList: React.FC<BlogsScreenProps> = ({ blogs }) => {
  let blogComponents = []
  let key = 0
  for (let i of blogs) {
    blogComponents.push(<BlogCardWide blog={i} key={key++} />)
  }

  return (
    <div className='bg-white text-black'>
      {blogComponents}
    </div>
  )
}

interface BlogCardWideProps {
  blog: Blog
}

const BlogCardWide: React.FC<BlogCardWideProps> = ({ blog }) => {
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

const SearchForm = () => {
  return (
    <form className="flex gap-4">
      <input type="text" className="border border-gray-300 text-gray-900 text-sm rounded-full block px-8 py-2.5 w-60" placeholder="Search..." />
      <button type="submit" className="text-white bg-blue-600 font-black rounded-full text-sm px-5 py-2.5 text-center">
        <AiOutlinePlus className="inline-block me-1" /> New Blog
      </button>
    </form>
  )
}

interface TagListProps {
  tags: Blog['tags']
}

const TagList: React.FC<TagListProps> = ({ tags }) => {
  let tagComponents = []
  for (let tag of tags) {
    tagComponents.push(<Tag tag={tag} />)
  }

  return (
    <div className="flex gap-2">
      {tagComponents}
    </div>
  )
}

interface TagProps {
  tag: string
}

const Tag: React.FC<TagProps> = ({ tag }) => {
  return (
    <div className="text-xs font-extralight bg-gray-100 rounded-full px-8 py-2">
      {tag}
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