import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import Navigation from '@/components/NavBar'
import Footer from '@/components/Footer'
import { Provider } from "react-redux";
import {store} from "../store/store";

export default function App({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store}>
      <div>
        <Navigation />
        <Component {...pageProps} />
        <Footer />
      </div>
    </Provider>
  )
}