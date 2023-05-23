import type { AppProps } from 'next/app'
import { store } from '@/store/store'
import { Provider } from 'react-redux'
import '@/styles/globals.css'
import Layout from '@/components/common/Layout'

export default function App({ Component, pageProps }: AppProps) {
  return <Provider store={store}>
    <Layout>
      <Component {...pageProps} /> 
    </Layout>
  </Provider>
}
