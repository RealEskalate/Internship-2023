import allTeamMembers from '@/data/teams/team-members.json'
import TeamMemberCard from './TeamMemberCard'
import { useEffect, useState } from 'react'
import Pagination from '../common/Pagination'
import {TeamMember} from '../../types/teams'

const TeamMembersList: React.FC = () => {
    const [teamMembersCount, setTeamMembersCount] = useState(allTeamMembers.length)
    const [currentPage, setCurrentPage] = useState(1)
    const [startIndex, setStartIndex] = useState(0)
    const [endIndex, setEndIndex] = useState(0)
    const [teamMembers, setTeamMembers] = useState<TeamMember[]>([])
    const teamsPerPage = 6

    useEffect(() => {
        setTeamMembers(allTeamMembers.slice(startIndex,endIndex))
    }, [startIndex, endIndex, teamMembers])

    return (

        <div className="flex flex-col">
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3  justify-items-center items-center gap-0 p-16">
                {teamMembers.map((teamMember, index) => <TeamMemberCard key={index} teamMember={teamMember}/>)}
            </div>
            <Pagination currentPage={currentPage} setCurrentPage={setCurrentPage} itemsPerPage={teamsPerPage} totalItems={teamMembersCount} setStartIndex={setStartIndex} setEndIndex={setEndIndex}></Pagination>
        </div>
            
    )
}

export default TeamMembersList