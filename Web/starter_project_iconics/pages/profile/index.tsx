import ProfileLayout from '@/components/profile/profileLayout'
import { cards } from '../../data/blogs'
import MyBlogs from '@/components/profile/myblogs'

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
