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
    <div className="grid grid-cols-2 gap-10">
      <Image src={image} alt={''}></Image>
      <SocialProjectDescription
        leftAligned={leftAligned}
        title={title}
        content={content}
      />
    </div>
  ) : (
    <div className="grid grid-cols-2 gap-10">
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
