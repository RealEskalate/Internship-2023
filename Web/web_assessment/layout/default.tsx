import React from 'react'
import { ReactNode, Suspense } from 'react'

import Footer from '@/components/layout/Footer'
import NavigationBar from '@/components/layout/Navbar'

const RootLayout = ({ children }: { children: ReactNode }) => {
  return (
    <div>
      <NavigationBar/>
      <Suspense fallback={<div>Loading...</div>}>{children}</Suspense>
      <Footer/>
    </div>
  )
}

export default RootLayout