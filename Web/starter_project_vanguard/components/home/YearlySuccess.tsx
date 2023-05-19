import React from 'react'

interface yearlySucess {
  id: number,
  year: string,
  success: string,
  average: string
}

const YearlySuccess: React.FC<yearlySucess> = ({
  id,
  year,
  success,
  average,
}) => {
  return (
    <div className="flex flex-col items-center justify-center w-3/5 p-5 m-4 bg-white rounded-xl aspect-auto grow">
      <p className="mb-4 font-bold">{year}</p>
      <p className="font-bold">{success}</p>
      <p className="text-sm text-secondary-text">{average}</p>
    </div>
  )
}

export default YearlySuccess
