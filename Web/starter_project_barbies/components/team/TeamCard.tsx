import React from 'react'
import { BsFacebook, BsLinkedin, BsInstagram } from 'react-icons/bs'
import Image from "next/image";

type TeamCardProps = {
  name: string
  jobTitle: string
  description: string
  image: string
  facebook: string
  linkedin: string
  instagram: string
}

const TeamCard = ({
  name,
  jobTitle,
  description,
  image,
  facebook,
  linkedin,
  instagram,
}: TeamCardProps) => {
  return (
    <div className="team-card box-content font-sans w-72 m-4 text-center shadow-md shadow-gray-200 rounded-md py-2">
      <div className="team-card__image container overflow-hidden my-4">
        <Image className="rounded-full mx-auto w-32" width={200} height={200} src={image} alt={name} />
      </div>

      <div className="team-card__content m-4">
        <h3 className="team-card__name text-2xl m-3 font-extrabold tracking-widest">
          {name}
        </h3>
        <p className="team-card__job-title m-3 tracking-widest text-base">
          {jobTitle}
        </p>
        <p className="team-card__description text-sm mt-5 mb-3 text-gray-400 font-light px-4 tracking-wide">
          {description}
        </p>
      </div>

      <hr className="h-0.5 border-t-0 bg-neutral-100 opacity-100 dark:opacity-50 inline-block ms-auto w-5/6" />

      <div className="team-card__social flex-row mt-3">
        <div className="team-card__social__icon inline-block w-1/3">
          <a
            className="inline-block"
            href={facebook}
            target="_blank"
            rel="noreferrer"
          >
            <BsFacebook className="fill-gray-400 w-6 h-6" />
          </a>
        </div>

        <div className="team-card__social__icon inline-block w-1/3">
          <a
            className="inline-block"
            href={linkedin}
            target="_blank"
            rel="noreferrer"
          >
            <BsLinkedin className="fill-gray-400 w-6 h-6" />
          </a>
        </div>

        <div className="team-card__social__icon inline-block w-1/3">
          <a
            className="inline-block"
            href={instagram}
            target="_blank"
            rel="noreferrer"
          >
            <BsInstagram className="fill-gray-400 w-6 h-6" />
          </a>
        </div>
      </div>
    </div>
  )
}

export default TeamCard
