import clsx from 'clsx'
import { Montserrat } from 'next/font/google'
import Image from 'next/image'
import Link from 'next/link'
import { navItems } from '@/utils/NavItems'
import { useRouter } from 'next/router'

import logo from '../../public/logo.png'

const montserrat = Montserrat({ subsets: ['latin'] })

const Navbar = () => {
  const router = useRouter()

  const currSegment = router.pathname.split('/')[1] || ''

  return (
    <div className={montserrat.className}>
      <div className="flex justify-between">
        <Link href="/">
          <Image src={logo} className="" alt="A2SV Logo" />
        </Link>
        <div className="flex gap-4 mt-2">
          {navItems.map((navItem, index) => (
            <Link
              href={navItem.href}
              key={index}
              className={clsx(
                'font-semibold ',
                currSegment === navItem.href.split('/')[1]
                  ? 'border-b-4 border-primary text-primary'
                  : 'text-navColor'
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
    </div>
  )
}

export default Navbar
