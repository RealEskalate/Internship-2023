import ProfileLayout from '@/components/profile/ProfileLayout'
import cards from '../../data/profile/blogs.json'
import MyBlogs from '@/components/profile/MyBlogs'
import { Blog } from '@/types/profile/blog'

const index = () => {
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

export default index
