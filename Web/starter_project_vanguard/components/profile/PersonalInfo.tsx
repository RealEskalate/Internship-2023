import Image  from 'next/image'
import React from 'react'

import {User} from '@/types/user-profile'
import profile from 'public/images/profile-photo.png'

const user: User = {
  firstName: 'Segni',
  lastName: 'Desta',
  email: 'segni@gmail.com',
  img: profile,
}
const PersonalInfo:React.FC = () => {
  return (
    <div className="flex flex-col gap-4 py-6">
      <div className="flex justify-between">
        <div className="font-montserrat">
          <h1 className="font-semibold pt-3 text-xl">
            Manage Personal Information
          </h1>
          <p className="text-primary-text">
            Add all required information about yourself
          </p>
        </div>
        <button className="bg-primary text-white rounded px-3 h-9 my-auto mr-8">
          Save Changes
        </button>
      </div>
      <hr />

      <div className="flex py-5 gap-10">
        <label htmlFor="">
          Name <span className="text-red-500">*</span>
        </label>
        <div className="flex gap-10 ml-10">
          <input
            className="bg-gray-50  ml-10 w-[200%]  text-gray-900 b-2 pl-3 outline-none  border border-gray-300 rounded-lg"
            value={user.firstName}
            type="text"
          />
          <input
            className="b-2 p-2 pl-3 outline-none ml-10 border border-gray-300 bg-gray-50 rounded-lg"
            value={user.lastName}
            type="text"
          />
        </div>
      </div>
      <hr />
      <div className="flex py-5 gap-10">
        <label htmlFor="" className="mr-10">
          Email <span className="text-red-500">*</span>
        </label>
        <div className="relative mb-6">
          <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
            <svg
              aria-hidden="true"
              className="w-5 h-5 ml-10 text-gray-500 dark:text-gray-400"
              fill="currentColor"
              viewBox="0 0 20 20"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path d="M2.003 5.884L10 9.882l7.997-3.998A2 2 0 0016 4H4a2 2 0 00-1.997 1.884z"></path>
              <path d="M18 8.118l-8 4-8-4V14a2 2 0 002 2h12a2 2 0 002-2V8.118z"></path>
            </svg>
          </div>
          <input
            required
            value={user.email}
            type="text"
            id="input-group-1"
            className="bg-gray-50 border ml-10 w-[195%] border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block  pl-10 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          />
        </div>
      </div>
      <hr />
      <div className="flex py-5 gap-10 ">
        <label htmlFor="" className="mr-10">
          Your Photo <span className="text-red-500">*</span>
        </label>
        <Image
          src={user.img}
          alt={user.firstName + user.lastName}
          className="h-[80px] w-[80px] rounded-lg"
        />
        <div className="flex items-center justify-center w-[35%] h-[20%]">
          <label className="flex flex-col items-center justify-center w-full h-50 border-2 border-gray-300 border-dashed rounded-lg cursor-pointer bg-gray-50 dark:hover:bg-bray-800 dark:bg-gray-700 hover:bg-gray-100 dark:border-gray-600 dark:hover:border-gray-500 dark:hover:bg-gray-600">
            <div className="flex flex-col items-center justify-center pt-5 pb-6">
              <svg
                aria-hidden="true"
                className="w-10 h-10 mb-3 text-gray-400"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M7 16a4 4 0 01-.88-7.903A5 5 0 1115.9 6L16 6a5 5 0 011 9.9M15 13l-3-3m0 0l-3 3m3-3v12"
                ></path>
              </svg>
              <p className="mb-2 text-sm text-gray-500 dark:text-gray-400">
                <span className="font-semibold">Click to upload</span> or drag
                and drop
              </p>
              <p className="text-xs text-gray-500 dark:text-gray-400">
                SVG, PNG, JPG or GIF (MAX. 800x400px)
              </p>
            </div>
            <input id="dropzone-file" type="file" className="hidden" />
          </label>
        </div>
      </div>
      <hr />
    </div>
  )
}

export default PersonalInfo
