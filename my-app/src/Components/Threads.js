import React, { Children } from 'react';
import UbtLog from '../Images/UbtLogo.png'
import importcss from "../hooks/importcss";



export default function Threads  ({title,desc,path,children}){
   importcss(`${path}`,`Threads.css`);
return(
<div className="IndexPage">
   <div className="MainNavBar">
      <nav> </nav>
   </div>
   <div className="backgroundImage">
   <a href="/"> <img src={UbtLog} height="150px" width="150px"/></a>
   </div>
   <div className="mainWrapper">
      <div className="toplinecss"> UBT</div>
      <div className="secondWrapper">
         <div className="mainTitle">
            <h3>{title}</h3>
            <p>{desc}</p>
         </div>
         <div className="thirdWrapper">
            <div className="ContentBox">
               <div className="ContentBoxHeader">
                  <h3>Topics </h3>
               </div>
               <div className="ContentBoxBody">
                  <p>Welcome to UBT. Please read forum rules & keep chatbox English at all times. Remember to run downloaded files in a Virtual Machine or Sandboxie.Do not trust anyone!</p>
               </div>
               <table>
                  <thead>
                     <tr>
                        <td width="3%"></td>
                        <td width="40%">Forum</td>
                        <td width="10%">Likes</td>
                        <td width="10%">Posts</td>
                        <td width="30%">Last Post</td>
                     </tr>
                  </thead>
                  <tbody>
                    {children}
                     
                   
                  </tbody>
               </table>
            </div>
         </div>
      </div>
   </div>
</div>
)
}
