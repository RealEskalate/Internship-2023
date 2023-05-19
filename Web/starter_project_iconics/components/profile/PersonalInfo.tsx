import React, { useRef, useState } from 'react'
import { AiOutlineCloudUpload } from 'react-icons/ai'
import user from '@/data/profile/user-profile.json'

const MyInformation: React.FC = () => {
  const [firstName, setFirstName] = useState<string>('')
  const [lastName, setLastName] = useState<string>('')
  const [email, setEmail] = useState<string>('')
  const photo: any = useRef(null)
  /**
   * @param event
   * Does something with form data, e.g. submit to a server
   */
  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()
  }
  const handleClick = () => {
    photo.current?.click()
  }
  const handleFileChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const fileObj = event.target.files && event.target.files[0]
    if (!fileObj) {
      return
    }
  }
  return (
    <div>
      <div className="flex flex-col md:flex-row justify-center my-5 py-4 items-center bg-white">
        <span>
          <h2 className={`text-2xl font-bold text-gray-500`}>
            {'Manage Personal Information'}
          </h2>
          <h3 className={`text--.1xl text-gray-400`}>
            {'Add all the required information about yourself'}
          </h3>
        </span>
        <div className="flex-1"></div>
        <button className="text-sm font-semibold text-white bg-primary px-8 py-2 rounded-md float-right">
          {'Save changes'}
        </button>
      </div>
      <form className="mx-auto max-w-full my-10" onSubmit={handleSubmit}>
        <div className="my-10 flex flex-direction-row">
          <label
            htmlFor="text"
            className="mb-2 mr-[13%] font-bold text-gray-700 "
          >
            Name <span className="text-red-500">*</span>
          </label>
          <div className="flex ">
            <input
              type="text"
              id="firstName"
              name="firstName"
              value={firstName}
              onChange={(event) => setFirstName(event.target.value)}
              placeholder={`${user.firstName}`}
              className="flex-grow mr-2 block w-[50%] px-4 py-2 rounded-lg text-secondary-text bg-gray-100 focus:outline-none"
              required
            />
            <input
              type="text"
              id="lastName"
              name="lastName"
              value={lastName}
              onChange={(event) => setLastName(event.target.value)}
              placeholder={`${user.lastName}`}
              className="flex-grow block w-[50%] ml-2 px-4 py-2 rounded-lg text-secondary-text  bg-gray-100 focus:outline-none"
              required
            />
          </div>
        </div>
        <div className="my-10 flex flex-direction-row">
          <label
            htmlFor="email"
            className="block mb-2  mr-[8%] font-bold text-gray-700"
          >
            Email Address <span className="text-red-500">*</span>
          </label>
          <input
            type="email"
            id="email"
            name="email"
            value={email}
            onChange={(event) => setEmail(event.target.value)}
            className="px-4 py-2 w-[35%] rounded-lg bg-gray-100  text-secondary-text focus:outline-none"
            placeholder={`${user.email}`}
            required
          />
        </div>
        <div className="my-10 flex flex-direction-row">
          <label
            htmlFor="photo"
            className="flex mb-2 font-bold mr-[12%] text-gray-700"
          >
            Your Photo <span className="text-red-500">*</span>
          </label>

          <div className="flex">
            <img
              src={`${user.photoUrl}`}
              className="w-16 h-16 bg-gray-300 rounded-full mr-2"
            />
            <div className="block w-600 py-2 flex flex-direction-col justify-center rounded-lg bg-gray-100 border-transparent focus:border-gray-200 text-secondary focus:bg-white focus:ring-0 secondary-text">
              <span>
                <AiOutlineCloudUpload className="ml-[50%]" color="blue" />
                <p className="ml-[5%] text-center text-secondary-text">
                  <b onClick={handleClick}>Click to upload</b> or drag and drop
                  SVG, PNG, JPG, or GIF(max800x400px)
                </p>
              </span>

              <input
                type="file"
                id="photo"
                name="photo"
                accept="image/*"
                ref={photo}
                className="hidden"
                onChange={(event) => {
                  handleFileChange(event)
                }}
                required
              />
            </div>
          </div>
        </div>
      </form>
    </div>
  )
}

export default MyInformation
