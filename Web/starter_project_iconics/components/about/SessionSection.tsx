import Image from "next/image"
const SessionSection = () => {
    return (
        <div className = "session-section grid grid-cols-2 p-12	bg-white font-poppins text-black lg">
            <div className="col img-col flex justify-center items-center">
            <Image  src = "/about/img/amicopuzzle.png" alt = "amicopuzzle" width = {600} height = {563.46}  />
    </div>

    <div className= "col p-2.5 lg">
        <h1 className="font-poppins text-5xl"> <div>How we are <span className = "text-blue-800">solving it</span></div> </h1>
        <Image  className = " py-2.5" src = "/about/img/info iconicon3.png" alt = "info iconicon3" width = {80} height = {80}  />
        <p className="font-poppins font-light text-2xl">Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere.</p>
    </div>
</div>
    )
}

export default SessionSection