import 'tailwindcss/base.css'
import React, { FC, useState } from 'react'
import Avatar from '../common/Avatar'
import 'typeface-montserrat'
import Image from 'next/image'
import { Blog } from '../../types/blog/blog'
import Link from 'next/link'

type MyTagProps = {
  tags: string[]
}

const Tags: FC<MyTagProps> = ({ tags }) => {
  return (
    <div className="flex flex-wrap justify-start items-end">
      {tags.map((tag, index) => (
        <button
          key={index}
          className="btn btn-outline btn-pill flex mr-2 mb-2 mx-4 mt-5 px-4 py-2 "
        >
          <i>
            <span className="text-lg font-semibold font-montserrat text-gray-500">{tag}</span>
          </i>
        </button>
      ))}
    </div>
  )
}

interface Props {
  blog: Blog
}

function BlogsCard(props: Props) {
  const encodedId = encodeURIComponent(props.blog._id)
  return (
    <div className=" flex flex-wrap justify-center w-6/5 ">
      <div className="flex border-t-2  w-3/4 border-gray-300 pl-10">
        <div className=" items-start w-3/5 pt-4 pb-4 pr-0">
          <div className="flex items-start">
            <div className="items-start my-4 mx-0">
              <div>
                <Avatar src={props.blog.authorPhoto} alt="Avatar" size="md" />
              </div>
            </div>
            <div className="self-center mx-3">
              <div className=" flex flex-col justify-center">
                <span className="text-sm font-montserrat text-black font-semibold block">
                  {props.blog.authorName}
                </span>
                <span className="text-sm font-montserrat text-gray-500 flex font-medium">
                  {props.blog.profession.toUpperCase()}
                </span>
              </div>
            </div>
            <div className="items-end self-center mx-5">
              <span className="text-sm font-montserrat text-black font-light">
                {props.blog.date}
              </span>
            </div>
          </div>

          <div className="flex flex-wrap">
            <div>
              <div>
                <span className="text-2xl font-bold font-montserrat">
                  {props.blog.title}
                </span>
              </div>
            </div>
            <div>
              {' '}
              <div className="pt-4 w-2/3">
                <span className="text-gray-500 font-light text-lg font-montserrat">
                  {props.blog.descriptionTitle}
                </span>
              </div>
            </div>
          </div>
          <div className="justify-start items-end">
            <Tags tags={props.blog.skills} />
          </div>
        </div>

        <div className="flex justify-center items-center w-1/4 pl-0 ">
          <Link href={`./single-blog?id=${encodedId}`} passHref>
            <Image
              src={props.blog.img}
              className={`object-cover rounded`}
              alt={''}
              width={350}
              height={350}
            />
          </Link>
        </div>
      </div>
    </div>
  )
}

export default BlogsCard
