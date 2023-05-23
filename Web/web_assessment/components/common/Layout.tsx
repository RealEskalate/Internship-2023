import { ReactNode } from "react"
import Footer from "./Footer"
import NavBar from "./NavBar"

type LayoutProps = {
    children:ReactNode
}

const Layout = ({children}: LayoutProps) => {
  return (
    <div>
        <NavBar />
        <div>{children}</div>
        <Footer />
    </div>
  )
}

export default Layout