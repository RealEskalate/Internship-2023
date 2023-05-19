import { ImageParagraphComponent } from '@/types/about/image-paragraph-component'
import Image from 'next/image'
import React from 'react'

const ImagePragraph: React.FC<ImageParagraphComponent> = ({
  image,
  text,
}: ImageParagraphComponent) => {
  return (
    <div className="py-7">
      <Image src={image} alt={text} className="w-[10%]" />
      <p className="pt-5">{text}</p>
    </div>
  )
}

export default ImagePragraph
