import Image from "next/image"

const ProblemSection = () => {
    return (
        <div className='problem-section grid grid-cols-2 p-12 bg-white font-poppins text-black lg'>
            <div className = "col p-2.5">
            <h1 className="font-extrabold text-5xl p-5"><div> The Problem We <span className = "text-blue-800">Are Solving </span></div></h1>
            <Image  className = " py-2.5" src = "/about/img/info iconicon1.png" alt = "info iconicon1" width = {80} height = {80}  />
            <p className="font-sans text-2xl font-normal">Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.</p>
            <Image  className = " py-2.5"  src = "/about/img/info iconicon2.png" alt = "info iconicon2" width = {80} height = {80}  />

            <p className="font-sans font-normal text-2xl">With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential.</p>

            </div>

            <div className='col img-col'>
            <Image  src = "/about/img/amicosolve.png" alt = "amicosolve" width = {600} height = {563.46}  />
            </div>
        </div>
    )
}
export default ProblemSection