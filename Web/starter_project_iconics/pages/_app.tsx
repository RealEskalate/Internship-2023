import Footer from '@/components/layout/Footer'
import Navbar from '@/components/layout/Navbar'
import '@/styles/globals.css'
import { ApiProvider } from '@reduxjs/toolkit/dist/query/react'
import type { AppProps } from 'next/app'
import { blogApi } from '../store/features/api/blog-api'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <>
      <ApiProvider api={blogApi}>
        <Navbar />
        <Component {...pageProps} />
        <Footer />
      </ApiProvider>
    </>
  )
}
