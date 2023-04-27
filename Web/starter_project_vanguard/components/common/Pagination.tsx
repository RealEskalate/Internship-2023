import clsx from 'clsx'
import React, { useState } from 'react'
import teamMembers from '@/data/team-members.json'

const Pagination:React.FC = () => {
    const [curPage, setCurPage] = useState(1)
    const pages = []
    const numberOfPages = Math.ceil(teamMembers.length / 8)
    for(let i=1; i <= numberOfPages; i++){
        pages.push(i)
    }

    const changePage:Function = (val: React.SetStateAction<number>) => {
        setCurPage(val)
    }
  return (
    <div className='flex gap-3 justify-center'>
        {
            pages.map((value, idx) => {
                return(<button key={idx} onClick={()=>changePage(value)} className={clsx('px-4 py-1.5 rounded-md',curPage == value ? 'bg-primary text-white': 'bg-gray-200 text-black' )}>{value}</button>)
            })
        }
        
    </div>
  )
}

export default Pagination