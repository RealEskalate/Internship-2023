import Image from 'next/image'
import {
  AiFillLinkedin,
  AiFillYoutube,
  AiOutlineInstagram,
  AiOutlineTwitter,
} from 'react-icons/ai'
import { MdCopyright, MdOutlineFacebook } from 'react-icons/md'

interface NavBlock {
  header: string
  links: NavItem[]
}

const Footer: React.FC = () => {
  const navigation: NavBlock[] = [
    {
      header: 'Links',
      links: [
        { name: 'Home', to: '/' },
        {
          name: 'Success Stories',
          to: '/stories',
        },
        { name: 'About Us', to: '/about/about' },
        {
          name: 'Get Involved',
          to: '/get-involved',
        },
      ],
    },
    {
      header: 'Teams',
      links: [
        { name: 'Board Members', to: '/board' },
        {
          name: 'Advisors/Mentors',
          to: '/advisors',
        },
        { name: 'Executives', to: '/executives' },
        {
          name: 'Staffs',
          to: '/staff',
        },
      ],
    },
    {
      header: 'Blogs',
      links: [
        { name: 'Recent Blogs', to: '/recent-blogs' },
        {
          name: 'New Blog',
          to: '/new-blog',
        },
      ],
    },
  ]

  return (
    <section className="bg-white flex flex-col gap-y-4 p-4 text-xl md:text-2xl md:p-10">
      <div className="flex flex-col xl:flex-row items-center justify-between gap-4">
        <div className="w-30 lg:w-60 ">
          <Image
            src="/img/footer/helping-a-partner.jpg"
            alt="helping-a-partner"
            width={240}
            height={180}
          />
        </div>

        <div className="flex flex-col items-center gap-4">
          <p className="font-bold ">
            Get involved in improving tech education in Africa!
          </p>
          <button className="bg-blue-700 w-40 p-3 text-white font-bold rounded-2xl xl:self-start">
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
          <AiOutlineTwitter href="https://twitter.com/A2_SV" target="_blank" />
          <MdOutlineFacebook
            href="https://www.facebook.com/profile.php?id=100085473798621"
            target="_blank"
          />
          <AiFillYoutube
            href="https://www.youtube.com/channel/UC70kFW6mFFGEjsucvNZk6-A"
            target="_blank"
          />
          <AiFillLinkedin
            href="https://www.linkedin.com/company/a2sv/mycompany/"
            target="_blank"
          />
          <AiOutlineInstagram
            href="https://www.instagram.com/a2sv_org"
            target="_blank"
          />
        </div>
      </div>
    </section>
  )
}

export default Footer
