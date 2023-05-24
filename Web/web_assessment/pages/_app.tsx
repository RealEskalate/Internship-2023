import Footer from '@/components/layout/Footer'
import NavBar from '@/components/layout/NavBar'
import { store } from '@/store'
import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import {Provider} from 'react-redux'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <div>
      <Provider store={store}>
      <NavBar/>
      <Component {...pageProps} />
      <Footer/>
      </Provider>
      
    </div>
    
    
    )
}
