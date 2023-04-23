import Navbar from '@/components/layout/Navbar'
import '@/styles/globals.css'
import '@/styles/singleBlog.css'
import type { AppProps } from 'next/app'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <>
      <Navbar />
      <Component {...pageProps} />
    </>
  )
}
