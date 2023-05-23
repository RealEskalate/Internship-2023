import { BrowserRouter as Router } from 'react-router-dom';
import Top from '../../common/Top';
import DoctorsList from '../../components/DoctorsList'

export default function App() {
  return (
      <Router>
        <Top />
        <DoctorsList />
      </Router>
  );
}
