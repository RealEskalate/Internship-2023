import Image from "next/image"


const AboutSection:React.FC = () => {
    return (

<div >
<div className='about-section grid grid-cols-2 lg md:flex-row md:w-full justify-between'>

    <div className='col p-12'>
        <h1 className="font-extrabold  text-5xl "><div> <span className = "text-primary"> Africa </span> to Silicon Valley</div></h1>
        <p className="font-sans-serif font-normal text-2xl py-12">A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>

        <button className="flex flex-row items-center justify-center font-medium text-2xl rounded bg-primary text-blue-100 hover:bg-blue-600 duration-300 gap-3 p-4">
             <>Meet our team</>
        </button>

        <p className="font-sans text-2xl py-12	 italic font-light">A2SV is a social enterprise that enables high-potential university students to create digital solutions to Africa’s most pressing problems.</p>
    </div>

    <div className = "col img-col grid grid-rows-2 justify-center gap-6 lg py-12 px-12 lg">
    <div className= "col img-col grid justify-center gap-6 grid-cols-2 lg ">
        <div className = "relative lg">
        <Image src = "/img/about/about-section/rectangle-1.png" alt = "img1" width = {388} height = {276}/>
        <div className="absolute bottom-2/3 top-1/4 left-1/4 right-2/3 text-white text-center p-2">
        The education process
        </div>
        </div>

        <div className="relative lg ">
        <Image src = "/img/about/about-section/rectangle-2.png" alt = "img2" width = {388} height = {276}/>
        <div className="absolute bottom-2/3 top-1/3 left-1/3 right-2/3 text-white text-center p-2">
        Development phase
        </div> 
        </div>
    </div>

        <div className = "relative lg">
        <Image src = "/img/about/about-section/rectangle-3.png" alt = "img3" width={800} height={212}/>
        <div className="absolute bottom-1/4 top-1/4 left-1/4 right-1/4 text-white text-center p-2">
        20% percent growth
        </div>   
        </div>

    </div>

</div>
</div>

)
}

export default AboutSection