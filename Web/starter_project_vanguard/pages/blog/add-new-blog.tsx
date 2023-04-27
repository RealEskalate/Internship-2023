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
    <div className="flex pl-20 mb-24 pr-6 pt-6 h-screen">
      <div className="w-3/4  pr-10 pb-10 mr-10">
        <div>

          <form className="mb-10">
            <input
              type="search"
              id="search"
              className="block w-full  px-4 text-3xl text-title   border-l-2 outline-none border-blue-700 font-montserrat  "
              placeholder="Enter the title of the blog"
              required
            />
          </form>

        </div>

        <FileUpload />

        <TextEditor value={content} onChange={() => handleContentChange} />

        <div className="flex flex-row gap-4  mt-10  p-4 justify-end">
          <button className="btn btn-outline border-none">cancel</button>
          <button className="btn">save changes</button>
        </div>

      </div>

      <div className="w-1/3 pl-8 border-l-2  pr-10 gap-4">
        
        <h2 className="font-{montserrat} text-lg font-bold mb-5">
          Select Tag
        </h2>

        <div className="flex flex-row gap-3 flex-wrap ">
          {ListOfTags}
        </div>

      </div>

    </div>
  )
}

export default addNewBlog
