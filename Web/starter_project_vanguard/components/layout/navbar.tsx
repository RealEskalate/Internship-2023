import clsx from 'clsx'
import Image from 'next/image'
import Link from 'next/link'
import { useRouter } from 'next/router'

import logo from '../../public/images/a2sv-logo.png'
import { NavItem } from '@/types/nav'

const navItems: NavItem[] = [
  { name: 'Home', href: '/' },
  { name: 'Teams', href: '/team' },
  { name: 'Success Stories', href: '/story' },
  { name: 'About Us', href: '/about' },
  { name: 'Get Involved', href: '/get-involved' },
]

const Navbar = () => {
  const router = useRouter()
  const currSegment = router.pathname.split('/')[1] || ''

  return (
    <div className="sticky top-0 bg-white bg-opacity-100 flex justify-between font-montserrat p-10">
      <Link href="/">
        <Image src={logo} alt="A2SV Logo" />
      </Link>
      <div className="flex gap-4">
        {navItems.map((navItem, index) => (
          <Link
            href={navItem.href}
            key={index}
            className={clsx(
              'font-semibold',
              currSegment === navItem.href.split('/')[1]
                ? 'border-b-4 border-primary text-primary'
                : 'text-tertiary-text'
            )}
          >
            {navItem.name}
          </Link>
        ))}
      </div>
      <div className="flex gap-4">
        <button className="bg-primary text-white rounded-md w-[78px] h-[36px]">
          Donate
        </button>
      </div>
    </div>
  )
}

export default Navbar
