import { store } from './../store/store'
import '@/styles/globals.css'
import { Provider } from 'react-redux'

export default function App() {
  return <Provider store={store}>
      
     </Provider>
}
