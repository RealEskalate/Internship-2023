import ProfileLayout from '@/components/profile/ProfileLayout'
import MyBlogs from '../../components/profile/MyBlogs'

const index: React.FC = () => {
  return (
    <ProfileLayout
      buttonText="New Blog"
      bodyElement={<MyBlogs />}
      bodyMainText="Manage Blogs"
      bodyInnerText="Edit, Delete and View the Status of your blogs"
      currentPage="My Blogs"
    ></ProfileLayout>
  )
}

export default index
