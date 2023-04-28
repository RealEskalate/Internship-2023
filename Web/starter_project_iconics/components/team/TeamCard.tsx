import Image from 'next/image'
import {
  BsEmojiSmileUpsideDown,
  BsFacebook,
  BsInstagram,
  BsLinkedin,
} from 'react-icons/bs'
type social = { type: string; link: string }
export interface TeamCardProps {
  name: string
  job: string
  description: string
  avatar: string
  socialMedia: social[]
}

const SocialMediaIcon: { [index: string]: any } = {
  facebook: <BsFacebook className="fill-gray-400 w-8 h-8" />,
  linkedin: <BsLinkedin className="fill-gray-400 w-8 h-8" />,
  instagram: <BsInstagram className="fill-gray-400 w-8 h-8" />,
  default: <BsEmojiSmileUpsideDown className="fill-gray-400 w-8 h-8" />,
}

function TeamCard({
  name,
  job,
  description,
  avatar,
  socialMedia,
}: TeamCardProps) {
  return (
    <div className="flex flex-col bg-white rounded-lg p-6 m-2 items-center justify-center shadow-xl max-w-sm">
      <Image
        className="rounded-full w-32 h-32 mt-2 object-cover"
        src={avatar}
        alt="avatar"
      ></Image>
      <h1 className="font-bold uppercase text-black text-2xl m-3">{name}</h1>
      <h2 className="uppercase text-black text-xl">{job}</h2>
      <p className="text-center my-4 text-xl text-[#7D7D7D]">{description}</p>
      <hr className="my-6 w-[100%] "></hr>

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

export default TeamCard
