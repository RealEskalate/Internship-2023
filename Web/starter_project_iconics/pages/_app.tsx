import Footer from '@/components/layout/Footer'
import Navbar from '@/components/layout/Navbar'
import '@/styles/globals.css'
import type { AppProps } from 'next/app'


import '@/styles/about/AboutSection.css'
import '@/styles/about/Card.css'
import '@/styles/about/ProblemSection.css'
import '@/styles/about/SessionSection.css'
import '@/styles/about/SocialProjectsSections.css'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <>
      <Navbar />
      <Component {...pageProps} />
      <Footer />
    </>
  )
}
