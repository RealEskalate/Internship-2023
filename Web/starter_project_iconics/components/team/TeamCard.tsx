
export interface TeamCardProps{
    name: string
    job: string
    description: string
    instagram?: string
     linkedin?: string
     facebook?: string
     avatar?: string
}

function TeamCard({name, job, description, avatar = 'https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg', instagram, linkedin, facebook}: TeamCardProps) {
    const socials = [{link: facebook, image: '/img/teams-page/facebook.png' }, {link: instagram, image: '/img/teams-page/instagram.png' }, {link: linkedin, image: '/img/teams-page/linkedin.png' }]
    return (
        <div className='flex flex-col bg-white rounded-lg p-6 m-2 items-center justify-center shadow-xl max-w-sm'>
        <img className='rounded-full w-32 h-32 mt-2 object-cover ' src={avatar}></img>
        <h1 className="font-bold uppercase text-black text-2xl m-3">{name}</h1>
        <h2 className="uppercase text-black text-xl">{job}</h2>
        <p className="text-center my-4 text-xl text-[#7D7D7D]">{description}</p>
        <hr className='my-6 w-[100%] '></hr>

            <div className="flex justify-around w-[100%]">
                
                {socials.map((social) => <a href={social.link}><img className='rounded-md object-contain w-8' src={social.image}></img></a>)}
                    

            </div>
        </div>
    )
}

export default TeamCard 