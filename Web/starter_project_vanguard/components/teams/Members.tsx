import React from 'react'
import MemberCard from './MemberCard'
import teamMembers from '../../data/team-members.json'

const Members: React.FC = () => {
  return (
    <div className="grid grid-cols-12 gap-8">
      {teamMembers.map((member, idx: number) => {
        return (
          <div className="col-span-12 sm:col-span-6 lg:col-span-3 " key={idx}>
            <MemberCard member={member} />
          </div>
        )
      })}
    </div>
  )
}

export default Members
