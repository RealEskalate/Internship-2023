import Image from 'next/image'

import { SocialProjectDescriptionProp } from '@/types/about/social-project-description-prop'
import githubIcon from '../../public/images/aboutus/icons/github.svg'
import shareIcon from '../../public/images/aboutus/icons/share.svg'

function SocialProjectDescription({
  leftAligned,
  title,
  content,
}: SocialProjectDescriptionProp) {
  return (
    <div className={`${leftAligned ? 'text-left' : 'text-right'}`}>
      <p className="font-extralight text-[#1E3A8A]">Social Project</p>
      <p className="text-primary font-bold text-2xl">{title}</p>
      <p className="pt-4">{content}</p>
      <div
        className={`${leftAligned ? 'justify-start' : 'justify-end'} flex mt-3`}
      >
        <Image src={githubIcon} className="w-[30px]" alt={'github icon'} />
        <div className="w-[10px]"></div>
        <Image src={shareIcon} className="w-[30px]" alt={'share icon'} />
      </div>
    </div>
  )
}

export default SocialProjectDescription
