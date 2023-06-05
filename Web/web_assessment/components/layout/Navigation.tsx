import Image from 'next/image';
import Link from 'next/link'
const Navigation : React.FC = () => {
    return (
        <div className='flex'>
            <Link href={"/doctor"} className='w-1/3'>
                <Image src='/image/HakimHub.png' alt={''} width={180} height={60}/>
            </Link>
            <div className='flex flex-wrap w-1/3 justify-center'>
            <Link className='font-bold m-1' href={''}>Home</Link>
            <Link className='font-bold m-1' href={''}>Hospitals</Link>
            <Link className='font-bold m-1' href={''}>Doctors</Link>
            </div>
            <div className='w-1/3 flex justify-end '>
                <div>
                    <Image src='/image/profile.png' alt={''} width={50} height={50}/>
                </div>
                <div className='self-center flex'>
                <div className='p-1'>
                    Name
                </div>
                <div className='p-1'>
                    --
                </div>
                </div>
            </div>
        </div>
    )
}

export default Navigation;