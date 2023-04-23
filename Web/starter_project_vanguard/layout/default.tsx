import React from 'react'
import { ReactNode, Suspense } from 'react'

import Navbar from '@/components/layout/navbar'

const RootLayout = ({ children }: { children: ReactNode }) => {
  return (
    <div>
      <Navbar/>
      <Suspense fallback={<div>Loading...</div>}>{children}</Suspense>
    </div>
  )
}

export default RootLayout