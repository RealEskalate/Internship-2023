import { SerializedError } from '@reduxjs/toolkit'
import { FetchBaseQueryError } from '@reduxjs/toolkit/dist/query'
import React from 'react'
interface ErrorProps{
    error: string
}

const Error: React.FC<ErrorProps> = ({error}) => {
  return (
    <div
      className="bg-red-100 border border-danger text-danger px-4 py-3 rounded relative text-center"
      role="alert"
    >
      <strong className="font-bold capitalize">
        {error}
      </strong>
    </div>
  )
}

export default Error