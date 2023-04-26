import clsx from 'clsx'
import Image from 'next/image'
import Link from 'next/link'
import { useRouter } from 'next/router'
import { AiOutlineMenu } from 'react-icons/ai'

import { NavItem } from '@/types/nav'
import { useState } from 'react'
import logo from '../../public/img/a2sv-logo.png'

const navItems: NavItem[] = [
  { name: 'Home', href: '/' },
  { name: 'Teams', href: '/teams' },
  { name: 'Success Stories', href: '/successs-story' },
  { name: 'About Us', href: '/about' },
  { name: 'Get Involved', href: '/get-involved' },
]
const Navbar = () => {
  const router = useRouter()
  const currSegment = router.pathname.split('/')[1] || ''
  const [toggle, setToggle] = useState(false)

  return (
    <div className="sticky top-0 z-50 bg-white bg-opacity-100 flex justify-between font-montserrat px-10 pt-5">
      <Link href="/">
        <Image src={logo} alt="A2SV Logo" className="h-12 w-25  " />
      </Link>
      <div className="hidden md:flex gap-4">
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

      <div className="hidden md:flex float-right gap-4">
        <button className="bg-primary text-white rounded-md w-[78px] h-[36px] md:float-right">
          Donate
        </button>
      </div>
      <div
        className="md:hidden flex flex-col "
        onClick={() => setToggle(!toggle)}
      >
        <AiOutlineMenu className="w-7 h-7 cursor-pointer" />
        <div
          className={`${
            !toggle ? 'hidden' : 'flex'
          } flex-col gap-4 p-6 black-gradient absolute top-20 right-2 mx-4 my-2 min-w-[140px] rounded-xl
          z-50 bg-gray-100 bg-opacity-100
          `}
        >
          {' '}
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
              onClick={() => setToggle(!toggle)}
            >
              {navItem.name}
            </Link>
          ))}
          <button className="bg-primary text-white rounded-md w-[78px] h-[36px] md:float-right">
            Donate
          </button>
        </div>
      </div>
    </div>
  )
}

export default Navbar
