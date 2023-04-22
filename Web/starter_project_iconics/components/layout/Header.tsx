import Image from 'next/image'
import { useState } from 'react'
import { MdOutlineClose, MdViewHeadline } from 'react-icons/md'
import logo from '../../public/a2sv-logo.png'

function classNames(...classes: string[]) {
  return classes.filter(Boolean).join(' ')
}

const Header = () => {
  const [navigation, setNavigation] = useState(() => [
    { id: 0, name: 'Home', to: '/', current: true },
    { id: 1, name: 'Teams', to: '/team/teams', current: false },
    {
      id: 2,
      name: 'Success Stories',
      to: '/Success_story/success_stories',
      current: false,
    },
    { id: 3, name: 'About Us', to: '/about/about', current: false },
    { id: 4, name: 'Blogs', to: '/blog/blogs', current: false },
    {
      id: 5,
      name: 'Get Involved',
      to: '/get_involved/get_involved',
      current: false,
    },
  ])

  const [showNav, setShowNav] = useState(false)

  const handleNavClick = (e: React.FormEvent) => {
    let id = parseInt((e.target as HTMLAnchorElement).id)

    setNavigation(
      navigation.map((item) => {
        if (item.id == id) {
          return { ...item, current: true }
        } else {
          return { ...item, current: false }
        }
      })
    )
  }

  return (
    <div className="bg-white flex justify-between p-5">
      <div className="w-28 lg:w-52">
        <Image
          src={logo}
          alt="a2sv-logo"
          width={200}
          height={50}
          className="object-cover"
        />
      </div>

      <div className="w-3/4 flex flex-col gap-y-4  md:ml-0 md:flex-row justify-between">
        {showNav ? (
          <MdOutlineClose
            className="block w-10 h-10 p-2 md:hidden ml-auto"
            onClick={() => {
              setShowNav(!showNav)
            }}
          />
        ) : (
          <MdViewHeadline
            className="block w-10 h-10 p-2 md:hidden ml-auto"
            onClick={() => {
              setShowNav(!showNav)
            }}
          />
        )}

        <nav
          className={classNames(
            showNav ? 'flex' : 'hidden',
            'md:flex ml-auto md:ml-0 md:w-3/4'
          )}
        >
          <ul className="flex flex-col gap-5 content-between md:flex-row md:w-full justify-between">
            {navigation.map(({ id, name, to, current }) => (
              <li key={id}>
                <a
                  href={to}
                  id={id.toString()}
                  className={classNames(
                    current
                      ? 'text-blue-700 underline underline-offset-8 decoration-4'
                      : 'no-underline text-gray-900',
                    'font-semibold text-base lg:text-xl'
                  )}
                  onClick={(e: React.FormEvent) => handleNavClick(e)}
                >
                  {name}
                </a>
              </li>
            ))}
          </ul>
        </nav>

        <div
          className={classNames(
            showNav ? 'flex' : 'hidden',
            'ml-auto md:ml-0 md:flex gap-4 text-sm lg:text-lg'
          )}
        >
          <button className="font-bold m-4 md:m-0">Login</button>
          <button className="bg-blue-700 text-white font-bold px-3 rounded-2xl">
            Donate
          </button>
        </div>
      </div>
    </div>
  )
}

export default Header
