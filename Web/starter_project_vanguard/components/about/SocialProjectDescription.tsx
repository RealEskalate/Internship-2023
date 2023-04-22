import Image from 'next/image'

import githubIcon from '../../public/aboutus/github.svg'
import shareIcon from '../../public/aboutus/share.svg'

function SocialProjectDescription({ leftAligned, title, content }: any) {
  return (
    <div className={`${leftAligned ? 'text-left' : 'text-right'}`}>
      <p className="font-extralight text-[#1E3A8A]">Social Project</p>
      <p className="text-[#264FAD] font-bold text-2xl">{title}</p>
      <p className="pt-4">{content}</p>
      <div className="flex justify-end mt-3">
        <Image src={githubIcon} className="w-[30px]" alt={''}></Image>
        <div className="w-[10px]"></div>
        <Image src={shareIcon} className="w-[30px]" alt={''}></Image>
      </div>
    </div>
  )
}

export default SocialProjectDescription
