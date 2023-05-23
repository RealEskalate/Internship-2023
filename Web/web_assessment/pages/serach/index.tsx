import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import SearchDoctorPage from './../../components/SearchDoctorPage';
import DoctorDCard from './../../components/DoctorCard';

const App = () => {
  return (
    <Router>
      <Switch>
        <Route exact path="/">
          <SearchDoctorPage />
        </Route>
        <Route path="/doctors/:id">
          <Doctorcard />
        </Route>
      </Switch>
    </Router>
  );
};

export default App;