import { map } from 'cypress/types/bluebird'
import React from 'react'
import Blog from './blog'

const blogs = [
    <Blog/>,
    <Blog />,
    <Blog/>,
    <Blog />,
    <Blog/>,
    <Blog />,
]

function Blogs() {
  return (
    <ul>
        {blogs.map((item) => (
            <li>{item}</li>
        ))}
    </ul>
  )
}

export default Blogs