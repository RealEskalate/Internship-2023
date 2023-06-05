import Image from 'next/image';
import Link from 'next/link'
const Navigation : React.FC = () => {
    return (
        <div className='flex'>
            <Link href={"/doctor"} className='w-1/3'>
                <Image src='/image/HakimHub.png' alt={''} width={180} height={60}/>
            </Link>
            <div className='flex flex-wrap w-1/3 justify-center'>
            <Link className='font-bold m-4' href={''}>Home</Link>
            <Link className='font-bold m-4' href={''}>Hospitals</Link>
            <Link className='font-bold m-4' href={''}>Doctors</Link>
            </div>
            <div className='w-1/3 flex justify-end '>
                <div className='rounded-full text-3xl font-bold bg-gray-600 w-12 h-12 m-3 flex flex-wrap justify-center self-center'>
                    <div className='self-center text-white'>
                        K
                    </div>
                </div>
                <div className='self-center flex'>
                
                <div className='rounded-full border-2 border-gray-500  pl-2 pr-2'>
                   Logout
                </div>
                </div>
            </div>
        </div>
    )
}

export default Navigation;