import { teamMembers } from '@/data/team/teams'
import TeamCard from './TeamCard'
import TeamsHero from './TeamsHero'

function Teams() {

    const teams = teamMembers

    return (
        <div className='bg-white'>
            <TeamsHero></TeamsHero>
            
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3  justify-items-center items-center gap-0 p-16">
                {teams.map((person, index) => <TeamCard key={index} name={person.name} description={person.description} job={person.job} avatar={person.avatar} socialMedia={person.socialMedia}></TeamCard>)}
            </div>

            
            
        </div>
    )
}

export default Teams