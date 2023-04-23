import React from 'react'
import { BsFacebook, BsLinkedin, BsInstagram } from 'react-icons/bs';
import Image from "next/image";
import { TeamMemberCardProps } from "@/types/teams";

const TeamMemberCard = ({
  teamMember
}: TeamMemberCardProps) => {
  return (
    <div className="team-card box-content font-sans w-72 mt-4 text-center shadow-md shadow-gray-200 rounded-md py-2 m-auto">
      <div className="team-card__image container overflow-hidden my-4">
        <Image className="rounded-full mx-auto w-32" width={200} height={200} src={teamMember.image} alt={teamMember.name} />
      </div>

      <div className="team-card__content m-4">
        <h3 className="team-card__name text-2xl m-3 font-extrabold tracking-widest uppercase">
          {teamMember.name}
        </h3>
        <p className="team-card__job-title m-3 tracking-widest text-base uppercase">
          {teamMember.jobTitle}
        </p>
        <p className="team-card__description text-sm mt-5 mb-3 text-gray-400 font-light px-4 tracking-wide">
          {teamMember.description}
        </p>
      </div>

      <hr className="h-0.5 border-t-0 bg-neutral-100 opacity-100 dark:opacity-50 block m-auto w-5/6" />

      <div className="team-card__social flex-row mt-3">
        {teamMember.links && teamMember.links.map((link, index) => (
        <div key={index} className="team-card__social__icon inline-block w-1/3">
          <a
            className="inline-block"
            href={link.url}
            target="_blank"
            rel="noreferrer"
          >
            {link.type === 'facebook' && <BsFacebook className="fill-gray-400 w-6 h-6" />}
            {link.type === 'linkedin' && <BsLinkedin className="fill-gray-400 w-6 h-6" />}
            {link.type === 'instagram' && <BsInstagram className="fill-gray-400 w-6 h-6" />}
          </a>
        </div>
        )
        )}
      </div>
    </div>
  )
}

export default TeamMemberCard
