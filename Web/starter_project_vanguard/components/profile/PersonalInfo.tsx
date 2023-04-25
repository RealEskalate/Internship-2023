import Image from 'next/image'
import React from 'react'
import { AiOutlineCloudUpload } from 'react-icons/ai'
import { HiOutlineMail, HiOutlineMailOpen } from 'react-icons/hi'

import {user} from './user'
const PersonalInfo: React.FC = () => {
  return (
    <div className="flex flex-col gap-4 py-6  text-secondary-text">
      <div className="flex justify-between">
        <div>
          <h1 className="font-semibold text-secondary-text pt-3 text-xl">
            Manage Personal Information
          </h1>
          <p>
            Add all required information about yourself
          </p>
        </div>
        <button className="bg-primary text-white rounded px-3 h-9 my-auto mr-8">
          Save Changes
        </button>
      </div>
      <hr />

      <div className="flex py-5 gap-10 ">
        <label htmlFor="" className="pt-3">
          Name <span className="text-red-500">*</span>
        </label>
        <div className="flex gap-10 ml-10 flex-wrap">
          <input
            className="bg-gray-50  ml-10 p-2   text-gray-900 b-2 pl-3 outline-none  border border-gray-300 rounded-lg"
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
        <label htmlFor="email" className="mr-10 pt-3">
          Email <span className="text-red-500">*</span>
        </label>
        <div className="relative mb-6">
          <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
            <HiOutlineMail className="w-5 h-5 ml-10 text-gray-500 dark:text-gray-400" />
          </div>
          <input
            required
            value={user.email}
            type="text"
            id="email"
            className="bg-gray-50 border ml-10 sm:w-[100%] md:w-[195%]  border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500  block  pl-10 p-3  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white outline-none"
          />
        </div>
      </div>
      <hr />
      <div className="flex py-5 gap-10">
        <label htmlFor="" className="mr-10 pt-3">
          Your Photo <span className="text-red-500">*</span>
        </label>
        <Image
          src={user.img}
          alt={user.firstName + user.lastName}
          className="h-[80px] w-[80px] rounded-lg"
        />
        <div className="flex items-center justify-center w-[40%] h-[20%]">
          <label className="flex flex-col items-center justify-center w-full h-50 border-2 border-gray-300  rounded-lg cursor-pointer bg-gray-50 dark:hover:bg-bray-800 dark:bg-gray-700 hover:bg-gray-100 dark:border-gray-600 dark:hover:border-gray-500 dark:hover:bg-gray-600">
            <div className="flex flex-col items-center justify-center pt-5 pb-6">
              <div className='rounded-full bg-slate-200 m-4'>
              <AiOutlineCloudUpload className="w-10 h-10 text-primary p-2" />
              </div>

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
