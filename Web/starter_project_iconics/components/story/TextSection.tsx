import React from 'react'

interface TextSectionProps  {
  heading : string,
  paragraph : string
}

const TextSection: React.FC<TextSectionProps> = ({heading,paragraph}) => {
  return(
    <div className="m-8 max-w-3xl font-montserrat">
      <h2 className="text-2xl font-semibold mb-4 mt-2">{heading}</h2>
      <p className="italic text-sm mt-2">{paragraph}</p>
    </div>
  )
}

export default TextSection
