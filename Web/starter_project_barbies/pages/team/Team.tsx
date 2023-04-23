import React from 'react'
import TeamsImage from '../../public/teams_page_img.svg'
import Image from 'next/image'
import TeamMemberCard from "@/components/team/TeamMemberCard";
import { TeamMemberCardProps } from "@/types/team/TeamMemberCardProps";

const DummyDataGenerator = (): TeamMemberCardProps[] => {
  const data:TeamMemberCardProps[] = []
  for (let i = 0; i < 10; i++) {
    data.push({
      name: 'John Doe',
      jobTitle: 'Software Engineer',
      description:
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam ac suscipit nisl. Nullam euismod, purus vel maximus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam ac suscipit nisl. Nullam euismod, purus vel maximus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam ac suscipit nisl. Nullam euismod, purus vel maximus.',
      image: 'https://picsum.photos/200',
      links: [
        {
          type: 'facebook',
          url: 'https://www.facebook.com/',
        },
        {
          type: 'linkedin',
          url: 'https://www.linkedin.com/',
        },
        {
          type: 'instagram',
          url: 'https://www.instagram.com/',
        }
      ]
    })
  }
  return data
}

const Team = () => {
  return (
    <div className="px-12 my-8 md:px-20 lg:px-28">
      <div className="flex flex-col md:flex-row">
        <div className="w-full md:w-2/5">
          <h1 className="text-5xl text-gray-700 font-extrabold lg:leading-snug my-8 md:text-3xl lg:text-5xl">
            THE TEAM WE&apos;RE CURRENTLY WORKING WITH
          </h1>
          <p className="text-base md:text-sm lg:text-base lg:leading-7 text-gray-400 font-light">
            Meet our development team is a small but highly skilled and
            experienced group of professionals. We have a talented mix of web
            developers, software engineers, project managers and quality
            assurance specialists who are passionate about developing
            exceptional products and services.
          </p>
        </div>
        <div className="w-0 md:w-3/5 my-8">
          <Image src={TeamsImage} alt="placeholder" />
        </div>
      </div>

      <hr className="h-0.5 border-t-0 bg-neutral-100 opacity-100 dark:opacity-100 block w-5/6 my-8 m-auto" />

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
        {DummyDataGenerator().map((data, index) => (
          <TeamMemberCard key={index} name={data.name} jobTitle={data.jobTitle} description={data.description} image={data.image} links={data.links} />
        ))}
      </div>
    </div>
  )
}

export default Team
