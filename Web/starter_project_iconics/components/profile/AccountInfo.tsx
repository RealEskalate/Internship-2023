import { AiFillEye } from 'react-icons/ai'
import React, { useState } from 'react'

const AccountInfo: React.FC = () => {
  const [old, setOld] = useState<string>('')
  const [oldShow, setOldShow] = useState<boolean>(false)
  const [newPassword, setNewPassword] = useState<string>('')
  const [newPasswordShow, setNewPasswordShow] = useState<boolean>(false)
  const [confirmed, setConfirmed] = useState<string>('')
  const [confirmedShow, setConfirmedShow] = useState<boolean>(false)

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    // Do something with form data, e.g. submit to a server
  }

  return (
    <form className="mx-auto max-w-[70%] ml-[30%]" onSubmit={handleSubmit}>
      <div className="mb-4"></div>
      <div className="mb-4  flex flex-direction-row">
        <label
          htmlFor="password"
          className=" mb-4 w-[60%] font-bold text-gray-700"
        >
          Current Password
        </label>
        <div className="flex flex-direction-row w-[70%] px-4 py-2 mr-[30%] rounded-lg bg-gray-100 border-transparent ">
          <input
            type={oldShow ? 'text' : 'password'}
            id="password"
            name="password"
            value={old}
            onChange={(event) => setOld(event.target.value)}
            className="bg-gray-100 text-black w-[95%] focus:outline-none"
            placeholder={'Enter Your Current Password'}
            required
          />
          <AiFillEye
            className="mt-1 ml-1"
            color="gray"
            size={20}
            onClick={() => {
              setOldShow(!oldShow)
            }}
          />
        </div>
      </div>
      <div className="mb-4  flex flex-direction-row">
        <label
          htmlFor="password"
          className=" mb-2 w-[60%] font-bold text-gray-700"
        >
          New Password
        </label>
        <div className="flex flex-direction-row w-[70%] px-4 py-2 mr-[30%] rounded-lg bg-gray-100 border-transparent focus:border-transparent">
          <input
            type={newPasswordShow ? 'text' : 'password'}
            id="password"
            name="password"
            value={newPassword}
            onChange={(event) => setNewPassword(event.target.value)}
            className="bg-gray-100 text-black w-[95%] focus:outline-none"
            placeholder={'Enter New Password'}
            required
          />
          <AiFillEye
            className="mt-1 ml-1"
            color="gray"
            size={20}
            onClick={() => {
              setNewPasswordShow(!newPasswordShow)
            }}
          />
        </div>
      </div>
      <div className="mb-4 flex flex-direction-row">
        <label
          htmlFor="password"
          className="mb-2 w-[60%] font-bold text-gray-700"
        >
          Confirm Password
        </label>
        <div className="flex flex-direction-row w-[70%] px-4 py-2 mr-[30%] rounded-lg bg-gray-100 border-transparent">
          <input
            type={confirmedShow ? 'text' : 'password'}
            id="password"
            name="password"
            className="bg-gray-100 text-black w-[95%]"
            value={confirmed}
            onChange={(event) => setConfirmed(event.target.value)}
            placeholder={`Confirm New Password`}
            required
          />
          <AiFillEye
            className="mt-1 ml-1"
            color="gray"
            size={20}
            onClick={() => {
              setConfirmedShow(!confirmedShow)
            }}
          />
        </div>
      </div>
    </form>
  )
}

export default AccountInfo
