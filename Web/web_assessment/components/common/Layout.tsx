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
        <div className="my-24">{children}</div>
        <Footer />
    </div>
  )
}

export default Layout