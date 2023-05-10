import Image from "next/image"
const SocialProjectsSections = () => {
  return (
    <>
<h1 className="social-section-title p-12 lg"> <div className="font-poppins text-6xl justify-items-center content-center"> Social <span className = "text-primary">Projects </span></div></h1>

<div className="social-project-section grid grid-cols-2 p-12 lg">
   <div className="col img-col">
   <Image src = "/img/about/socialproject-section/rectangle-4.png" alt = "Rectangle 4" height={400} width={800} />
</div>

<div className="col right">
   <h3> <div className="font-poppins text-1xl text-primary text-sm text-right pl-12 lg">Social Project</div></h3>
   <h2> <div className="font-poppins text-3xl text-primary text-right pl-12	lg"> Hakim Hub</div></h2>
   <p className="font-sans text-2xl font-light">HakimHub is a platform that provides information about healthcare facilities and healthcare professionals in Ethiopia. Hakimhub makes information about hospitals, medical laboratories, and doctors conveniently accessible to its users.</p>
</div>

<div className="col left">
   <h3> <div className="font-poppins text-1xl text-primary text-sm lg">Social Project</div></h3>
   <h2> <div className="font-poppins text-3xl text-primary lg">Track Sym</div></h2>
   <p className="font-sans text-2xl font-light lg">TrackSym is a non-commercial app that uses crowd-sourcing to collect and visualize the density of the relevant Covid-19 symptoms. Symptom data, aggregated by places, can help people avoid visiting areas that are heavily populated by symptomatic people.</p>
   </div>
   <div className="col img-col lg">
   <Image src = "/img/about/socialproject-section/rectangle-5.png" alt = "rectangle_5" height={400} width={800}  />
   </div>
</div>
   <div>
   <h1 className="font-extrabold text-5xl justify-center items-center content-center	 p-12"><div> A2SV <span className = "text-primary">Sessions </span></div></h1>
</div>
    </>
  )
}


export default SocialProjectsSections