import React from 'react'
import { BsFacebook, BsLinkedin, BsInstagram, BsEmojiSmileUpsideDown } from 'react-icons/bs';
import Image from "next/image";
import { TeamMember } from "@/types/team";

export type TeamMemberCardProps = {
  teamMember: TeamMember
}

const SocialMediaIcon: {[index: string]:any} = {
  "facebook": <BsFacebook className="fill-gray-400 w-6 h-6" />,
  "linkedin": <BsLinkedin className="fill-gray-400 w-6 h-6" />,
  "instagram": <BsInstagram className="fill-gray-400 w-6 h-6" />,
  "default": <BsEmojiSmileUpsideDown className="fill-gray-400 w-6 h-6" />
}

const TeamMemberCard: React.FC<TeamMemberCardProps> = ({
  teamMember
}: TeamMemberCardProps) => {
  return (
    <div className="box-content font-sans w-72 mt-4 text-center shadow-md shadow-gray-200 rounded-md py-2 m-auto">
      <div className="container overflow-hidden my-4">
        <Image className="rounded-full mx-auto w-32" width={200} height={200} src={teamMember.profileImg} alt={teamMember.name} />
      </div>

      <div className="m-4">
        <h3 className="text-2xl m-3 font-extrabold tracking-widest uppercase">
          {teamMember.name}
        </h3>
        <p className="m-3 tracking-widest text-base uppercase">
          {teamMember.jobTitle}
        </p>
        <p className="text-sm mt-5 mb-3 text-gray-400 font-light px-4 tracking-wide">
          {teamMember.description}
        </p>
      </div>

      <hr className="h-0.5 border-t-0 bg-neutral-100 opacity-100 dark:opacity-50 block m-auto w-5/6" />

      <div className="flex-row mt-3">
        {teamMember.socialMediaLinks && teamMember.socialMediaLinks.map((link, index) => (
        <div key={index} className="team-card__social__icon inline-block w-1/3">
          <a
            className="inline-block"
            href={link.url}
            target="_blank"
            rel="noreferrer"
          >
            {SocialMediaIcon[link.type] || SocialMediaIcon["default"]}
          </a>
        </div>
        )
        )}
      </div>
    </div>
  )
}

export default TeamMemberCard
