import Image from 'next/image'
import {
  AiFillLinkedin,
  AiFillYoutube,
  AiOutlineInstagram,
  AiOutlineTwitter,
} from 'react-icons/ai'
import { MdCopyright, MdOutlineFacebook } from 'react-icons/md'

const Footer: React.FC = () => {
  const navigation = [
    {
      id: 1,
      header: 'Links',
      links: [
        { id: 1, name: 'Home', to: '/' },
        {
          id: 2,
          name: 'Success Stories',
          to: '/stories',
        },
        { id: 3, name: 'About Us', to: '/about/about' },
        {
          id: 4,
          name: 'Get Involved',
          to: '/get-involved',
        },
      ],
    },
    {
      id: 2,
      header: 'Teams',
      links: [
        { id: 1, name: 'Board Members', to: '/board' },
        {
          id: 2,
          name: 'Advisors/Mentors',
          to: '/advisors',
        },
        { id: 3, name: 'Executives', to: '/executives' },
        {
          id: 4,
          name: 'Staffs',
          to: '/staff',
        },
      ],
    },
    {
      id: 3,
      header: 'Blogs',
      links: [
        { id: 1, name: 'Recent Blogs', to: '/recent-blogs' },
        {
          id: 2,
          name: 'Blogs',
          to: '/blogs',
        },
      ],
    },
  ]

  return (
    <section className="bg-white flex flex-col gap-y-4 p-4 text-xl md:text-2xl md:p-10">
      <div className="flex flex-col xl:flex-row items-center justify-between gap-4">
        <div className="w-30 lg:w-60 ">
          <Image
            src="/helping-a-partner-rafiki.svg"
            alt="helping-a-partner"
            width={240}
            height={180}
            className="object-cover"
          />
        </div>

        <div className="flex flex-col items-center gap-4">
          <p className="font-bold ">
            Get involved in improving tech education in Africa!
          </p>
          <button className="bg-blue-700 w-40 p-3 text-white font-bold rounded-2xl">
            Support Us
          </button>
        </div>

        <div className="w-full 2xl:w-2/3 flex flex-wrap justify-between lg:justify-evenly">
          {navigation.map((nav_item, index1) => (
            <div
              className="flex flex-col items-center gap-y-6 m-10"
              key={index1 + 1}
            >
              <h1 className="text-2xl self-start">{nav_item.header}</h1>
              <ul className="flex flex-col self-start gap-y-4">
                {nav_item.links.map((link_item, index2) => (
                  <li
                    key={parseInt(
                      (index1 + 1).toString() + (index2 + 1).toString()
                    )}
                  >
                    <a className="font-light" href={link_item.name}>
                      {link_item.name}
                    </a>
                  </li>
                ))}
              </ul>
            </div>
          ))}
        </div>
      </div>
      <div className="flex flex-col items-center gap-y-4 md:flex-row justify-between text-gray-500">
        <p>
          <MdCopyright className="inline mr-2" />
          2020 Africa to Silicon Valley, Inc. All right reserved.
        </p>
        <div className="flex gap-4 text-2xl md:text-4xl ">
          <AiOutlineTwitter />
          <MdOutlineFacebook />
          <AiFillYoutube />
          <AiFillLinkedin />
          <AiOutlineInstagram />
        </div>
      </div>
    </section>
  )
}

export default Footer
