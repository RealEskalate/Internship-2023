import Image from "next/image"
import Link from "next/link"
import React from "react"

type SocialMedia = {url: "", social:""}

interface MemberCardProps {
    name: string,
    picture: string,
    role: string,
    description: string,
    links: SocialMedia[]
}
const MemberCard: React.FC<MemberCardProps> = ( {name, picture, role, description, links}) => {
  return (
    <div className="bg-white rounded-md drop-shadow-xl py-6 px-6 max-w-sm ">
        <Image className="rounded-full m-auto text-center" width={120} height={120} src={picture} alt={name} />
        <h2 className="font-bold mt-4 uppercase text-2xl text-center text-primary-text">{name}</h2>
        <h5  className="font-medium uppercase text-center text-primary-text">{role}</h5>
        <p className="text-center text-secondary-text my-3">{description}</p>
        <hr className="border mt-7 mb-3" />
        <div className="flex justify-around">
          {
            links.map((link:SocialMedia, idx: number) => {
              return(
              <Link key={idx} href={link.url} target="_blank">
                <Image className="" width={27} height={27} src={`/images/member-card/${link.social}.svg`} alt={link.social} />
              </Link>)
            })
          }
        </div>

    </div>
  )
}

export default MemberCard