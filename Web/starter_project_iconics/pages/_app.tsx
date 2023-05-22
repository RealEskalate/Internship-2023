import Footer from '@/components/layout/Footer'
import Navbar from '@/components/layout/Navbar'
import { store } from '@/store'
import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import { Provider } from 'react-redux'



export default function App({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store}>
      <div className="max-w-screen-2xl mx-auto">
        <Navbar />
        <Component {...pageProps} />
        <Footer />
      </div>
    </Provider>
  )
}
