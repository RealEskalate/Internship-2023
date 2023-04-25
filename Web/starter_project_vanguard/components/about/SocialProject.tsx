import Image from 'next/image'
import SocialProjectDescription from './SocialProjectDescription'

function SocialProject({
  image,
  leftAligned,
  title,
  content,
  isImageLeft,
}: any) {
  return isImageLeft ? (
    <div className="grid sm:grid-cols-1 md:grid-cols-2 gap-10">
      <Image src={image} alt={''}></Image>
      <SocialProjectDescription
        leftAligned={leftAligned}
        title={title}
        content={content}
      />
    </div>
  ) : (
    <div className="grid gap-10 sm:grid-cols-1 md:grid-cols-2">
      <SocialProjectDescription
        leftAligned={leftAligned}
        title={title}
        content={content}
      />
      <Image src={image} alt={''}></Image>
    </div>
  )
}

export default SocialProject
