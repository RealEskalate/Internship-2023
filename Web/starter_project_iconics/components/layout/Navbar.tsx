import { navData } from '@/data/layout/navbar/nav-data'
import Image from 'next/image'
import { useRouter } from 'next/router'
import { useEffect, useState } from 'react'
import { MdOutlineClose, MdViewHeadline } from 'react-icons/md'

function classNames(...classes: string[]) {
  return classes.filter(Boolean).join(' ')
}

const Navbar: React.FC = () => {
  const [navigation, setNavigation] = useState(() => navData)

  const { asPath } = useRouter()
  const [showNav, setShowNav] = useState(false)

  useEffect(() => {
    setNavigation(
      navigation.map((item) => {
        if (item.to === asPath) {
          return { ...item, current: true }
        } else {
          return { ...item, current: false }
        }
      })
    )
  }, [asPath, navigation])

  return (
    <div className="bg-white flex justify-between p-5">
      <div className="w-28 lg:w-52">
        <Image src="/a2sv-logo.png" alt="a2sv-logo" width={200} height={50} />
      </div>

      <div className="w-3/4 absolute -right-0 mr-4 flex flex-col gap-y-4 md:ml-0 md:flex-row  md:static justify-between">
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
            {navigation.map(({ name, to, current }, index) => (
              <li key={index}>
                <a
                  href={to}
                  id={index.toString()}
                  className={classNames(
                    current
                      ? 'text-blue-700 underline underline-offset-8 decoration-4'
                      : 'no-underline text-gray-900',
                    'font-semibold text-base lg:text-xl'
                  )}
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

export default Navbar
