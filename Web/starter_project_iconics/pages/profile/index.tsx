import ProfileLayout from '@/components/profile/profileLayout'
import { cards } from '../../data/profile/blogs'
import MyBlogs from '@/components/profile/myBlogs'

const index = () => {
  return (
    <ProfileLayout
      buttonText="New Blog"
      element={<MyBlogs cards={cards} />}
      text="Manage Blogs"
      innerText="Edit, Delete and View the Status of your blogs"
    ></ProfileLayout>
  )
}

export default index
