import Title from '../../components/successStory/Title'
import  Profile  from '../../components/successStory/SuccessStory'
import Partners from '../../components/successStory/Partners'
import Footer from '../../components/successStory/Footer'
import { Inter } from 'next/font/google'


const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (
    <div>
      <Title />
      <Profile />
      <Partners />
      <Footer />
    </div>
    
  )
}
