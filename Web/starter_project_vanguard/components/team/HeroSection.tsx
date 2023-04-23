import Image from "next/image"

const HeroSection = () => {
  return (
    <div className="flex mx-10">
        <div className="basis-2/5 ">
            <h1 className="uppercase font-bold text-5xl text-primary-text flex flex-col gap-4"><span>The team we're</span>  <span>currently</span> <span>working with</span> </h1>
            <p className="text-secondary-text mt-8 text-xl">Meet our development team is a small but highly skilled and experienced group of professionals. We have a talented mix of web developers, software engineers, project managers and quality assurance specialists who are passionate about developing exceptional products and services.</p>
        </div>
        <div className=" relative basis-3/5 p-40 flex flex-col gap-4 bg-center bg-no-repeat bg-contain text-primary-text" style={{backgroundImage: 'url("/images/teams-hero-section/teams-hero-background.png")'}}>
          <Image className=" md:absolute right-24 -top-6" width={230} height={250} src={'/images/teams-hero-section/teams-hero-image-1.png'} alt={"hero image"}/>
          <Image className="absolute -top-8 left-14 " width={230} height={250} src={'/images/teams-hero-section/teams-hero-image-2.png'} alt={"hero-image-2"}/>
          <h1 className="uppercase font-bold text-5xl ml-24"><span className=" text-primary">Team</span>  work</h1>
          <h1 className="uppercase font-bold text-5xl ml-24">collaboration</h1>
          <h1 className="uppercase font-bold text-5xl mx-24 "><span className=" text-primary">Hard</span> work</h1>
          <Image className="absolute left-24 -bottom-20" width={230} height={250} src={'/images/teams-hero-section/teams-hero-image-3.png'} alt={"hero-image-3"}/>
        </div>
        

    </div>
  )
}

export default HeroSection