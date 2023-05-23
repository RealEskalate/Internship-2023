import '@/styles/globals.css'
import { store } from '@/store'
import type { AppProps } from 'next/app'
import '../components/doctors/DoctorCard.css'; 
import { Provider } from 'react-redux'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <>
      <Provider store={store}>
          <Component {...pageProps} />
      </Provider>
    </>
  )
}
