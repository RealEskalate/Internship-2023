import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import Navbar from '@/components/layout/Navbar'
import Footer from '@/components/layout/Footer'

export default function App({ Component, pageProps }: AppProps) {
  return  (
    <div>
      <Navbar activePage='Home'/>
      <Component {...pageProps} />
      <Footer/>
    </div>
  )
}
