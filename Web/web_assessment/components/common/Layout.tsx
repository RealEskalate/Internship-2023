import { ReactNode } from 'react'
import Footer from './Footer'
import Header from './Header'

interface LayoutProps {
    children : ReactNode
}

const Layout = ({children}:LayoutProps) => {
  return (
    <div >
      <Header />
      <div className='px-36'>
        {children}
      </div>
      <Footer />
    </div>
  )
}

export default Layout