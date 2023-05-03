import { ImageParagraphComponentProp } from '@/types/about/image-paragraph-component-prop'
import Image from 'next/image'

function ImagePragraph({ image, text }: ImageParagraphComponentProp) {
  return (
    <div className="py-7">
      <Image src={image} alt={text} className="w-[10%]"></Image>
      <p className="pt-5">{text}</p>
    </div>
  )
}

export default ImagePragraph
