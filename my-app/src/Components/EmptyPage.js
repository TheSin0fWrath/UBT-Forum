import React, { useContext, useEffect, useState } from 'react';
import UbtLog from '../Images/UbtLogo.png'
import importcss from "../hooks/importcss";
import profileIcon from '@iconify-icons/vs/profile';
import { UserContext } from '../hooks/UserContext';
import { Icon, InlineIcon } from '@iconify/react';

export default function EmptyPage  ({path,children}){
   importcss(`${path}`,`Empty.css`);

      

return(
<div className="IndexPage">
   <div className="MainNavBar">
      {/* {user?(<nav> <p onClick={async ()=>{window.localStorage.removeItem("token");window.location.reload()}}>SignOut</p> <a href={`/user/${user.nameid}`}>MyProfile</a></nav>):(  <nav> <a href="/login">SignUp</a></nav>)} */}
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
