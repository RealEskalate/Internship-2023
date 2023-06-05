import { store } from '../store/store'
import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import { Provider } from 'react-redux'

import Navbar from '@/components/layout/Navbar'
import Footer from '@/components/layout/Footer'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store} >
        <Component {...pageProps} />
    </Provider>
  )
}
