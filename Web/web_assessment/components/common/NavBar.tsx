import Image from "next/image"
import { IoIosArrowDown} from 'react-icons/all'

type Props = {}

const NavBar = (props: Props) => {
  return (
    <div className="fixed top-0 w-full">
      <div className="flex justify-between max-w-6xl">
        <div className="relative w-48 h-48">
          <Image className="rounded-full" src='/profile.jpeg' fill={true} alt="profile picture"/>
        </div>
        <div>
          <div>Jonathan Alemayehu</div>
          <IoIosArrowDown />
        </div>
      </div>
      
    </div>
  )
}

export default NavBar