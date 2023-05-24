import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import { Provider } from 'react-redux'
import { store } from '@/store/store'
import Footer from '@/components/Footer'
import Header from '@/components/Header'

export default function App({ Component, pageProps }: AppProps) {
  return<Provider store={store}>
      <div className='min-h-screen'>
      <Header/>
      <Component {...pageProps} />
      </div>
      <Footer/>
      </Provider>
}
