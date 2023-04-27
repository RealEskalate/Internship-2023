import Loading from '@/components/common/Loading'
import Meta from '@/components/common/Meta'
import Navbar from '@/components/layout/Navbar'
import { ReactNode, Suspense } from 'react'

const RootLayout = ({ children }: { children: ReactNode }) => {
  return (
    <>
      <Meta />

      <Navbar />
      <Suspense fallback={<Loading />}>
        <main className="">{children}</main>
      </Suspense>
    </>
  )
}

export default RootLayout
