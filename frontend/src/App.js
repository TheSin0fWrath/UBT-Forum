
import './App.css';
import HomePage from './HomePage/HomePage';
import {Link, Route, Switch}  from "react-router-dom"
import Announcments from "./Forums/Announcments"
import LoginPage from "./LoginPage/LoginPage"
import UserProfile from "./UserProfile/UserProfile"
import { UserContext } from './Shared/hooks/UserContext';
import { useMemo, useState,useEffect } from 'react';
import {CheckLogin} from "./Shared/hooks/CheckLogin";
import EmptyPage from "./Shared/Components/EmptyPage"
import ProfileEdit from "./UserSettings/ProfileEdit"
import UserReputation from "./UserProfile/UserReputation"
import AdminPanel from "./AdminPanel/AdminPanel"
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
          <Route path="/reputation"><UserReputation/></Route>
          <Route path="/adminPanel"><AdminPanel/></Route>
          <Route path="/"> <HomePage/>  </Route>
        </Switch>
       </UserContext.Provider>
    </div>
  )
}

export default App;
