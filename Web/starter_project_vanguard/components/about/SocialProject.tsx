import { SocialProjectComponent } from '@/types/about/social-project-component'
import Image from 'next/image'
import React from 'react'
import SocialProjectDescription from './SocialProjectDescription'

const SocialProject: React.FC<SocialProjectComponent> = ({
  image,
  leftAligned,
  title,
  content,
  isImageLeft,
}: SocialProjectComponent) => {
  return isImageLeft ? (
    <div className="grid sm:grid-cols-1 md:grid-cols-2 gap-10">
      <Image
        src={`/img/about/${image}`}
        width={1}
        height={1}
        className="w-[100%] h-[100%]"
        alt={title}
      ></Image>
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
      <Image
        src={`/img/about/${image}`}
        width={1}
        height={1}
        className="w-[100%] h-[100%]"
        alt={title}
      ></Image>
    </div>
  )
}

export default SocialProject
