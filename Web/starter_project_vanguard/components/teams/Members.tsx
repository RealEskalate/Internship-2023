import React from 'react'
import Member from './MemberCard'
import members from '../../data/team-members.json'

const Members: React.FC = () => {
  return (
    <div className="grid grid-cols-12 gap-8">
      {members.map((member, idx: number) => {
        return (
          <div className="col-span-12 sm:col-span-6 lg:col-span-3 " key={idx}>
            <Member member={member} />
          </div>
        )
      })}
    </div>
  )
}

export default Members
