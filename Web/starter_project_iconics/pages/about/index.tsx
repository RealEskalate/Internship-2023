import { useEffect, useState } from 'react'
const about = () => {
  const [data, setData] = useState('')

  useEffect(() => {
    const delay = setTimeout(() => {
      setData('Hello, world!')
    }, 2000)

    return () => clearTimeout(delay)
  }, [])

  return <div>{data && <h1>{data}</h1>}</div>
}

export default about
