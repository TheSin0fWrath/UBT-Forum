import React, { useContext, useMemo, useState } from 'react';
import UbtLog from '../Images/UbtLogo.png'
import importcss from "../hooks/importcss";
import { UserContext } from '../hooks/UserContext';

export default function EmptyPage  ({path,secondfeed,children}){
   importcss(`${path}`,"Empty.css");
   const {user,setUser} = useContext(UserContext);
   console.log(user,'user');

const adminCheck=useMemo(()=>{
   if(user!=null && user!="" ){
      console.log(user.role)
      if(user.role.includes("Admin")){
         return <p onClick={async ()=>{window.location.href="/adminPanel"}}>AdminPanel</p>
      }
   }
},[user])
return(
<div className="IndexPage">
   <div className="MainNavBar">
      {user?(
      <nav> 
         {adminCheck}
         <p onClick={async ()=>{window.localStorage.removeItem("token");window.location.reload()}}>SignOut</p>
          <a href={`/user/${user.nameid}`}>MyProfile</a></nav>
          ):( 
              <nav> <a href="/login">SignUp</a></nav>
              )}
   </div>
   <div className="backgroundImage">
   <a href="/"> <img src={UbtLog} height="150px" width="150px"/></a>
   </div>
   <div className="mainWrapper">
      <div className="toplinecss"> UBT</div>
      <div className="secondWrapper">
      
         <div className="thirdWrapper">
        
         {children}
         </div>
         {secondfeed}
      </div>
   </div>
</div>
)
}
