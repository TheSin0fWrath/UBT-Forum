import React, { useContext, useMemo, useState } from 'react';
import UbtLog from '../Images/UbtLogo.png'
import importcss from "../hooks/importcss";
import { UserContext } from '../hooks/UserContext';

export default function EmptyPage  ({path,children}){
   importcss(`${path}`,"Empty.css");
   const {user,setUser} = useContext(UserContext);
<<<<<<< HEAD
   console.log(user,'user');

=======
 
>>>>>>> 5df4f7f2b0e2d41c072e45a8c8c559417cbd3de3
const adminCheck=useMemo(()=>{
   if(user!=null ){
      if(user.role=="Admin"){
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
      </div>
   </div>
</div>
)
}
