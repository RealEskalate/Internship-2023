import "@/styles/globals.css";
import { store } from "../store";
import NavBar from "../components/layout/NavBar";
import Footer from "@/components/layout/Footer";
import { Provider } from "react-redux";

import type { AppProps } from "next/app";

export default function App({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store}>
      <div className="max-w-screen-2xl mx-auto">
        <NavBar />
        <Component {...pageProps} />
        <Footer />
      </div>
    </Provider>
  );
}
