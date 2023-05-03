import Image from 'next/image'
import React, { useState } from 'react'
import ReactQuill from 'react-quill'
import 'react-quill/dist/quill.snow.css' // import the stylesheet

interface CustomIcons {
  [key: string]: string
}

const AddBlog: React.FC = () => {
  const [content, setContent] = useState('')

  const handleChange = (value: string) => {
    setContent(value)
  }

  const editorModules = {
    toolbar: [
      ['bold', 'italic', 'underline'],
      [{ list: 'ordered' }, { list: 'bullet' }],
      ['link'],
      ['video', 'image', 'file'],
    ],
  }

  const customIcons: CustomIcons = {
    link: '<i class="fas fa-link"></i>',
    image: '<i class="fas fa-image"></i>',
    video: '<i class="fas fa-video"></i>',
    file: '<i class="fas fa-file"></i>',
  }

  const toolbarOptions = editorModules.toolbar.map((group) =>
    group.map((button: any) => {
      if (typeof button !== 'object' || !('value' in button)) {
        return button
      }
      const customIcon = customIcons[button.value]
      return {
        ...button,
        icon: customIcon !== undefined ? customIcon : button.icon,
      }
    })
  )

  return (
    <div className="grid grid-cols-4 gap-8 bg-white">
      <div className="mx-auto w-5/6 col-span-3">
        <div className="mx-auto">
          <input
            type="text"
            className="border-l-2 border-indigo-400 text-primary-text text-3xl p-2 leading-normal mt-8 focus:outline-0 font-imfell"
            placeholder="Enter the title of the blog"
            required
          />
        </div>
        <div className="bg-gray-100 mt-8">
          <Image
            src="/img/blog/upload-img.png"
            alt=""
            className="mx-auto pt-24 pb-8"
            width={300}
            height={300}
          />
          <div className="text-center p-12 font-montserrat text-primary-text">
            <p>
              please, &nbsp;{' '}
              <button className="bg-white hover:bg-gray-50 text-secondary-text py-2 px-4 border-gray-400 rounded shadow">
                Upload File
              </button>{' '}
              &nbsp; or choose file from &nbsp;{' '}
              <button className="bg-white hover:bg-gray-50 text-secondary-text  py-2 px-4 border-gray-400 rounded shadow">
                {' '}
                My Files
              </button>
            </p>
          </div>
        </div>
        <div className="border-none">
          <ReactQuill
            value={content}
            onChange={handleChange}
            modules={{ toolbar: toolbarOptions }}
            className="mt-12 mb-8 h-48 pb-12"
          />
        </div>
        <div className="flex justify-end gap-x-7 font-montserrat font-semibold mb-8 mt-8">
          <a href="#" className="pt-3 text-blue-600">
            Cancel
          </a>
          <button className="text-white bg-blue-600 py-2 px-4 border-gray-400 rounded shadow">
            Save Changes
          </button>
        </div>
      </div>

      <div className="col-span-1 border-l-2 border-indigo-100 h-3/5 mt-28"></div>
    </div>
  )
}

export default AddBlog
