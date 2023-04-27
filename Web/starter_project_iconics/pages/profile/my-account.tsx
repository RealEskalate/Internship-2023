import ProfileLayout from '@/components/profile/ProfileLayout'
import AccountInfo from '@/components/profile/AccountInfo'

const index = () => {
  return (
    <ProfileLayout
      buttonText="Save changes"
      element={<AccountInfo />}
      text="Manage Your Account"
      innerText="You can change your password here"
      currentPage="My Account"
    ></ProfileLayout>
  )
}

export default index
