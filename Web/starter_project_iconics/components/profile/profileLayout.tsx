import Link from 'next/link'
import React, { useState } from 'react'

type ProfileProps = {
  buttonText: string
  element: React.ReactNode
  text: string
  innerText: string
  currentPage: string
}

const ProfileLayout: React.FC<ProfileProps> = ({
  buttonText,
  element,
  text,
  innerText,
  currentPage,
}) => {
  const [activeLink, setActiveLink] = useState(currentPage)

  const handleLinkClick = (linkText: string) => {
    setActiveLink(linkText)
  }

  return (
    <div className="min-h-screen bg-white flex p-10 flex-col">
      <div className="flex   py-4">
        <h1 className="text-4xl font-bold text-gray-900">Profile</h1>
      </div>
      <div className="flex flex-col md:flex-row justify-center items-center bg-white pb-0">
        <Link
          href="/profile/my-info"
          className={`text-lg font-semibold  text-tab pl-0 pr-4 pt-2 pb-5 hover:text-primary ${
            activeLink === 'My Information'
              ? 'border-b-2 border-primary text-primary'
              : 'border-b-2 border-transparent text-tab'
          }`}
          onClick={() => handleLinkClick('My Information')}
        >
          Personal Information
        </Link>
        <Link
          href="/profile/my-blogs"
          className={`text-lg font-semibold  text-tab px-4 pt-2 pb-5 hover:text-primary ${
            activeLink === 'My Blogs'
              ? 'border-b-2 border-primary text-primary'
              : 'border-b-2 border-transparent text-tab'
          }`}
          onClick={() => handleLinkClick('My Blogs')}
        >
          My Blogs
        </Link>
        <Link
          href="/profile/my-account"
          className={`text-lg font-semibold  px-4 pt-2 pb-5 hover:text-primary ${
            activeLink === 'My Account'
              ? 'border-b-2 border-primary text-primary'
              : 'border-b-2 border-transparent text-tab'
          }`}
          onClick={() => handleLinkClick('My Account')}
        >
          Account Settings
        </Link>
        <div className="flex-1"></div>
      </div>
      <hr className="border-gray-300" />
      <div className="flex flex-col md:flex-row justify-center my-5 py-4 items-center bg-white">
        <span>
          <h2 className={`text-2xl font-bold text-gray-500`}>{text}</h2>
          <h3 className={`text--.1xl text-gray-400`}>{innerText}</h3>
        </span>
        <div className="flex-1"></div>
        <button className="text-sm font-semibold text-white bg-primary px-8 py-2 rounded-md float-right">
          {buttonText}
        </button>
      </div>
      <hr className="border-gray-300" />
      <div className="flex-2">{element}</div>
    </div>
  )
}

export default ProfileLayout
