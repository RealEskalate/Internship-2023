import '@/styles/globals.css'
import type { AppProps } from 'next/app'

import RootLayout from '@/layout/default' 

export default function App({ Component, pageProps }: AppProps) {
  return <RootLayout><Component {...pageProps} /> </RootLayout>
}
