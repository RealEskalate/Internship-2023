import FileUpload from '@/components/blog/FileUpload'
import TagSelection from '@/components/blog/TagSelection'
import TextEditor from '@/components/blog/TextEditor'
import { useAddBlogMutation } from '@/store/features/blog/add-new-blog-api'
import React, { useEffect, useState } from 'react'
import { date } from 'yup'

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
  const [imageSrc, setImageSrc] = useState()
  const [selectedTags, setSelectedTags] = useState<string[]>([])
  const [content, setContent] = useState('')
  const [selectedImage, setSelectedImage] = useState<File | null>(null)

  const handleImageUpload = (file: File) => {
    setSelectedImage(file)
  }
  const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setTitle(event.target.value)
  }
  useEffect(() => {
    const getImageUrl = async () => {
      try {
        if (selectedImage) {
          const formData = new FormData()
          formData.append('file', selectedImage)
          formData.append('upload_preset', 'blog-img')

          const response = await fetch(
            'https://api.cloudinary.com/v1_1/dfmpk2qfp/image/upload',
            {
              method: 'POST',
              body: formData,
            }
          )

          if (response.ok) {
            const data = await response.json()
            const imageUrl = data.url
            setImageSrc(imageUrl)
          } else {
            console.error('Image upload failed:', response.statusText)
          }
        }
      } catch (error) {
        console.error('Error:', error)
      }
    }

    getImageUrl()
  }, [selectedImage])

  const [
    addNewBlog,
    {
      data: addBlogData,
      isError: isAddBlogError,
      isSuccess: isAddBlogSuccess,
      error: addBlogError,
    },
  ] = useAddBlogMutation()

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault()
    const currentDate = new Date()
    await addNewBlog({
      title: title,
      img: imageSrc || '',
      skills: selectedTags,
      description: content,
      authorName: 'Segni Desta',
      id: currentDate.getSeconds().toString(),
      profession: 'Software Engineering',
      authorUserName: 'segni',
      authorPhoto: 'https://picsum.photos/id/165/200',
      isPending: true,
      company: 'BIOTICA',
      descriptionTitle:
        'Network traffic passes through the front-end can seem hard at first glance. And you may not be familiar with advanced algorithms, but there are simple steps you can follow to see outstanding results in a short period of time.',
      likes: 1722,
      time: currentDate.getTime(),
      date: 'Dec 13,2014',
    })
  }
  useEffect(() => {
    if (isAddBlogSuccess) {
      //move to the blog page
    }
  }, [isAddBlogSuccess])

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
              className="block w-full px-4 text-2xl md:text-3xl border-l-2 outline-none border-primary font-montserrat"
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
