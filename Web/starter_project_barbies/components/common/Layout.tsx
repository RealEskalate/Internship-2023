import { ReactNode } from 'react'
import Footer from './Footer'
import Navbar from './Navbar'

interface LayoutProps {
    children : ReactNode
}

const Layout = ({children}:LayoutProps) => {
  return (
    <div >
        <Navbar />
        <div>
            {children}
        </div>
        <Footer/>
    </div>
  )
}

export default Layout