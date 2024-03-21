import { useGetTeamMembersQuery } from '@/store/features/team-members/team-members-api'
import { useEffect, useState } from 'react'
import { TeamMember } from '../../types/teams'
import Error from '../common/Error'
import Pagination from '../common/Pagination'
import TeamMemberCard from './TeamMemberCard'

const TeamMembersList: React.FC = () => {
  const {
    data: allTeamMembers,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetTeamMembersQuery()

  const [currentPage, setCurrentPage] = useState(1)
  const [startIndex, setStartIndex] = useState(0)
  const [endIndex, setEndIndex] = useState(0)
  const [teamMembers, setTeamMembers] = useState<TeamMember[]>([])
  const teamsPerPage = 6

  let content
  useEffect(() => {
    if (isSuccess) {
      setTeamMembers(allTeamMembers.slice(startIndex, endIndex))
    }
  }, [isLoading, isSuccess, startIndex, endIndex, teamMembers, allTeamMembers])

  if (isLoading) {
    content = (
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3  justify-items-center items-center gap-0 p-16">
        {Array(3)
          .fill(0)
          .map((_, index) => (
            <div
              key={index}
              className="animate-pulse flex flex-col self-start bg-white rounded-lg p-6 m-2 items-center justify-center shadow-xl w-[400px]"
            >
              <div className="rounded-full w-32 h-32 mt-2 bg-gray-200 object-contain"></div>
              <div className="w-1/2 h-5 bg-gray-200 m-3"></div>
              <div className="w-1/3 h-5 bg-gray-200"></div>
              <div className="flex flex-col my-4 p-4 w-full gap-3">
                <div className="w-full h-5 bg-gray-200"></div>
                <div className="w-full h-5 bg-gray-200"></div>
                <div className="w-full h-5 bg-gray-200"></div>
                <div className="w-full h-5 bg-gray-200"></div>
              </div>
            </div>
          ))}
      </div>
    )
  } else if (isSuccess) {
    content = (
      <div className="flex flex-col">
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3  justify-items-center items-center gap-0 p-16">
          {teamMembers.map((teamMember, index) => (
            <TeamMemberCard key={index} teamMember={teamMember} />
          ))}
        </div>
        <Pagination
          currentPage={currentPage}
          setCurrentPage={setCurrentPage}
          itemsPerPage={teamsPerPage}
          totalItems={allTeamMembers.length}
          setStartIndex={setStartIndex}
          setEndIndex={setEndIndex}
        ></Pagination>
      </div>
    )
  } else if (isError) {
    content = <Error></Error>
  }

  return <div>{content}</div>
}

export default TeamMembersList
