import React from 'react'

const Error: React.FC = () => {
  return (
    <div
      className="bg-red-100 border border-danger text-danger px-4 py-3 rounded relative text-center"
      role="alert"
    >
      <strong className="font-bold capitalize">
        Requested resource not found!
      </strong>
    </div>
  )
}

export default Error
