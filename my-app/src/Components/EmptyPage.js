import React from 'react';
// import "./ComponentCss/EmptyPage.css"
import {Link, Route}  from "react-router-dom";
import UbtLog from '../Images/UbtLogo.png'
import Forum from "./Forum"

export default function EmptyPage(){
return(
<div className="IndexPage" >
   <div className="MainNavBar">
      <nav> </nav>
   </div>
   <div className="backgroundImage">
      <img src={UbtLog} height="150px" width="150px"/>
   </div>
   <div className="mainWrapper">
      <div className="toplinecss"> UBT</div>
      <div className="secondWrapper">
         <div className="mainTitle">
            <h3>Post Your Tools</h3>
            <p>Your Description Goes here about the this froum partt section</p>
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
                     <Forum icon="i" name="Tips For Visual Studio" desc="Started by bankercion"threads="22" posts="22" lastPost="This post"/>
                     <Forum icon="i" name="Best Virtual Machine Tools" desc="Started by bankercion"threads="22" posts="22" lastPost="This post"/>
                     <Forum icon="i" name="Simple Design Tools" desc="Started by bankercion."threads="22" posts="22" lastPost="This post"/>
                     {/* 
                     <tr className="subCategory">
                        <td className="subCategory" colspan="10">Tools</td>
                     </tr>
                     */}
                  </tbody>
               </table>
            </div>
         </div>
      </div>
   </div>
</div>
)
}
