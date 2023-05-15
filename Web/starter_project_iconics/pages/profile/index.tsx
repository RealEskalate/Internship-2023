import MyBlogs from '@/components/profile/MyBlogs'
import Link from 'next/link'
import React, { useState } from 'react'

const Index: React.FC = () => {
  const [activeLink, setActiveLink] = useState('My_Blogs')
  const bodyElement: {
    [key: string]: React.ReactNode
  } = { My_Blogs: <MyBlogs /> }
  return (
    <div className="min-h-screen bg-white flex p-10 flex-col">
      <div className="flex py-4">
        <h1 className="text-4xl font-bold text-gray-900">Profile</h1>
      </div>
      <div className="flex flex-col md:flex-row justify-center items-center bg-white pb-0">
        <Link
          href="#"
          className={`text-lg font-semibold  text-third pl-0 pr-4 pt-2 pb-5 hover:text-primary ${
            activeLink === 'My_Information'
              ? 'border-b-2 border-primary text-primary'
              : 'border-b-2 border-transparent text-third'
          }`}
          onClick={() => setActiveLink('My_Information')}
        >
          Personal Information
        </Link>
        <Link
          href="#"
          className={`text-lg font-semibold text-third px-4 pt-2 pb-5 hover:text-primary ${
            activeLink === 'My_Blogs'
              ? 'border-b-2 border-primary text-primary'
              : 'border-b-2 border-transparent text-third'
          }`}
          onClick={() => setActiveLink('My_Blogs')}
        >
          My Blogs
        </Link>
        <Link
          href="#"
          className={`text-lg font-semibold  px-4 pt-2 pb-5 hover:text-primary ${
            activeLink === 'My_Account'
              ? 'border-b-2 border-primary text-primary'
              : 'border-b-2 border-transparent text-third'
          }`}
          onClick={() => setActiveLink('My_Account')}
        >
          Account Settings
        </Link>
        <div className="flex-1"></div>
      </div>
      <hr className="border-gray-300" />

      <hr className="border-gray-300" />
      <div className="flex-2">{bodyElement[activeLink || 'My_Blogs']}</div>
    </div>
  )
}

export default Index
