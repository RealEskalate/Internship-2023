import React from 'react'

type Props = {
  children: string | JSX.Element | JSX.Element[]
}
const Layout = ({ children }: Props) => {
  return (
    <>
      <div className="font-body bg-white">
        <main>{children}</main>
      </div>
    </>
  )
}
export default Layout
