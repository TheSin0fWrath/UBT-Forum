
import './App.css';
import HomePage from './HomePage.js';
import {Link, Route, Switch}  from "react-router-dom"
import EmptyPage from "../src/Components/EmptyPage"

function App() {
  return (
    <div className="App">
       <HomePage/>
    </div>
  )
}

export default App;
