import '@/styles/globals.css'
import type { AppProps } from 'next/app'
import React from "react";
import {Provider} from "react-redux";
import {store} from "@/store/store";
import Layout from "@/components/common/Layout";

export default function App({ Component, pageProps }: AppProps) {
  return <Provider store={store}>
          <Layout>
              <Component {...pageProps} />
          </Layout>
        </Provider>
}
