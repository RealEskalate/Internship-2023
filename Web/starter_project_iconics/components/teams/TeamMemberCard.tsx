import { TeamMember } from '@/types/teams';
import Image from 'next/image';
import {
  BsEmojiSmileUpsideDown,
  BsFacebook,
  BsInstagram,
  BsLinkedin,
} from 'react-icons/bs';

export interface TeamMemberCardProps {
  teamMember : TeamMember
}

const SocialMediaIcon: { [index: string]: any } = {
  facebook: <BsFacebook className="fill-gray-400 w-8 h-8" />,
  linkedin: <BsLinkedin className="fill-gray-400 w-8 h-8" />,
  instagram: <BsInstagram className="fill-gray-400 w-8 h-8" />,
  default: <BsEmojiSmileUpsideDown className="fill-gray-400 w-8 h-8" />,
}

const TeamMemberCard: React.FC<TeamMemberCardProps> = ({teamMember}) => {
  const {name, job, avatar, description, socialMedia} = teamMember
  return (
    <div className="flex flex-col self-start bg-white rounded-lg p-6 m-2 items-center justify-center shadow-xl max-w-[500px]">
      <Image
        className="rounded-full w-32 h-32 mt-2 bg-gray-200 object-contain"
        src={avatar}
        alt="avatar"
        width={178}
        height={178}
      ></Image>

      <h1 className="font-bold uppercase text-black text-2xl m-3">{name}</h1>
      <h2 className="uppercase text-black text-xl">{job}</h2>
      <p className="text-center my-4 text-xl text-[#7D7D7D]">{description}</p>
      <hr className="my-6 w-[100%]"></hr>

      <div className="flex justify-around w-[100%]">
        {socialMedia &&
          socialMedia.map((social, index) => (
            <a href={social.link} key={index}>
              {' '}
              {SocialMediaIcon[social.type] || SocialMediaIcon['default']}
            </a>
          ))}
      </div>
    </div>
  )
}

export default TeamMemberCard
