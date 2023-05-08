import React from 'react'
import { SuccessModel } from '@/types/home/SuccessModel'

interface Props {
  info: SuccessModel
}

const YearlySuccess = ({ info }: Props) => {
  return (
    <div className="flex flex-col items-center justify-center w-3/5 p-5 m-4 bg-white limit_size:w-max limit_size:h-max rounded-xl aspect-auto grow">
      <p className="mb-4 font-bold">{info.year}</p>
      <p className="font-bold">{info.success}</p>
      <p className="text-sm text-gray-500">{info.average}</p>
    </div>
  )
}
export default YearlySuccess
