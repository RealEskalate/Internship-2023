import React from 'react'
import Member from './MemberCard'
import { members } from '@/data/team-members'


const Members:React.FC = () => {
  return (
    <div className='grid grid-cols-12 gap-8'>
        {
            members.map((member: any, idx: number)=>{
                return(
                    <div className='col-span-3' key={idx}>
                        <Member  name={member.name} picture={member.photoUrl} role={member.role} description={member.description} links={member.links}/>
                    </div>
                )
            })
        }

    </div>
  )
}

export default Members