import { AiFillEye } from 'react-icons/ai'
import React, { useState } from 'react'

const AccountInfo: React.FC = () => {
  const [old, setOld] = useState('')
  const [oldView, setOldView] = useState(false)
  const [newPassword, setNewPassword] = useState('')
  const [newPasswordVew, setNewPasswordView] = useState(false)
  const [confirmed, setConfirmed] = useState('')
  const [confirmedView, setConfirmedView] = useState(false)

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    // Do something with form data, e.g. submit to a server
  }

  const handleTogglePassword = (
    setState: React.Dispatch<React.SetStateAction<boolean>>
  ) => {
    setState((prevValue) => !prevValue)
  }

  return (
    <div>
      <div className="flex flex-col md:flex-row justify-center my-5 py-4 items-center bg-white">
        <div>
          <h2 className="text-2xl font-bold text-gray-500">
            Manage Your Account
          </h2>
          <h3 className="text-sm text-gray-400">
            You can change your password here
          </h3>
        </div>
        <div className="flex-1"></div>
        <button className="text-sm font-semibold text-white bg-primary px-8 py-2 rounded-md float-right">
          Save changes
        </button>
      </div>
      <form className="mx-auto max-w-[70%] ml-[30%]" onSubmit={handleSubmit}>
        {[
          {
            label: 'Current Password',
            state: old,
            viewName: oldView,
            view: setOldView,
            setState: setOld,
          },
          {
            label: 'New Password',
            state: newPassword,
            viewName: newPasswordVew,
            view: setNewPasswordView,
            setState: setNewPassword,
          },
          {
            label: 'Confirm Password',
            state: confirmed,
            viewName: confirmedView,
            view: setConfirmedView,
            setState: setConfirmed,
          },
        ].map(({ label, state, viewName, view, setState }) => (
          <div key={label} className="mb-4 flex items-center">
            <label
              htmlFor={label.toLowerCase().replace(/\s/g, '-')}
              className="mb-2 mr-20 font-bold text-gray-700 w-36"
            >
              {label}
            </label>
            <div className="flex items-center w-[35%] px-4 py-2 rounded-lg bg-gray-100 border-transparent">
              <input
                type={viewName ? 'text' : 'password'}
                id={label.toLowerCase().replace(/\s/g, '-')}
                name={label.toLowerCase().replace(/\s/g, '-')}
                value={state}
                onChange={(event) => setState(event.target.value)}
                className="bg-gray-100 text-black w-full focus:outline-none"
                placeholder={`Enter ${label}`}
                required
              />
              <AiFillEye
                className="mt-1 ml-1"
                color="gray"
                size={20}
                onClick={() => handleTogglePassword(view)}
                aria-label={state === '' ? 'Show password' : 'Hide password'}
              />
            </div>
          </div>
        ))}
      </form>
    </div>
  )
}

export default AccountInfo
