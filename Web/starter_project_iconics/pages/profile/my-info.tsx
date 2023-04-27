import ProfileLayout from '@/components/profile/ProfileLayout'
import user from '../../data/profile/user.json'
import Form from '@/components/profile/MyPersonalInfo'
import { User } from '@/types/profile/user'

const index = () => {
  const result: User = JSON.parse(JSON.stringify(user))
  return (
    <ProfileLayout
      buttonText="Save changes"
      element={<Form user={user} />}
      text="Manage Personal Information"
      innerText="Add all the required information about yourself"
      currentPage="My Information"
    ></ProfileLayout>
  )
}

export default index
