import React from 'react';
import Image from 'next/image';
import ProfileNavbar from './ProfileNavbar';

export const PersonalInformation = () => {
    return (
      <div className='text-left'>

          <ProfileNavbar/>

        <div className="flex flex-row h-screen ">   
         <main className="flex-grow bg-white p-8">
          <form className="w-96 ml-10">
            <div className="mb-4 flex ">

             <div className='mr-8 text-black'> Name</div>

              <div className="w-1/2 pr-2">

                <label className="block text-gray-600 font-bold mb-2" htmlFor="first_name"/>
              
                <input
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                id="first_name"
                type="text"
                placeholder=""
                required
                />
              </div>

              <div className="w-1/2 pl-2">
                <label className="block text-gray-700 font-bold mb-2" htmlFor="last_name"/>
                <input
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    id="last_name"
                    type="text"
                    placeholder=""
                    required
                />
              </div>
            </div>

            <div>
                <div className=" flex mb-12 mt-12">
                <p className='text-black'> Email Address</p>
                    
                        <label className="block text-gray-700 font-bold mb-2" htmlFor="email"/>

                        <input
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="email"
                        type="email"
                        placeholder="Enter your email address"
                        required
                        />
                </div>
            </div>

        <div className="flex items-center justify-center w-full ">
          <p className='mr-8 text-black'>Your Photo</p>

            <label htmlFor="image" className="block text-gray-700 font-bold mb-2 mr-4">
                <div className="w-12 h-12 rounded-full overflow-hidden border-2 border-gray-400 hover:border-gray-500 focus:border-blue-500">
                <Image height={50} width={50} className="w-full h-full object-cover" src="/img/profile-information/profile-girl.png" alt="Image placeholder"/>
                </div>
            </label>

            <input type="file" id="image" name="image" className="hidden required"/>


        <label htmlFor="dropzone-file" className="flex flex-col items-center justify-center w-80 h-30 py-6 px-10 border-2 border-slate-50 border-dashed rounded-lg cursor-pointer bg-white dark:hover:bg-gray-400 dark:bg-white hover:bg-gray-100 dark:border-gray-600 dark:hover:border-gray-500 dark:hover:bg-gray-600">
          
          <div className="flex flex-col items-center justify-center ">
              <svg aria-hidden="true" className="w-10 h-10 mb-3 text-black " fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M7 16a4 4 0 01-.88-7.903A5 5 0 1115.9 6L16 6a5 5 0 011 9.9M15 13l-3-3m0 0l-3 3m3-3v12"></path></svg>
              <p className="mb-2 text-sm text-black dark:text-black "><span className="font-semibold">Click to upload</span> or drag and drop</p>
              <p className="text-xs text-black  dark:text-black ">SVG, PNG, JPG or GIF (MAX. 800x400px)</p>
          </div>

          <input id="dropzone-file" type="file" className="hidden" />
          
      </label>
     </div> 
   </form>
  </main>
 </div>
</div>
)}
  
  export default PersonalInformation;