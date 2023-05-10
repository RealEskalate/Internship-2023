import Image, { ImageProps } from "next/image"

const TeamsHero: React.FC = () => {
    const images: ImageProps[] = [{src: "/img/teams/team-work/team-work-1.png", alt:"", className:'contain absolute top-0 left-0 w-[35%]' ,width:322,height:316.7}, {src: "/img/teams/team-work/team-work-2.png", alt:"", className: 'contain absolute top-0 right-0 w-[35%]', width:322,height:316.7}, {src:"/img/teams/team-work/team-work-3.png",alt:"",width:322,height:316.7, className:'contain absolute bottom-0 left-0 w-[35%]'}, {src:"/img/teams/hero-background.png", alt:"", className: "",width:800,height:710.7}]
    return (
        <div>
            <div className="grid md:grid-cols-1 lg:grid-cols-2 p-8">
                <div className="flex flex-col p-8 m-2">
                    <h1 className="font-bold text-black text-5xl my-4 uppercase m-2">
                        The team we’re currently
                        working with
                    </h1>
                    <p className="text-2xl text-black m-2">Meet our development team is a small but highly skilled and experienced group of professionals. We have a talented mix of web developers, software engineers, project managers and quality assurance specialists who are passionate about developing exceptional products and services.</p>
                </div>
                
                <div className=" w-[85%] md:w-[85%] lg:w-[100%] relative p-8 m-auto">
                    {images.map((image, index) => <Image key={index} src={image.src} alt={image.alt} width={image.width} height={image.height} className={image.className}/>)}
                    
                    <div className="absolute top-[30%] left-[30%] flex flex-col flex flex-col font-bold xs:text-3xl sm:text-4xl leading-10 text-black uppercase h-[40%] justify-evenly items-left">

                        <span> <span className="text-primary">Team</span>  work</span>
                        <span> Collaboration </span>
                        <span> <span className="text-primary">hard</span>  work</span>
                    </div>
                </div>
            </div>
            <div className="flex justify-around"><hr className='my-4 mx-4 w-[80%] color-black'></hr></div> 
        </div>
    )
}

export default TeamsHero