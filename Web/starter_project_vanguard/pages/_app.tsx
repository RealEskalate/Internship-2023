import '@/styles/globals.css'
import type { AppProps } from 'next/app'

import RootLayout from '@/layout/default'
import { Provider } from 'react-redux'
import store from '@/store/index'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store}>
      <RootLayout>
        <Component {...pageProps} />
      </RootLayout>
    </Provider>
  )
}
