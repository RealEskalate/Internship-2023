import { Member } from '@/types/teams'
import Image from 'next/image'
import Link from 'next/link'
import React from 'react'
import { FaFacebook, FaInstagram, FaLinkedin } from 'react-icons/fa'
import { IconContext } from 'react-icons/lib'

interface MemberCardProps {
  member: Member
}
const MemberCard: React.FC<MemberCardProps> = ({ member }) => {
  let social_icon_map = new Map<string, JSX.Element>()
  social_icon_map.set('facebook', <FaFacebook />)
  social_icon_map.set('linkedin', <FaLinkedin />)
  social_icon_map.set('instagram', <FaInstagram />)

  return (
    <div className="bg-white rounded-md drop-shadow-xl py-6 px-6 max-w-sm ">
      <Image
        className="rounded-full m-auto text-center"
        width={120}
        height={120}
        src={member.photoUrl}
        alt={member.name}
      />
      <h2 className="font-bold mt-4 uppercase text-2xl text-center text-primary-text">
        {member.name}
      </h2>
      <h5 className="font-medium uppercase text-center text-primary-text">
        {member.role}
      </h5>
      <p className="text-center text-secondary-text my-3">
        {member.description}
      </p>
      <hr className="border mt-7 mb-3" />
      <div className="flex justify-around">
        {member.links.map((link, idx: number) => {
          return (
            <Link key={idx} href={link.url} target="_blank">
              <IconContext.Provider value={{ color: '#717171', size: '27px' }}>
                {social_icon_map.get(link.social)}
              </IconContext.Provider>
            </Link>
          )
        })}
      </div>
    </div>
  )
}

export default MemberCard
