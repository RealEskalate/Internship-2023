import Footer from "@/components/layout/Footer";
import Header from "@/components/layout/Header";
import { store } from "@/store";
import "@/styles/globals.css";
import type { AppProps } from "next/app";
import { Provider } from "react-redux";

export default function App({ Component, pageProps }: AppProps) {
  return (

    <Provider store={store}>
    <div className="max-w-screen-2xl mx-auto">
      <Header></Header>
      <Component {...pageProps} />
      <Footer></Footer>
    </div>
    </Provider>
  );
}
