import React from 'react'

interface TagProps {
  tags: string[]
}

export const Tags: React.FC<TagProps> = ({ tags }) => {
  return (
    <div className="flex flex-wrap justify-start items-end">
      {tags.map((tag, index) => (
        <button
          key={index}
          className="btn btn-outline btn-pill flex mr-2 mb-2 mx-4 mt-5 px-4 py-2 "
        >
          <i>
            <span className="text-lg font-semibold  text-gray-500">{tag}</span>
          </i>
        </button>
      ))}
    </div>
  )
}
