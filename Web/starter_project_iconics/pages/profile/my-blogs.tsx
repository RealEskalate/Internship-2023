import ProfileLayout from '@/components/profile/ProfilePageLayout'
import MyBlogs from '@/components/profile/MyBlogsPage'

const myBlogs = () => {
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

export default myBlogs
