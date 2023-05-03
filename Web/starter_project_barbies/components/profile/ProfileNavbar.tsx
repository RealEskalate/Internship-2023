import Link from 'next/link';
import { useRouter } from 'next/router';

const ProfileNavbar = () => {
  const router = useRouter();

  return (

    <nav className='bg-white ml-10'  >
      <h1 className='bg-white text-black pd-12 pt-6 text-2xl ml-8 mb-4'>Profile</h1>
      <ul className='flex bg-white'>

        <li className='text-black ml-8 mr-4 hover:text-red-500'>
          <Link href="/personal-information" className={router.pathname === '/personal-information' ? 'active' : ''}>
            Personal Information
          </Link>
        </li>

        <li className='text-black mr-4 hover:text-red-500'>
          <Link href="/my-blogs" className={router.pathname === '/my-blogs' ? 'active' : ''}>
            My Blogs
          </Link>
        </li>

        <li className='text-black hover:text-red-500'>
          <Link href="/account-setting" className={router.pathname === '/account-setting' ? 'active' : ''}>
            Account Setting
          </Link>
        </li>
      </ul>
    <div className='flex justify-between '>
      <div>
      <h1 className='text-black ml-8 text-base mt-8'>Manage Your Account</h1>
      <h5 className='text-black ml-8 text-xs pt-1 '>You can change your password here.</h5>
      </div>

    <div>
      <button className="bg-blue-700 text-white mr-10 mr-18 py-1 px-2 rounded"> Save Changes</button>
    </div>

    </div>

    </nav>

  );
};

export default ProfileNavbar;