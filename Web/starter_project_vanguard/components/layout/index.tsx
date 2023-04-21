import React from 'react'
import { ReactNode, Suspense } from 'react'
import Navbar from './navbar'

const RootLayout = ({ children }: { children: ReactNode }) => {
  return (
    <div className='px-20 py-8'>
      <Navbar />
      <Suspense fallback={<div>Loading...</div>}>{children}</Suspense>
    </div>
  )
}

export default RootLayout
