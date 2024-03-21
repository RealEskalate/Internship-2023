import { TeamMember } from '@/types/teams'
import Image from 'next/image'
import Link from 'next/link'
import React from 'react'
import { FaFacebook, FaInstagram, FaLinkedin, FaNetworkWired } from 'react-icons/fa'
import { IconContext } from 'react-icons/lib'

interface MemberCardProps {
  member: TeamMember
}
const MemberCard: React.FC<MemberCardProps> = ({ member }) => {
  const socialMediaIcons = {
      facebook: <FaFacebook />,
      linkedin: <FaLinkedin />,
      instagram: <FaInstagram />,
      default: <FaNetworkWired />
      }

  return (
    <div className="bg-white rounded-md drop-shadow-xl py-6 px-6 ">
      <Image
        className="rounded-full m-auto text-center"
        width={120}
        height={120}
        src={member.photoUrl}
        alt={member.name}
      />
      <h2 className="font-bold mt-4 uppercase text-xl lg:text-2xl text-center text-primary-text">
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
              <IconContext.Provider value={{ size: '27px', color:'grey' }} >
                {socialMediaIcons[link.social as keyof typeof socialMediaIcons] || socialMediaIcons.default}
              </IconContext.Provider>
            </Link>
          )
        })}
      </div>
    </div>
  )
}

export default MemberCard
