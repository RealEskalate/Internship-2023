import React from 'react'
import { ReactNode, Suspense } from 'react'

import Navbar from '@/components/layout/Navbar'
import Footer from '@/components/layout/Footer'

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