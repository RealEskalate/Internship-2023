import SearchBar from "@/components/common/SearchBar";
import Footer from "@/components/layout/Footer";
import Navigation from "@/components/layout/Navigation";
import { store } from "@/store";
import "@/styles/globals.css";
import type { AppProps } from "next/app";
import { Provider } from "react-redux";

export default function App({ Component, pageProps }: AppProps) {
  return (
    <div className="min-h-screen bg-white p-10">
      <Provider store={store}>
        <Navigation />
        
        <Component {...pageProps} />
        <Footer />
      </Provider>
    </div>
  );
}
