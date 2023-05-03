import Image from 'next/image'
import React, { useState } from 'react'
import { AiOutlineCloudUpload } from 'react-icons/ai'
import { HiOutlineMail } from 'react-icons/hi'

import { user } from '../../data/profile/user'
const PersonalInfo: React.FC = () => {
  const [firstName, setFirstName] = useState(user.firstName)
  const [lastName, setLastName] = useState(user.lastName)
  const [email, setEmail] = useState(user.email)
   return (
    <div className="flex flex-col gap-4 py-6  text-secondary-text">
      <div className="flex justify-between">
        <div>
          <h1 className="font-semibold text-secondary-text pt-3 text-xl">
            Manage Personal Information
          </h1>
          <p>Add all required information about yourself</p>
        </div>
        <button className="bg-primary text-white rounded px-3 h-9 my-auto mr-8">
          Save <span className="hidden sm:inline-block">Changes</span>
        </button>
      </div>
      <hr />

      <div className="flex py-5 gap-10 ">
        <label htmlFor="" className="pt-3 relative">
          Name <span className="text-red-500 absolute top-3 -right-3">*</span>
        </label>
        <div className="flex gap-10 ml-10 flex-wrap">
          <input
            className="bg-gray-50  ml-10 p-2   text-tertiary-text b-2 pl-3 outline-none  border border-primary-text/20 rounded-lg"
            value={firstName}
            onChange={(e)=>setFirstName(e.target.value)}
            type="text"
          />
          <input
            className="b-2 p-2 pl-3 outline-none ml-10 border border-primary-text/20 bg-gray-50 rounded-lg"
            value={lastName}
            onChange={(e)=>setLastName(e.target.value)}
            type="text"
          />
        </div>
      </div>
      <hr />
      <div className="flex py-5 gap-10">
        <label htmlFor="email" className="mr-10 pt-3 relative">
          Email <span className="text-red-500  absolute top-3 -right-3">*</span>
        </label>
        <div className="relative mb-6">
          <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
            <HiOutlineMail className="w-5 h-5 ml-10 text-primary-text/50" />
          </div>
          <input
            required
            value={email}
            onChange={(e)=>setEmail(e.target.value)}
            type="text"
            id="email"
            className="bg-gray-50 border ml-10 sm:w-[100%] md:w-[195%]  border-primary-text/20 text-primary-text text-sm rounded-lg block  pl-10 p-3 outline-none"
          />
        </div>
      </div>
      <hr />
      <div className="flex py-5 gap-10">
        <label htmlFor="" className="mr-10 pt-3 relative">
          Your Photo <span className="text-red-500  absolute top-3 -right-3">*</span>
        </label>
        <Image
          src={user.img}
          alt={user.firstName + user.lastName}
          className="h-[80px] w-[80px] rounded-lg"
        />
        <div className="flex items-center justify-center w-[35%] h-[20%]">
          <label className="flex flex-col items-center justify-center w-full h-50 border-2 border-text-primary/20  rounded-lg cursor-pointer bg-gray-50">
            <div className="flex flex-col items-center justify-center pt-5 pb-6">
              <div className="rounded-full bg-slate-200 m-4">
                <AiOutlineCloudUpload className="w-10 h-10 text-primary p-2" />
              </div>
              <div className="hidden sm:block">
                <p className=" mb-2 text-sm text-primary-text">
                  <span className="font-semibold">Click to upload</span> or drag
                  and drop
                </p>
                <p className="text-xs text-tertiary-text">
                  SVG, PNG, JPG or GIF (MAX. 800x400px)
                </p>
              </div>
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
