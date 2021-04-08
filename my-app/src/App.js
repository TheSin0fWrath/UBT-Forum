
import './App.css';
import HomePage from './HomePage.js';
import {Link, Route, Switch}  from "react-router-dom"
import Announcments from "./Pages/Announcments"
import LoginPage from "./Pages/LoginPage"

function App() {

  return (
    <div className="App">
      <Switch>
      <Route path="/login"> <LoginPage /> </Route>
       <Route path="/announcments"> <Announcments /> </Route>
       <Route path="/"> <HomePage/>  </Route>
       </Switch>
    </div>
  )
}

export default App;
