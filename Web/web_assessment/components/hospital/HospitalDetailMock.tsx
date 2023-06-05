import Image from 'next/image'
import { IsOpen } from '../common/IsOpen'

export const MockDetail: React.FC = () =>{
    return (
        <div className='p-44 pt-0'>
            <div>
                <Image src='/image/background.png' alt={''} width={1500} height={400} className='rounded-lg'/>
            </div>
      <div className='font-extrabold text-4xl mb-3 mt-3'>Black Lion Hospital</div>
      
      <div className='flex flex-wrap mb-8'>
        <div className=''><IsOpen isopen={'close'} /> </div>
        <div className='bg-blue-200 rounded-full pl-4 pr-4 pt-1 pb-1 flex justify-center self-center ml-4'> Available 24 Hours</div>
      </div>
      <div className='mb-20'>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Nobis dolore
        maiores, natus ducimus, harum tempore quaerat veritatis minima molestiae
        maxime labore vel quasi. Et fuga perspiciatis veritatis quidem, voluptas
        accusamus animi ipsa autem! A amet dolore quod vel eos quos, numquam est
        consequuntur possimus repudiandae dignissimos, nobis culpa similique
        optio.
      </div>
      <div>
        <div className='mb-6 font-bold text-xl'>Services</div>
        <div className="flex flex-wrap mb-20">
          <div className='w-1/3 '>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
          </div>
          <div className='w-1/3 justify-center'>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
            <li>Lorem, ipsum.</li>
          </div>
        </div>
      </div>
      <div className="border-2 border-black p-10 pt-2 pl-2">
        <div className='font-bold text-xl mb-4'>Contact Details</div>
        <div className="flex flex-wrap">
          <div>
            <div>
              <div>Main Office</div>
              <div>phone 1</div>
              <div>phone 2</div>
            </div>
            <div>
              <div>Main Office</div>
              <div>phone 1</div>
              <div>phone 2</div>
            </div>
          </div>
          <div>
            <div>
              <div>Main Office</div>
              <div>phone 1</div>
              <div>phone 2</div>
            </div>
            <div>
              <div>Main Office</div>
              <div>phone 1</div>
              <div>phone 2</div>
            </div>
          </div>
        </div>
      </div>
    </div>
    )
}