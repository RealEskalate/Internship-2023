import Link from 'next/link'
import { FaFacebook, FaInstagram, FaLinkedin, FaTwitter, FaYoutube} from 'react-icons/fa'
import inpowered from '../../public/images/inpowered.png'
import Image from 'next/image'
import { NavItem } from '@/types/nav'

const navLinks: NavItem[] = [
  { name: 'Home', href: '/' },
  { name: 'Success Stories', href: '/story' },
  { name: 'About Us', href: '/about' },
  { name: 'Get Involved', href: '/get-involved' },
]

const navTeams: NavItem[] = [
  { name: 'Board Members', href: '/board' },
  { name: 'Advisors/Mentors', href: '/advisors' },
  { name: 'Executives', href: '/executives' },
  { name: 'Staffs', href: '/staffs' },
]

const navBlogs: NavItem[] = [
  { name: 'Recent Blogs', href: '/recent-blogs' },
  { name: 'New Blog', href: '/new-blog' },
]

const Footer: React.FC = () => {
  return (
    <footer className="mt-auto border-y border-text-secondary px-12">
      <div className="flex justify-between py-12 items-center space-x-12">
        <div className="basis-1/5">
          <Link href="/">
            <Image src={inpowered} alt="inpowered logo" />
          </Link>
        </div>

        <div className="basis-1/3">
          <h3 className="text-lg font-semibold my-6">
            Get involved in improving tech education in Africa!
          </h3>
          <button className="bg-primary text-white rounded-md w-[190px] h-[45px]">
            Support us
          </button>
        </div>
        <div className="basis-1/5 self-start">
          <h3 className="text-lg font-semibold mb-6">Links</h3>
          <ul className="flex flex-col text-secondary-text space-y-4">
            {navLinks.map((navItem, index) => (
              <li key={index}>
                <Link href={navItem.href}>{navItem.name}</Link>
              </li>
            ))}
          </ul>
        </div>

        <div className="basis-1/5 self-start">
          <h3 className="text-lg font-semibold mb-6">Teams</h3>
          <ul className="flex flex-col text-secondary-text space-y-4">
            {navTeams.map((navItem, index) => (
              <li key={index}>
                <Link href={navItem.href}>{navItem.name}</Link>
              </li>
            ))}
          </ul>
        </div>

        <div className="basis-1/5 self-start">
          <h3 className="text-lg font-semibold mb-6">Blogs</h3>
          <ul className="flex flex-col text-secondary-text space-y-4">
            {navBlogs.map((navBlog, index) => (
              <li key={index}>
                <Link href={navBlog.href}>{navBlog.name}</Link>
              </li>
            ))}
          </ul>
        </div>
      </div>

      <div className="border-t border-neutral-200 flex justify-between py-8">
        <p className="text-sm text-secondary-text">
          <span className="text-xl px-1">&copy;</span> 2020 Africa to Silicon
          Valley,Inc. All right reserved.
        </p>

        <div className="text-secondary-text flex align-middle space-x-6 text-xl">
            <Link href="https://twitter.com/A2_SV" target="_blank"> 
                <FaTwitter/> 
            </Link>

            <Link href="https://www.facebook.com/profile.php?id=100085473798621" target="_blank"> 
                <FaFacebook/> 
            </Link>

            <Link href="https://www.youtube.com/channel/UC70kFW6mFFGEjsucvNZk6-A" target="_blank"> 
                <FaYoutube/> 
            </Link>

            <Link href="https://www.linkedin.com/company/a2sv/mycompany/" target="_blank"> 
                <FaLinkedin/> 
            </Link>

            <Link href="https://www.instagram.com/a2sv_org" target="_blank"> 
                <FaInstagram/> 
            </Link>

        </div>

      </div>
    </footer>
  )
}

export default Footer
