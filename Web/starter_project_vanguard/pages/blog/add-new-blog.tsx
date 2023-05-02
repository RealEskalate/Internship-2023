import FileUpload from '@/components/blog/FileUpload'
import TextEditor from '@/components/blog/TextEditor'

import React, { useState } from 'react'

const addNewBlog = () => {
  const tags = [
    'Development',
    'Sports',
    'Writing',
    'Self Improvement',
    'Technology',
    'Social',
    'Datascience',
    'Programming',
  ]

  const [active, setActive] = useState('Development')
  const [content, setContent] = useState('')

  const handleContentChange = (value: string): void => {
    setContent(value)
  }

  const handleClick = (t: string): void => setActive(t)

  const ListOfTags = tags.map((tag) => (
    <button
      onClick={() => handleClick(tag)}
      className={`btn ${
        tag === active ? 'btn-active' : ''
      } font-{montserrat} text-blog btn-outline text-sm  btn-sm btn-pill`}
    >
      {tag}
    </button>
  ))

  return (
    <div className="flex flex-col lg:flex-row  pl-20 mb-36 md:mb-44 lg:mb-72 pr-6 pt-6 min-h-screen">
      <div className=" w-full lg:w-3/4  pr-10 pb-10 mr-10">
        <div>

          <form className="mb-10">
            <input
              type="search"
              id="search"
              className="block w-full  px-4 text-2xl md:text-3xl    border-l-2 outline-none border-blue-700 font-montserrat  "
              placeholder="Enter the title of the blog"
              required
            />
          </form>

        </div>

        <FileUpload />

        <TextEditor value={content} onChange={() => handleContentChange} />

        <div className="flex flex-row gap-4  mt-14 lg:mt-20  p-4 justify-end">
          <button className="btn btn-outline border-none">cancel</button>
          <button className="btn">save changes</button>
        </div>

      </div>

      <div className="w-full lg:w-1/3 pl-8 border-l-2  pr-16 lg:pr-10 gap-4">

        <h2 className="font-{montserrat} text-lg font-bold mb-5">
          Select Tag
        </h2>

        <div className="flex flex-row gap-3 w-3/4 lg:w-full flex-wrap">
          {ListOfTags}
        </div>

      </div>
 
    </div>
  )
}

export default addNewBlog
