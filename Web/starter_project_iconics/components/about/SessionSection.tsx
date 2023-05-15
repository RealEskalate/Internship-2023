import Image from "next/image"
const SessionSection:React.FC  = () => {
    return (
        <div className = "session-section grid grid-cols-2 p-12 font-poppins lg">
            <div className="col img-col flex justify-center items-center">
            <Image  src = "/img/about/session-section/amico-puzzle.png" alt = "amicopuzzle" width = {600} height = {563.46}  />
    </div>

    <div className= "col p-2.5 lg">
        <h1 className="font-poppins text-5xl"> <div>How we are <span className = "text-primary">solving it</span></div> </h1>
        <Image  className = " py-2.5" src = "/img/about/session-section/light-bulb-icon-3.png" alt = "info iconicon3" width = {80} height = {80}  />
        <p className="font-poppins text-2xl font-light">Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere.</p>
    </div>
</div>
    )
}

export default SessionSection