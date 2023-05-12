import teamMembers from '@/data/teams/team-members.json'
import TeamMemberCard from './TeamMemberCard'

const TeamMembersList: React.FC = () => {
    return (
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3  justify-items-center items-center gap-0 p-16">
                {teamMembers.map((teamMember, index) => <TeamMemberCard key={index} teamMember={teamMember}/>)}
            </div>
    )
}

export default TeamMembersList