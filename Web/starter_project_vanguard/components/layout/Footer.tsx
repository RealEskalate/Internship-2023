import Link from 'next/link'
import empowered from 'public/img/footer/empowered.png'
import {
  FaFacebook,
  FaInstagram,
  FaLinkedin,
  FaTwitter,
  FaYoutube,
} from 'react-icons/fa'
import { LinkItem } from '@/types/footer-navigation'
import Image from 'next/image'

const Footer: React.FC = () => {
  const linkItems: LinkItem[] = [
    {
      title: 'Links',
      links: [
        { name: 'Home', path: '/' },
        { name: 'Success Stories', path: '/story' },
        { name: 'About Us', path: '/about' },
        { name: 'Get Involved', path: '/get-involved' },
      ],
    },
    {
      title: 'Teams',
      links: [
        { name: 'Board Members', path: '/board' },
        { name: 'Advisors/Mentors', path: '/advisors' },
        { name: 'Executives', path: '/executives' },
        { name: 'Staffs', path: '/staffs' },
      ],
    },
    {
      title: 'Blogs',
      links: [
        { name: 'Recent Blogs', path: '/recent-blogs' },
        { name: 'New Blog', path: '/new-blog' },
      ],
    },
  ]

  const socialMedialinks = [
    {
      icon: FaTwitter,
      url: 'https://twitter.com/A2_SV',
    },
    {
      icon: FaFacebook,
      url: 'https://www.facebook.com/profile.php?id=100085473798621',
    },
    {
      icon: FaYoutube,
      url: 'https://www.youtube.com/channel/UC70kFW6mFFGEjsucvNZk6-A',
    },
    {
      icon: FaLinkedin,
      url: 'https://www.linkedin.com/company/a2sv/mycompany/',
    },
    {
      icon: FaInstagram,
      url: 'https://www.instagram.com/a2sv_org',
    },
  ]

  return (
    <footer className="mt-auto border-y border-text-secondary sm:px-6 px-12">
      <div className="px-6 sm:flex justify-between items-center space-y-12 sm:space-y-0 divide-y divide-y-reverse sm:py-12 py-3 sm:divide-y-0 sm:space-x-12">
        <div className="pb-8 sm:pb-0 basis-1/5 hidden lg:block">
          <Link href="/">
            <Image src={empowered} alt="empowered logo" />
          </Link>
        </div>

        <div className="pb-8 sm:pt-0 basis-1/3 ">
          <h3 className="text-lg font-semibold my-6">
            Get involved in improving tech education in Africa!
          </h3>
          <button className="btn btn-lg">Support us</button>
        </div>

        {linkItems.map((linkItem, index) => {
          return (
            <div key={index} className="sm:pt-0 basis-1/5 self-start">
              <h3 className="font-semibold mb-6">{linkItem.title}</h3>
              <ul className="flex flex-col text-secondary-text space-y-4">
                {linkItem.links.map(({ path, name }, index) => (
                  <li key={index}>
                    <Link href={path}>{name}</Link>
                  </li>
                ))}
              </ul>
            </div>
          )
        })}
      </div>

      <div className="md:border-t border-neutral-200 sm:flex mx-auto md:justify-between py-8">
        <p className="text-sm text-secondary-text py-4 sm:py-0 ">
          <span className="text-xl px-1">&copy;</span> 2023 Africa to Silicon
          Valley,Inc. All right reserved.
        </p>

        <div className="text-secondary-text flex align-middle justify-center space-x-6 text-xl">
          {socialMedialinks.map(({ icon: Icon, url }, index) => {
            return (
              <Link key={index} href={url} target="_blank">
                {<Icon />}
              </Link>
            )
          })}
        </div>
      </div>
    </footer>
  )
}

export default Footer
