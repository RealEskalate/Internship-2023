import { CenteredImageComponentProp } from '@/types/about/centered-image-prop'
import Image from 'next/image'
import { title } from 'process'

function CenteredImage({ image }: CenteredImageComponentProp) {
  return (
    <div className="mx-10 p-10 my-auto">
      <Image src={image} alt={title}></Image>
    </div>
  )
}

export default CenteredImage
