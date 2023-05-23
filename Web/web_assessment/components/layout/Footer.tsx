// import Link from 'next/link'
// import empowered from 'public/img/footer/empowered.png'
// import {
//   FaFacebook,
//   FaInstagram,
//   FaLinkedin,
//   FaTwitter,
//   FaYoutube,
// } from 'react-icons/fa'
// import { LinkItem } from '@/types/footer-navigation'

// const Footer: React.FC = () => {
//   const linkItems: LinkItem[] = [
//     {
//       title: 'Links',
//       links: [
//         { name: 'Doctors', path: '/' },
//         { name: 'Detail', path: '/doctor-detail' },
//       ],
//     },
//       ]

//   return (
//     <footer className="mt-auto border-y border-text-secondary sm:px-6 px-12">
//       <div className="px-6 sm:flex justify-between items-center space-y-12 sm:space-y-0 divide-y divide-y-reverse sm:py-12 py-3 sm:divide-y-0 sm:space-x-12">
        


//         {linkItems.map((linkItem, index) => {
//           return (
//             <div key={index} className="sm:pt-0 basis-1/5 self-start">
//               <h3 className="font-semibold mb-6">{linkItem.title}</h3>
//               <ul className="flex flex-col text-secondary-text space-y-4">
//                 {linkItem.links.map(({ path, name }, index) => (
//                   <li key={index}>
//                     <Link href={path}>{name}</Link>
//                   </li>
//                 ))}
//               </ul>
//             </div>
//           )
//         })}
//       </div>

//       <div className="md:border-t border-neutral-200 sm:flex mx-auto md:justify-between py-8">
        

//         {/* <div className="text-secondary-text flex align-middle justify-center space-x-6 text-xl">
//           {socialMedialinks.map(({ icon: Icon, url }, index) => {
//             return (
//               <Link key={index} href={url} target="_blank">
//                 {<Icon />}
//               </Link>
//             )
//           })}
//         </div> */}
//       </div>
//     </footer>
//   )
// }

// export default Footer
