import TeamCard from './TeamCard'

function Teams() {

    const teams = [{
        name: 'Nathaniel Awel',
        job: 'software engineer',
        description: 'He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.',
        avatar: 'https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg'
    },
    {
        name: 'Nathaniel Awel',
        job: 'software engineer',
        description: 'He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.',
        avatar: 'https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg'
    },
    {
        name: 'Nathaniel Awel',
        job: 'software engineer',
        description: 'He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.',
        avatar: 'https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg'
    },
    {
        name: 'Nathaniel Awel',
        job: 'software engineer',
        description: 'He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.',
        avatar: 'https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg'
    },
    {
        name: 'Nathaniel Awel',
        job: 'software engineer',
        description: 'He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.',
        avatar: 'https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg'
    },
    {
        name: 'Nathaniel Awel',
        job: 'software engineer',
        description: 'He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.',
        avatar: 'https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg'
    }]

    return (
        <div className='bg-white'>
            <div className="grid md:grid-cols-1 lg:grid-cols-2 p-8">
                <div className="flex flex-col p-8 m-2">
                    <h1 className="font-bold text-[2.5rem] xl:text-[3rem] uppercase m-2">
                        The team we’re currently
                        working with
                    </h1>
                    <p className="text-[1.5rem] text-[#7D7D7D] m-2">Meet our development team is a small but highly skilled and experienced group of professionals. We have a talented mix of web developers, software engineers, project managers and quality assurance specialists who are passionate about developing exceptional products and services.</p>
                </div>
                
                <div className="p-8 relative">
                    <img src="/vector (1).png" alt="" className='contain absolute top-0 left-0 w-[35%]'/>
                    <img src="/vector (2).png" alt="" className='contain absolute top-0 right-0 w-[35%]'/>
                    <img src="/vector (3).png" alt="" className='contain absolute bottom-0 left-0 w-[35%]'/>
                    <img src="/vector.png" alt="" className="src" />

                    <div className="absolute top-[33%] left-[33%] flex flex-col">
                    <h1 className="font-bold text-[1.5rem] sm:text-[2rem] md:text-[3rem] uppercase"> <span className="text-[#264FAD]">Team</span>  work</h1>

<h1 className="font-bold text-[1.5rem] sm:text-[2rem] md:text-[3rem] uppercase"> Collaboration </h1>
<h1 className="font-bold text-[1.5rem] sm:text-[2rem] md:text-[3rem] uppercase"> <span className="text-[#264FAD]">hard</span>  work</h1>

                    </div>
                    
                    
                </div>
            </div>
<div className="flex justify-around"><hr className='my-4 mx-4 w-[80%] color-black'></hr></div>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 p-8">
                {teams.map((person, index) => <TeamCard key={index} name={person.name} description={person.description} job={person.job} avatar={person.avatar}></TeamCard>)}
            </div>
        </div>
    )
}

export default Teams