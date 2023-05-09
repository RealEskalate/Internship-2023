import React from 'react'
import { SuccessModel } from '@/types/home/SuccessModel'

interface SuccessProp {
  info: SuccessModel
}

const YearlySuccess:React.FC<SuccessProp> = ({ info }) => {
  
  return (
    <div className="flex flex-col items-center justify-center w-3/5 p-5 m-4 bg-white rounded-xl aspect-auto grow">
      <p className="mb-4 font-bold">{info.year}</p>
      <p className="font-bold">{info.success}</p>
      <p className="text-sm text-secondary-text">{info.average}</p>
    </div>
  )
}

export default YearlySuccess