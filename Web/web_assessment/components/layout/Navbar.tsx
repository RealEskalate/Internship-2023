// import { navItems } from '@/data/layout/nav-items'
// import clsx from 'clsx'
// import Image from 'next/image'
// import Link from 'next/link'
// import { useState } from 'react'
// import { AiOutlineMenu } from 'react-icons/ai'
// import logo from '../../public/img/a2sv-logo.png'

// const Navbar: React.FC = () => {
//   return (
//     <div className="sticky top-0 z-50 bg-white bg-opacity-100 flex justify-between px-10 pt-5">
     
//      na
//       </div>

//       <div className="hidden md:flex float-right gap-4">
//         <button className="btn btn-md my-auto">Donate</button>
//       </div>
//       <div
//         className="md:hidden flex flex-col "
//         onClick={() => setToggle(!toggle)}
//       >
//         <AiOutlineMenu className="w-7 h-7 cursor-pointer" />
//         <div
//           className={`${
//             !toggle ? 'hidden' : 'flex'
//           } flex-col gap-4 p-6 black-gradient absolute top-12 right-2 mx-4 my-2 min-w-[140px] rounded-xl
//           z-50 bg-gray-100 bg-opacity-100
//           `}
//         >
//           {navItems.map((navItem, index) => (
//             <Link
//               href={navItem.href}
//               key={index}
//               className={clsx(
//                 'font-semibold',
//                 active === navItem.href
//                   ? 'border-b-4 border-primary text-primary'
//                   : 'text-tertiary-text'
//               )}
//               onClick={() => setActiveAndToggle(navItem.href)}
//             >
//               {navItem.name}
//             </Link>
//           ))}
//           <button className="btn btn-md">Donate</button>
//         </div>
//       </div>
//     </div>
//   )
// }

// export default Navbar
