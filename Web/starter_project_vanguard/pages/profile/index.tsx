import Link from 'next/link'
import React, { ReactNode, useState } from 'react'

import AccountSetting from '@/components/profile/AccountSetting'
import PersonalInfo from '@/components/profile/PersonalInfo'

const Profile: React.FC = () => {
  const [tab, setTab] = useState<number>(0)
  const handleTabChange = (tab: number) => {
    setTab(tab)
  }

  const profiles: ReactNode[] = [
    <PersonalInfo />,
    <></>,
    <AccountSetting />,
  ]

  return (
    <div className="p-10">
      <h1 className="font-semibold text-[30px]">Profile</h1>
      <div className="pt-6 text-sm font-medium text-center text-gray-500 border-b border-gray-200 dark:text-gray-400 dark:border-gray-700">
        <ul className="flex flex-wrap gap-5 -mb-px font-semibold">
          <li className="mr-2">
            <button
              onClick={() => handleTabChange(0)}
              className={`${
                tab == 0 && ' text-primary border-b-4 border-primary'
              } inline-block p-4 pl-0 rounded-t-lg  dark:text-primary dark:border-primary`}
              aria-current="page"
            >
              Personal Information
            </button>
          </li>
          <li className="mr-2">
            <button
              onClick={() => handleTabChange(1)}
              className={`${
                tab == 1 && ' text-primary border-b-4 border-primary'
              } inline-block py-4 px-2 rounded-t-lg  dark:text-primary dark:border-primary`}
              aria-current="page"
            >
              My Blogs
            </button>
          </li>
          <li className="mr-2">
            <button
              onClick={() => handleTabChange(2)}
              className={`${
                tab == 2 && ' text-primary border-b-4 border-primary'
              } inline-block py-4 px-2 rounded-t-lg  dark:text-primary dark:border-primary`}
              aria-current="page"
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
