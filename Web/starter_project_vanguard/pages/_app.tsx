import '@/styles/globals.css'
import type { AppProps } from 'next/app'

import RootLayout from '@/layout/default' 
import { store } from '@/store/store'
import { Provider } from 'react-redux'

export default function App({ Component, pageProps }: AppProps) {

  return <>
<Provider store={store}>
  <RootLayout><Component {...pageProps} /> </RootLayout>
  </Provider>
  </>
}
