import { BrowserRouter as Router } from 'react-router-dom';
import Top from '../../common/Top';
import DoctorDetailsPage from '../../components/DoctorsDetailPage'

export default function App() {
  return (
      <Router>
        <Top />
        <DoctorDetailsPage />
      </Router>
  );
}
