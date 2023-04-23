import Link from 'next/link'
import React, { useState } from 'react'

import AccountSetting from '@/components/profile/AccountSetting'
import PersonalInfo from '@/components/profile/PersonalInfo'

const Profile: React.FC = () => {
  const [tab, setTab] = useState<number>(0)
  const handleTabChange = (tab: number) => {
    setTab(tab)
  }

  return (
    <div className="px-10">
      <h1 className="font-medium font-poppins text-[40px]">Profile</h1>
      <div className="text-sm font-medium text-center text-gray-500 border-b border-gray-200 dark:text-gray-400 dark:border-gray-700">
        <ul className="flex flex-wrap -mb-px">
          <li className="mr-2">
            <Link
              onClick={() => handleTabChange(0)}
              href="#"
              className={`${
                tab == 0 && ' text-blue-600 border-b-2 border-blue-600'
              } inline-block p-4 rounded-t-lg  dark:text-blue-500 dark:border-blue-500`}
              aria-current="page"
            >
              Personal Information
            </Link>
          </li>
          <li className="mr-2">
            <Link
              onClick={() => handleTabChange(1)}
              href="#"
              className={`${
                tab == 1 && ' text-blue-600 border-b-2 border-blue-600'
              } inline-block p-4 rounded-t-lg  dark:text-blue-500 dark:border-blue-500`}
              aria-current="page"
            >
              My Blogs
            </Link>
          </li>
          <li className="mr-2">
            <Link
              onClick={() => handleTabChange(2)}
              href="#"
              className={`${
                tab == 2 && ' text-blue-600 border-b-2 border-blue-600'
              } inline-block p-4 rounded-t-lg  dark:text-blue-500 dark:border-blue-500`}
              aria-current="page"
            >
              Account Setting
            </Link>
          </li>
        </ul>
      </div>
      {tab === 0 && <PersonalInfo />}
      {tab === 2 && <AccountSetting />}
    </div>
  )
}

export default Profile
