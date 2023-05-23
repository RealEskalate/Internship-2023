import Image from "next/image"
import { IoIosArrowDown} from 'react-icons/io'

type Props = {}

const NavBar = (props: Props) => {
  return (
    <div className="fixed top-0 w-full h-24 bg-white z-10">
      <div className="flex justify-between ">
        <div className="relative w-24 h-24">
          <Image className="rounded-full" src='/hakimhub-logo.svg' fill={true} alt="logo"/>
        </div>
        <div className="flex items-center gap-2">
          <div className="relative w-12 h-12">
            <Image className="rounded-full" src='/profile.jpeg' fill={true} alt="profile picture"/>
          </div>
          <div>Jonathan Alemayehu</div>
          <IoIosArrowDown />
        </div>
      </div>
      
    </div>
  )
}

export default NavBar