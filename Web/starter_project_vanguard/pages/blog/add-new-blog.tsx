import FileUpload from '@/components/blog/FileUpload'
import TagSelection from '@/components/blog/TagSelection'
import TextEditor from '@/components/blog/TextEditor'
import React, { useState } from 'react'

const AddNewBlog = () => {
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

  const [title, setTitle] = useState('')
  const [selectedTags, setSelectedTags] = useState<string[]>([])
  const [content, setContent] = useState('')
  const [selectedImage, setSelectedImage] = useState<File | null>(null)

  const handleImageUpload = (file: File) => {
    setSelectedImage(file)
    // Perform any additional operations with the selected file
    console.log('Uploaded file:', file)
  }
  const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setTitle(event.target.value)
  }

  // Function to handle form submission
  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault()
    
    // Perform your form submission logic here, including the selected tags
    console.log('Selected Tags:', selectedTags)
    console.log('Content:', content)
    console.log('image:', selectedImage)
    console.log('title:', title)
  }

  // Callback function to update selected tags
  const handleTagSelection = (tags: string[]) => {
    setSelectedTags(tags)
  }

  const handleContentChange = (value: string): void => {
    setContent(value)
  }

  return (
    <div className="flex flex-col lg:flex-row pl-20 mb-36 md:mb-44 lg:mb-72 pr-6 pt-6 min-h-screen">
      <div className="w-full lg:w-3/4 pr-10 pb-10 mr-10">
        <div>
          <form className="mb-10" onSubmit={handleSubmit}>
            <input
              type="search"
              id="search"
              className="block w-full px-4 text-2xl md:text-3xl border-l-2 outline-none border-blue-700 font-montserrat"
              placeholder="Enter the title of the blog"
              required
              value={title}
              onChange={handleTitleChange}
            />

            <FileUpload onImageUpload={handleImageUpload} />

            <TextEditor value={content} onChange={handleContentChange} />

            <div className="flex flex-row gap-4 mt-14 lg:mt-20 p-4 justify-end">
              <button className="btn btn-outline border-none">Cancel</button>
              <button type="submit" className="btn">
                Save Changes
              </button>
            </div>
          </form>
        </div>
      </div>

      <div className="w-full lg:w-1/3 pl-8 border-l-2 pr-16 lg:pr-10 gap-4">
        <h2 className="font-montserrat text-lg font-bold mb-5">Select Tag</h2>
        <div className="flex flex-row gap-3 w-3/4 lg:w-full flex-wrap">
          <TagSelection tags={tags} onTagSelection={handleTagSelection} />
        </div>
      </div>
    </div>
  )
}

export default AddNewBlog
