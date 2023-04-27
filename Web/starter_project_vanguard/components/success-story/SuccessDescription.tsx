import { Story } from '@/types/success-story'
import React from 'react'

interface SuccessDescriptionProps {
  successDescription: Story
}

const SuccessDescription: React.FC<SuccessDescriptionProps> = ({
  successDescription,
}) => {
  return (
    <div className="md:m-8 max-w-3xl">
      <h1 className="font-montserrat text-xl md:text-2xl font-semibold mb-4">
        {successDescription.heading}
      </h1>
      <p className="font-montserrat italic text-sm">
        {successDescription.paragraph}
      </p>
    </div>
  )
}

export default SuccessDescription
