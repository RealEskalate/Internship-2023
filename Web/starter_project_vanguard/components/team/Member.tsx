import Image from "next/image"
import Link from "next/link"

interface MemberProps {
    name?: string,
    picture?: string,
    role?: string,
    description?: string,
    links?: string[]
}
const Member = ( {name = "Yared Tegegn", picture="https://media.licdn.com/dms/image/C4E03AQEVlrjCsy97_Q/profile-displayphoto-shrink_800_800/0/1661101696311?e=2147483647&v=beta&t=JK2LQ6ZoiQeWxoLnrPUwUiX5Bqi5mHBTIVKh4HK0cQk", role="Intern", description="Yared is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.", links=["https://github.com/", "https://github.com/", "https://github.com/"]}: MemberProps) => {
  const socials = ["facebook.svg", "linkedin.svg", "insta.svg"]
  return (
    <div className="bg-white rounded-md drop-shadow-xl py-6 px-6 max-w-sm ">
        <Image className="rounded-full m-auto text-center" width={120} height={120} src={picture} alt={name} />
        <h2 className="font-bold mt-4 uppercase text-2xl text-center text-primary-text">{name}</h2>
        <h5  className="font-medium uppercase text-center text-primary-text">{role}</h5>
        <p className="text-center text-secondary-text my-3">{description}</p>
        <hr className="border mt-7 mb-3" />
        <div className="flex justify-around">
          {
            links.map((link: string, idx: number) => {
              console.log(idx, link, socials[idx]);
              return(
              <Link key={idx} href={link} target="_blank">
                <Image className="hover:" width={27} height={27} src={socials[idx]} alt={socials[idx]} />
              </Link>)
            })
          }
        </div>

    </div>
  )
}

export default Member