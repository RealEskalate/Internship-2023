import React from 'react'
import Image from 'next/image'


const FileUpload = () => {
  return (
    <div className="w-full mb-16 h-1/2   lg:h-2/3  mt-8 bg-gray-100 rounded-lg flex items-center justify-center flex-col p-2 lg:p-5">

      <Image src='/images/illustration.jpg' alt="illustration image" width={200} height={200}/>

      <div className="flex flex-wrap flex-row gap-2 items-center mt-3">

        <p>Please,</p>
        <label htmlFor="upload-file" className="bg-white text-gray rounded-md px-4 py-2 hover:bg-gray-200">
          Upload File
          <input id="upload-file" type="file" className="sr-only" />
        </label>
        <p>Or choose file from</p>
        <label htmlFor="my-files" className="bg-white text-gray rounded-md px-4 py-2 hover:bg-gray-200">
          My Files
          <input id="my-files" type="file" className="sr-only" />
        </label>

      </div>
      
    </div>
  )
}

export default FileUpload