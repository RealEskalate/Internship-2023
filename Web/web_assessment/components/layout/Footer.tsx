import React from 'react'

const Footer:React.FC = () => {
  return (
    <div className='flex flex-row justify-between p-20 text-white bg-indigo-500'>
      <div>
        <p className='bold text-2xl'> HakimHub </p>
      </div>
      <div className = "flex flex-row justify-between gap-6">
        <div >
          <p><strong>getconnected</strong></p>
          <ul className='mt-2'>
            <li> For physians </li>
            <li> For hospitals </li>
          </ul>
        </div>
        
        <div>
          <p><strong>actions</strong></p>
          <ul className='mt-2'>
            <li> Find a doctor </li>
            <li> Find a hospital </li>
          </ul>
        </div>
        <div>
          <p><strong>company</strong></p>
          <ul className='mt-2'>
            <li> about us </li>
            <li> career </li>
            <li> join our team </li>
          </ul>
        </div>

      </div>
    </div>
  )
}

export default Footer