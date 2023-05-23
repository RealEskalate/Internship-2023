import Footer from '@/components/Footer'
import Navbar from '@/components/Navbar'
import React from 'react'
import { ReactNode, Suspense } from 'react'

const RootLayout = ({ children }: { children: ReactNode }) => {
  return (
    <div>
      <Navbar/>
      <Suspense fallback={<div>Loading...</div>}>{children}</Suspense>
      <Footer/>
    </div>
  )
}

export default RootLayout