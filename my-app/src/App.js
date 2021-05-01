
import './App.css';
import HomePage from './HomePage.js';
import {Link, Route, Switch}  from "react-router-dom"
import Announcments from "./Pages/Announcments"
import LoginPage from "./Pages/LoginPage"
import UserProfile from "./Pages/UserProfile"
import { UserContext } from './hooks/UserContext';
import { useMemo, useState,useEffect } from 'react';
import {CheckLogin} from "./hooks/CheckLogin";
import EmptyPage from "./Components/EmptyPage"
import ProfileEdit from "./Pages/ProfileEdit"

function App() {
  
  
  const [user,setUser] =  useState("");
  useEffect(async function check (){
    const response= await CheckLogin();
     setUser(await response)
 },[])

  const value = useMemo(()=>({user,setUser}),[user,setUser])
 
  
  return (
    <div className="App">
         <UserContext.Provider value={value}>
      <Switch>
        <Route path="/editprofile"><ProfileEdit/></Route>
      <Route path="/login"> <LoginPage /> </Route>
       <Route path="/announcments"> <Announcments /> </Route>
       <Route path="/user"> <UserProfile/>  </Route>
       <Route path="/"> <HomePage/>  </Route>
       </Switch>
       </UserContext.Provider>
    </div>
  )
}

export default App;
