import Footer from "@/components/layout/Footer";
import Navbar from "@/components/layout/Navbar";
import "@/styles/globals.css";
import type { AppProps } from "next/app";
import { Provider } from "react-redux";
import { store } from "./store";

export default function App({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store}>
      <div className="flex flex-col min-h-screen">
        <Navbar />
        <Component {...pageProps} />
        <Footer />
      </div>
    </Provider>
  );
}
