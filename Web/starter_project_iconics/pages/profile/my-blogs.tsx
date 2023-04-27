import ProfileLayout from '@/components/profile/profileLayout'
import cards from '../../data/profile/blogs.json'
import MyBlogs from '@/components/profile/myBlogs'
import { Blog } from '@/types/profile/blog'

const myBlogs = () => {
  const result: Blog[] = JSON.parse(JSON.stringify(cards))
  return (
    <ProfileLayout
      buttonText="New Blog"
      element={<MyBlogs cards={result} />}
      text="Manage Blogs"
      innerText="Edit, Delete and View the Status of your blogs"
      currentPage="My Blogs"
    ></ProfileLayout>
  )
}

export default myBlogs