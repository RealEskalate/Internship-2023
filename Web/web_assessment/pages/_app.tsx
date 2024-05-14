import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import Navbar from '@/components/layout/Navbar'
import Footer from '@/components/layout/Footer'
import { Provider } from 'react-redux'
import { store } from '@/store'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store}>
      <div>
        <Navbar />
        <Component {...pageProps} />
        <Footer />
      </div>
    </Provider>
  )
}
