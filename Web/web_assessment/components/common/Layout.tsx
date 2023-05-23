import { ReactNode } from 'react'

interface LayoutProps {
    children : ReactNode
}

const Layout = ({children}:LayoutProps) => {
  return (
    <div >
      <div>
          {children}
      </div>
    </div>
  )
}

export default Layout