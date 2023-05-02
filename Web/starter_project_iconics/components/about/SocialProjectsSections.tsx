
import Image from "next/image"
const SocialProjectsSections = () => {
  return (
    <>
<h1 className="social-section-title p-12 items-center justify-centerexit
 lg"> <div className="font-poppins text-6xl"> Social <span className = "text-blue-800">Projects </span></div></h1>

<div className="social-project-section grid grid-cols-2 p-12 lg">
   <div className="col img-col">
   <Image src = "/about/img/Rectangle 4(2).png" alt = "Rectangle 4" height={400} width={800} />
</div>

<div className="col right">
   <h3> <div className="font-poppins text-1xl text-blue-800 text-sm text-right pl-12 lg">Social Project</div></h3>
   <h2> <div className="font-poppins text-3xl text-blue-800 text-right pl-12	"> Hakim Hub</div></h2>
   <p className="font-poppins font-light text-2xl">HakimHub is a platform that provides information about healthcare facilities and healthcare professionals in Ethiopia. Hakimhub makes information about hospitals, medical laboratories, and doctors conveniently accessible to its users.</p>
</div>
<div className="col left">

   <h3> <div className="font-poppins text-1xl text-blue-800 text-sm lg">Social Project</div></h3>
   <h2> <div className="font-poppins text-3xl text-blue-800">Track Sym</div></h2>
   <p className="font-poppins font-light text-2xl">TrackSym is a non-commercial app that uses crowd-sourcing to collect and visualize the density of the relevant Covid-19 symptoms. Symptom data, aggregated by places, can help people avoid visiting areas that are heavily populated by symptomatic people.</p>
</div>

   <div className="col img-col lg">
   <Image src = "/about/img/Rectangle 5(2).png" alt = "Rectangle 5" height={400} width={800}  />

</div>
</div>
    </>
  )
}


export default SocialProjectsSections