import TeamMembersList from '@/components/teams/TeamMembersList'
import TeamsHero from '@/components/teams/TeamsHero'


const TeamsPage: React.FC = () => {
  return (
    <div className='flex'>
    <div className='max-w-screen-2xl mx-auto'>
    <TeamsHero/>
    <TeamMembersList/>
    </div>
    </div>
  )
}

export default TeamsPage