import React, {useEffect, useState} from 'react'
import MemberCard from './MemberCard'
import teamMembers from '../../data/team-members.json'
import Pagination from '../common/pagination'

const Members: React.FC = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [displayedMembers, setDisplayedMembers] = useState(teamMembers);

  const onPageChange = (page: number) => {
    setCurrentPage(page);
  };

  useEffect(()=>{
    const start = (currentPage - 1) * 8
    const end = start + 8
    setDisplayedMembers(teamMembers.slice(start, end))
  }, [currentPage])
  return (
    <>
    <div className="grid grid-cols-12 gap-8">
      {displayedMembers.map((member, idx: number) => {
        return (
          <div className="col-span-12 sm:col-span-6 2md:col-span-4 xl:col-span-3 3xl:col-span-2" key={idx}>
            <MemberCard member={member} />
          </div>
        )
      })}
    </div>
    <div className="mt-16">
      <Pagination currentPage={currentPage} totalPages={Math.ceil(teamMembers.length / 8)} onPageChange={onPageChange} />
    </div>
    </>
  )
}

export default Members
