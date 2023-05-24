import '@/styles/globals.css'
import { store } from '@/store'
import type { AppProps } from 'next/app'
import '../components/doctors/DoctorCard.css'; 
import { Provider } from 'react-redux'
import NavigationBar from '@/components/layout/Navbar';
import Footer from '@/components/layout/Footer';

import { library } from '@fortawesome/fontawesome-svg-core';
import { faFacebook, faInstagram, faLinkedin } from '@fortawesome/free-brands-svg-icons';

library.add(faFacebook, faInstagram, faLinkedin);

export default function App({ Component, pageProps }: AppProps) {
  return (
    <>
      <Provider store={store}>
        <NavigationBar />
          <Component {...pageProps} />

        <Footer />
      </Provider>
    </>
  )
}
