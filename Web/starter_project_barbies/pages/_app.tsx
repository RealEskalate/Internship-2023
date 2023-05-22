import Layout from '@/components/common/Layout'
import { store } from '@/store/store'
import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import { Provider } from 'react-redux'

export default function App({ Component, pageProps }: AppProps) {
  return <Provider store={store}>
    <Layout>
       <Component {...pageProps} /> 
    </Layout>
     </Provider>
}
