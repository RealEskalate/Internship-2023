
import Image from "next/image"
const AboutSection = () => {
    return (

<div >
<div className='about-section grid grid-cols-2 lg'>

    <div className='col'>
        <h1 className="font-extrabold  text-5xl p-12"><div> <span className = "text-blue-800"> Africa </span> to Silicon Valley</div></h1>
        <p className="font-sans font-normal text-2xl p-12">A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
        <div className='button pl-12'>Meet our Team</div>
        <p className="font-sans text-2xl p-12 italic font-light">A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
    </div>
    
    <div className= "col img-col grid justify-center gap-6 grid-cols-[400px_400] grid-cols-2 py-12 lg ">

       
        <div className = "container img1">
        <Image src = "/about/img/Rectangle 1 (2).png" alt = "amicosolve" width = {388} height = {276}/>
        </div>

        <div className='container img2 lg'>
        <Image src = "/about/img/Rectangle 2 (2).png" alt = "img2" width = {388} height = {276}/>
    
        </div>
  

        <div className = "container img3 ">
        <Image src = "/about/img/Rectangle 3 (2).png" alt = "img3" width={800} height={212}/>
       
        </div>
    </div>

    
</div>
</div>
    
)
}

export default AboutSection