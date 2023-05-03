import React, { ReactNode, useState } from 'react'

import AccountSetting from '@/components/profile/AccountSetting'
import PersonalInfo from '@/components/profile/PersonalInfo'

const Profile: React.FC = () => {
  const [tab, setTab] = useState<number>(0)
  const handleTabChange = (tab: number) => {
    setTab(tab)
  }

  const profiles: ReactNode[] = [
    <PersonalInfo key={0} />,
    <></>,
    <AccountSetting key={2} />,
  ]

  return (
    <div className="p-10">
      <h1 className="font-semibold text-[30px]">Profile</h1>
      <div className="pt-6 text-sm font-medium text-center text-tertiary-text border-b border-primary-text/20">
        <ul className="flex flex-wrap gap-5 -mb-px font-semibold">
          <li className="mr-2">
            <button
              onClick={() => handleTabChange(0)}
              className={`
              'inline-block py-4 px-2 rounded-t-lg text-tertiary-text'
              ${tab == 0 && ' text-primary border-b-4 border-primary'}`}
            >
              Personal Information
            </button>
          </li>
          <li className="mr-2">
            <button
              onClick={() => handleTabChange(1)}
              className={`
              'inline-block py-4 px-2 rounded-t-lg text-tertiary-text'
              ${tab == 1 && ' text-primary border-b-4 border-primary'} `}
            >
              My Blogs
            </button>
          </li>
          <li className="mr-2">
            <button
              onClick={() => handleTabChange(2)}
              className={` 
              'inline-block py-4 px-2 rounded-t-lg text-tertiary-text'
              ${tab == 2 && ' border-b-4 border-primary text-primary'} `}
            >
              Account Settings
            </button>
          </li>
        </ul>
      </div>
      {<>{profiles[tab]}</>}
    </div>
  )
}

export default Profile
