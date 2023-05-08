import { ImageTextStackComponent } from '@/types/about/image-text-stack-component'
import Image from 'next/image'

const ImageTextStack: React.FC<ImageTextStackComponent> = ({
  image,
  title,
}: ImageTextStackComponent) => {
  return (
    <div className="relative overflow-hidden rounded-lg shadow-lg cursor-pointer bg-aboutbackground ">
      <Image className="object-cover w-full h-48" src={image} alt={title} />
      <div className="absolute top-0 left-0 px-6 py-4 text-center w-[100%]">
        <h4 className="mt-10 pt-6 text-xl font-semibold text-white">{title}</h4>
      </div>
    </div>
  )
}

export default ImageTextStack
