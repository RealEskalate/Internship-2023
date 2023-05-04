import React from "react";
import Link from "next/link";
import Image from "next/image";


const Footer = () => {
  return (
    <footer className="bg-white border-black p-4 mr-16">
      <div className="flex justify-between mt-4">

      <div className="flex items-center">

      <Image src="/img/footerpic.png" alt="Footer Logo" height={150} width={150} className="h-10  text-stone-950 mr-12" />

      <div>

        <h3 className="text-stone-950"> Get Involved in improving tech </h3>
        <h3 className="mb-4 text-stone-950">education in africa!</h3>
        <button className="bg-blue-500 text-white px-4 py-2 rounded"> Support Us </button>

      </div>
      </div>


        <div>
          <h3 className="text-lg font-bold mb-4 text-stone-950">Links</h3>

          <ul >
            <li className="mb-4">
              <Link href="/about" className=" text-stone-950 hover:text-blue-500 pd-6 "> Home </Link>
            </li>

            <li className="mb-4">
            <Link href="/success-stories" className="text-stone-950 hover:text-blue-500"> Success Stories </Link>
            </li>

            <li className="mb-4">
            <Link href="/about-us" className="text-stone-950 hover:text-blue-500"> About Us</Link>
            </li>

            <li className="mb-4">
            <Link href="/get-involved" className="text-stone-950 hover:text-blue-500"> Get Involved</Link>
            </li>
          </ul>
        </div>


        <div>
          <h3 className="text-lg font-bold text-stone-950  mb-4">Teams</h3>

          <ul>
            <li className="mb-4">
            <Link href="/board-members" className="text-stone-950 hover:text-blue-500"> Board Members</Link>
            </li>

            <li className="mb-4">
            <Link href="/advisors-mentors" className="text-stone-950 hover:text-blue-500"> Advisors Mentors</Link>
            </li>

            <li className="mb-4">
            <Link href="/executives" className="text-stone-950 hover:text-blue-500"> Executives</Link>
            </li>
            
            <li className="mb-4">
            <Link href="/staffs" className="text-stone-950 hover:text-blue-500"> Staffs</Link>
            </li>
          </ul>
        </div>


        <div>
          <h3 className="text-lg font-bold mb-4 text-stone-950">Blog</h3>

          <ul>
            <li className="mb-4">
            <Link href="/recent-blogs" className="text-stone-950 hover:text-blue-500 "> Recent Blogs</Link>
            </li>

            <li className="mb-4">
            <Link href="/new-blog" className="text-stone-950 hover:text-blue-500"> New Blog</Link>
            </li>

          </ul>
        </div>
        </div>

{/* Footer Coyright  */}
        <div className="sm:flex sm:items-center sm:justify-between">
          <span className="text-sm text-black sm:text-center dark:text-black">©  <a href="https://flowbite.com/" className="hover:underline">2020 Africa To silicon Valley.Inc</a>. All Rights Reserved.
          </span>
          <div className="flex mt-4 space-x-6 pr-4 pb-6 pt-2 sm:justify-center sm:mt-0">

              <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
                  <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true"><path  /></svg>
                  <span className="sr-only">Twitter page</span>
              </Link>

              <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
                  <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true"><path fill-rule="evenodd"  clip-rule="evenodd" /></svg>
                  <span className="sr-only">Facebook page</span>
              </Link>

              <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
                  <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true"><path fill-rule="evenodd"  clip-rule="evenodd" /></svg>
                  <span className="sr-only">Instagram page</span>
              </Link>
             
              <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
                  <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true"><path fill-rule="evenodd"  clip-rule="evenodd" /></svg>
                  <span className="sr-only">GitHub account</span>
              </Link>

              <Link href="#" className="text-blackhover:text-gray-900 dark:hover:text-white">
                  <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true"><path fill-rule="evenodd" clip-rule="evenodd" /></svg>
                  <span className="sr-only">Dribbble account</span>
              </Link>

          </div>
          </div>

     
    </footer>
  );
};

export default Footer;