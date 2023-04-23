import React, { useState } from 'react'
import { AiFillEyeInvisible, AiFillEye } from 'react-icons/ai'

const AccountSetting: React.FC = () => {
  const [showCurrPassword, setShowCurrPassword] = useState<boolean>(false)
  const [showNewPassword, setShowNewPassword] = useState<boolean>(false)
  const [showConfirmPassword, setShowConfirmPassword] = useState<boolean>(false)

  return (
    <div className="mt-5 flex flex-col justify-center gap-2 px-auto">
      <div className="flex justify-between py-3">
        <div className="font-montserrat ">
          <h1 className="font-semibold text-xl">Manage your account</h1>
          <p className="text-primary-text">
            you can change your password here.
          </p>
        </div>
        <button className="bg-primary text-white rounded px-3 h-9 my-auto mr-8">
          Save Changes
        </button>
      </div>
      <hr />
      <form className="mx-auto font-poppins font-semibold text-tertiary-text pt-5 flex flex-col gap-4">
        <div className="relative">
          <label htmlFor="currPassword">Current Password</label>
          <div
            className="absolute top-3 right-3"
            onClick={() => setShowCurrPassword(!showCurrPassword)}
          >
            {showCurrPassword ? <AiFillEye /> : <AiFillEyeInvisible />}
          </div>
          <input
            type="password"
            id="currPassword"
            name="currPassword"
            className="p-2 border border-gray-300 outline-none bg-gray-50 ml-10 rounded-md"
          placeholder='Current password'
          />
        </div>
        <div className="relative">
          <label htmlFor="newPassword" className="mr-2">
            New Password
          </label>
          <div
            className="absolute top-3 right-3"
            onClick={() => setShowNewPassword(!showNewPassword)}
          >
            {showNewPassword ? <AiFillEye /> : <AiFillEyeInvisible />}
          </div>
          <input
            id="newPassword"
            name="newPassword"
            type="password"
            className="p-2  border border-gray-300 outline-none bg-gray-50 ml-14 rounded-md"
          placeholder='Enter new password'
          />
        </div>
        <div className="relative">
          <label htmlFor="confirmPassword">Confirm Password</label>
          <div
            className="absolute top-3 right-3"
            onClick={() => setShowConfirmPassword(!showConfirmPassword)}
          >
            {showConfirmPassword ? <AiFillEye /> : <AiFillEyeInvisible />}
          </div>
          <input
            type="password"
            id="confirmPassword"
            name="confirmPassword"
            className="p-2 border border-gray-300 outline-none bg-gray-50 ml-10 rounded-md"
          placeholder='Confirm password'
          />
        </div>
      </form>
    </div>
  )
}

export default AccountSetting
