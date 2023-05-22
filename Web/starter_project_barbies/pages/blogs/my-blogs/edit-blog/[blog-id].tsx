import {
  useGetBlogByIDQuery,
  useUpdateBlogByIdMutation,
} from '@/store/blog/blogs-api'
import Head from 'next/head'
import { useRouter } from 'next/router'
import { FormEvent, useEffect, useState } from 'react'
import { CgClose } from 'react-icons/cg'

const tags:string[] = [
  "Sport",
  "Art",
  "Music",
  "Science",
  "Architecture",
  "Poem",
  "Film",
  "Travel",
  "Hiking",
  "Politics",
  "philosophy",
] 

const EditBlog = () => {
  const route = useRouter()
  const blogID = route.query['blog-id'] as string
  const { data: blog, isLoading, error } = useGetBlogByIDQuery(blogID)
  const [setEditBlog] = useUpdateBlogByIdMutation()
  const [title, setTitle] = useState('')
  const [content, setContent] = useState('')
  const [selectedTags, setSelectedTags] = useState<string[]>(blog?.tags as string[])
  const [showTags, setShowTags] = useState(false)
  useEffect(() => {
    if (!isLoading && blog) {
      setTitle(blog.title)
      setContent(blog.content)
      setSelectedTags(blog.tags)
    }
  }, [tags, blog, isLoading])
  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    try {
      await setEditBlog({
        id: blogID,
        blog: { title: title, content: content, shortDescription:content.slice(0, 0.25*content.length), tags:selectedTags },
        userId: blog?.userID as string
      })
      route.push(`/blogs/${blogID}`)
    } catch (error) {
      console.log(error)
    }
  }
  const removeTag = (newtag:string) => {
    setSelectedTags(selectedTags.filter(tag => tag !== newtag))
  }
  const addTag = (tag:string)=> {
    if (!selectedTags.includes(tag)){
      setSelectedTags([...selectedTags, tag])
    }
  }

  return (
    <div className='max-w-6xl mx-auto'>
      <Head>
        <title>{blog?.title}</title>
      </Head>
      {blog && (
        <form
          className="flex flex-col items-start space-y-10 p-10 shadow-md rounded-md m-10 border"
          onSubmit={(e) => {
            handleSubmit(e)
          }}
        >
          <div className='w-full space-y-3'>
            <label htmlFor="title">Title</label>
            <input
              className="px-5 py-2 w-full rounded-md border"
              value={title}
              type="text"
              id="title"
              placeholder="Title"
              onChange={(e) => {
                setTitle(e.target.value)
              }}
            />
          </div>
          <div className='w-full space-y-3'>
            <label htmlFor="content">Content</label>
            <textarea
              className="p-5 rounded-md border w-full"
              name="content"
              value={content}
              id="content"
              cols={50}
              rows={10}
              onChange={(e) => {
                setContent(e.target.value)
              }}
            ></textarea>
          </div>
          <div className='space-y-2'>
            <div className="items-center rounded-lg p-2 space-y-2">
              <label htmlFor="preferences" className="font-semibold">
                Tags
              </label>
              <button
                id="preferences"
                className="relative flex items-center justify-between px-5 py-3 col-span-2 rounded-lg border"
                type='button'
                onClick={() => setShowTags(!showTags)}
              >  
                Add Preferences 
                {showTags && (
                  <div className="absolute z-10 top-full mt-2 py-2 w-56 bg-white rounded-md shadow-xl">
                    {tags.map((tag, index) => (
                      <button
                        key={index}
                        type='button'
                        onClick={() => addTag(tag)}
                        className="text-left w-full px-4 py-2 text-gray-800 hover:bg-primary hover:text-white"
                      >
                        {tag}
                      </button>
                    ))}
                  </div>
                )}
              </button>
            </div>
            <div className='flex flex-wrap gap-2 '>
              {
                selectedTags?.map((tag, index) => (
                  <div key={index} className='flex items-center relative px-7 py-2 rounded-full bg-gray-200'>
                    {tag}
                    <button type='button' className='absolute right-2' onClick={() => {removeTag(tag)}}>
                      <CgClose  />
                    </button>
                  </div>
                ))
              }
            </div>
          </div>
          
          <button
            className="px-3 py-2 rounded-lg bg-blue-500 text-white"
            type="submit"
          >
            Submit
          </button>
        </form>
      )}
    </div>
  );
}

export default EditBlog
