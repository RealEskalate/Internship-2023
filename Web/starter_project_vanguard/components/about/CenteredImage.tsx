import { CenteredImageComponent } from '@/types/about/centered-image'
import Image from 'next/image'
import { title } from 'process'

const CenteredImage: React.FC<CenteredImageComponent> = ({
  image,
}: CenteredImageComponent) => {
  return (
    <div className="mx-10 p-10 my-auto">
      <Image src={image} alt={title} />
    </div>
  )
}

export default CenteredImage
