import RootLayout from '@/layout/default'
import { store } from '@/store'
import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import { Provider } from 'react-redux'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <RootLayout>
    <Provider store={store}>
      <Component {...pageProps} />
    </Provider>
    </RootLayout>
    
    )
}
