import { ReactNode } from 'react'

interface LayoutProps {
    children : ReactNode
}

const Layout = ({children}:LayoutProps) => {
  return (
    <div >
      <div className='px-36'>
        {children}
      </div>
    </div>
  )
}

export default Layout