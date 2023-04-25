import Link from 'next/link'
import empowered from './img/empowered.png'
import Image from 'next/image'
import { linkItems } from './links/navigationLink'
import { socialMedialinks } from './links/socialMediaLinks'

const Footer: React.FC = () => {
  return (
    <footer className="mt-auto border-y border-text-secondary sm:px-6 px-12">
      <div className="sm:flex justify-between items-center space-y-12 sm:space-y-0 divide-y divide-y-reverse sm:py-12 py-3 sm:divide-y-0  sm:space-x-12">
        <div className="pb-8 sm:pt-0 basis-1/5 hidden lg:block">
          <Link href="/">
            <Image src={empowered} alt="inpowered logo" />
          </Link>
        </div>

        <div className="pb-8 sm:pt-0 basis-1/3 ">
          <h3 className="text-lg font-semibold my-6">
            Get involved in improving tech education in Africa!
          </h3>
          <button className="bg-primary text-white rounded-md w-[190px] h-[45px]">
            Support us
          </button>
        </div>
        {linkItems.map((linkItem, index) => {
          return (
            <div key={index} className="pb-8 sm:pt-0 basis-1/5 self-start">
              <h3 className="text-lg font-semibold mb-6">{linkItem.title}</h3>
              <ul className="flex flex-col text-secondary-text space-y-4">
                {linkItem.links.map((navItem, index) => (
                  <li key={index}>
                    <Link href={navItem.path}>{navItem.name}</Link>
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
          {socialMedialinks.map((socialMediaLink, index) => {
            return (
              <Link key={index} href={socialMediaLink.url} target="_blank">
                {socialMediaLink.icon}
              </Link>
            )
          })}
        </div>
      </div>
    </footer>
  )
}

export default Footer
