import TextEditor from '@/components/blog/TextEditor'
import Error from '@/components/common/Error'
import Tag from '@/components/common/Tag'
import { useGetTagsQuery } from '@/store/features/blog/tags-api'
import Image from 'next/image'
import Link from 'next/link'
import React from 'react'
import 'react-quill/dist/quill.snow.css'

const AddBlog: React.FC = () => {
  const tagClassName =
    'rounded-full font-montserrat bg-gray-100 px-4 py-2 m-1 font-semibold'
  const { data: tags, isLoading, error } = useGetTagsQuery()

  const [selectedTags, setSelectedTags] = React.useState<string[]>([])

  const handleTagClick = (tag: string) => {
    if (selectedTags.includes(tag)) {
      setSelectedTags(selectedTags.filter((t) => t !== tag))
    } else {
      setSelectedTags([...selectedTags, tag])
    }
  }

  return (
    <div className="grid grid-cols-1 gap-8 bg-white sm:grid-cols-3">
      <div className="sm:col-span-2 mx-auto w-5/6 col-span-3">
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
              <button className="bg-white hover:bg-gray-50 text-secondary-text py-2 px-4 border-gray-400 rounded shadow">
                {' '}
                My Files
              </button>
            </p>
          </div>
        </div>
        <div className="border-none">
          <TextEditor />
        </div>
        <div className="flex justify-end gap-x-7 font-montserrat font-semibold mb-8 mt-8">
          <Link href="#" className="pt-3 text-blue-600">
            Cancel
          </Link>
          <button className="text-white bg-blue-600 py-2 px-4 border-gray-400 rounded shadow">
            Save Changes
          </button>
        </div>
      </div>

      <div
        className="col-span-3 border-l-2 border-indigo-100 m-8 sm:col-span-1 sm:width-1/2"
        style={{ height: '575px' }}
      >
        {isLoading ? (
          <div>
            <h3 className="font-bold ml-4 font-montserrat tracking-wider">
              Select Tag
            </h3>
            <div className="rounded-md p-4 max-w-sm w-full mx-auto">
              <div className="animate-pulse flex space-x-4">
                <div className="flex-1 space-y-6 py-1">
                  <div className="space-y-3">
                    <div className="grid grid-cols-3 gap-4">
                      <div className="h-8 bg-slate-200 rounded-full col-span-1"></div>
                      <div className="h-8 bg-slate-200 rounded-full col-span-1"></div>
                      <div className="h-8 bg-slate-200 rounded-full col-span-1"></div>
                      <div className="h-8 bg-slate-200 rounded-full col-span-2"></div>
                      <div className="h-8 bg-slate-200 rounded-full col-span-1"></div>
                      <div className="h-8 bg-slate-200 rounded-full col-span-2"></div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        ) : error ? (
          <div className="col-span-3 border-l-2 border-indigo-100 m-8 sm:col-span-1 sm:width-1/2">
            <h3 className="font-bold ml-4 font-montserrat tracking-wider">
              Select Tag
            </h3>
            <Error />
          </div>
        ) : (
          <div>
            <h3 className="font-bold ml-4 font-montserrat tracking-wider">
              Select Tag
            </h3>
            <div className="m-4 font-montserrat">
              {tags?.map((tag, index) => (
                <Tag
                  key={index}
                  child={tag}
                  onClick={() => handleTagClick(tag)}
                  classname={
                    selectedTags.includes(tag)
                      ? `border-2 border-blue-800 text-blue-800 ${tagClassName}`
                      : `text-primary-text ${tagClassName}`
                  }
                />
              ))}
            </div>
          </div>
        )}
      </div>
    </div>
  )
}

export default AddBlog
