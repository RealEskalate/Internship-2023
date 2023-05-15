import Image from "next/image"

const ProblemSection:React.FC = () => {
    return (
        <div className='problem-section grid grid-cols-2 p-12  lg'>
            <div className = "col p-2.5">
                <h1 className="font-extrabold font-poppins text-5xl "><div> The Problem We <span className = "text-primary">Are Solving </span></div></h1>
                <Image  className = " py-2.5" src = "/img/about/problem-section/africa-iconicon-1.png" alt = "info_iconicon_1" width = {80} height = {80}  />
                <p className="font-sans-serif text-2xl font-light">Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.</p>
                <Image  className = " py-2.5"  src = "/img/about/problem-section/code-iconicon-2.png" alt = "info_iconicon_2" width = {80} height = {80}  />
                <p className="font-sans-serif font-light text-2xl">With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential.</p>
            </div>
            <div className='col img-col'>
            <Image  src = "/img/about/problem-section/amico-solve.png" alt = "amicosolve" width = {600} height = {563.46}  />
            </div>
        </div>
    )
}
export default ProblemSection