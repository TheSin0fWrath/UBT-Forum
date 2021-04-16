import React from 'react';
// import "../src/HomePage.css"
import CSE from './Subjects/CSE'
import Arkitektur from './Subjects/Arkitektur'
import {Link, Route}  from "react-router-dom";
import UbtLog from '../src/Images/UbtLogo.png'
import { Icon, InlineIcon } from '@iconify/react';
import home from '@iconify-icons/mdi/home';
import laptopicon from '@iconify-icons/mdi/laptop';
import baselineArchitecture from '@iconify-icons/ic/baseline-architecture';
import likeIcon from '@iconify-icons/topcoat/like';
import starFill from '@iconify-icons/bi/star-fill';
import OnlineMembers from './Components/OnlineMembers'
import Chat from "./Components/Chat";
import profileIcon from '@iconify-icons/vs/profile';

function HomePage(){

  
   if (window?.location.pathname === `/`)
  require(`../src/HomePage.css`)
return(
<div className="IndexPage" >
   <div className="MainNavBar">
      <nav> <a href="/login">SignUp</a></nav>
   </div>
   <div className="backgroundImage">
      <a href="/"> <img src={UbtLog} height="150px" width="150px"/></a>
   </div>
   <div className="mainWrapper">
      <div className="toplinecss"> UBT</div>
      <div className="secondWrapper">
         <div className="thirdWrapper">
            <div className="ContentBox">
               <div className="ContentBoxHeader">
                  <h3>Welcome </h3>
               </div>
               <div className="ContentBoxBody">
                  <p>Welcome to UBT. Please read forum rules & keep chatbox English at all times. Remember to run downloaded files in a Virtual Machine or Sandboxie.Do not trust anyone!</p>
               </div>
            </div>
            <div className="ContentBox chat">
               <div className="ContentBoxHeader">
                  <h3>ChatBox </h3>
               </div>
               <div className="ContentBoxBody">
                  <p>Welcome to UBT. Please read forum rules & keep chatbox English at all times. Remember to run downloaded files in a Virtual Machine or Sandboxie.Do not trust anyone!</p>
                  <div className="chatBox">
                      <Chat/>
                  </div>
               </div>
               <nav className="secondNav">
                  <ul>
                     <li>
                        <Link to="CSE" >
                        <InlineIcon icon={home} height="16px" width="16px"/>
                        &nbsp;Home</Link>
                     </li>
                     <li>
                        <Link to="Arkitektur" id="Selected"  >
                        <InlineIcon icon={laptopicon} height="16px" width="16px"/>
                        &nbsp;CSE</Link>
                     </li>
                     <li>
                        <Link to="CSE" >
                        <InlineIcon icon={baselineArchitecture} height="16px" width="16px"/>
                        &nbsp;Arkitektur</Link>
                     </li>
                  </ul>
               </nav>
               <Route exact path="/" component={CSE}/>
               <Route exact path="/arkitektur" component={Arkitektur}/>
            </div>
         </div>
         <div className="secondFeed">
            <div className="userstats">
               <div className="ContentBox">
                  <div className="ContentBoxHeader">
                     <h3>Welcome Back Sead </h3>
                  </div>
                  <div className="ContentBoxBody">
                     <ul>
                        <li>
                           <a>
                              <span>
                                 <InlineIcon icon={likeIcon} />
                              </span>
                              &nbsp;&nbsp;&nbsp;Likes <span>5</span>
                           </a>
                        </li>
                        <li>
                           <a>
                              <span>
                                 <InlineIcon icon={starFill} />
                              </span>
                              &nbsp;&nbsp;&nbsp;Reputation <span>5</span>
                           </a>
                        </li>
                        <li>
                           <a>
                              <span>
                                 <InlineIcon icon={likeIcon} />
                              </span>
                              &nbsp;&nbsp;&nbsp;Likes <span>5</span>
                           </a>
                        </li>
                        <li>
                           <a>
                              <span>
                                 <InlineIcon icon={likeIcon} />
                              </span>
                              &nbsp;&nbsp;&nbsp;Likes <span>5</span>
                           </a>
                        </li>
                     </ul>
                  </div>
               </div>
            </div>
            <div className="announcments">
               <div className="ContentBoxHeader">
                  <h3>Announcements </h3>
               </div>
               <div className="ContentBoxBody">
                  <ul>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                  </ul>
               </div>
            </div>
            <div className="LatestActivities">
               <div className="ContentBoxHeader">
                  <h3>LatestActivities </h3>
               </div>
               <div className="ContentBoxBody">
                  <ul>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                  </ul>
               </div>
            </div>
            <div className="LastTopics">
               <div className="ContentBoxHeader">
                  <h3>LastTopics </h3>
               </div>
               <div className="ContentBoxBody">
                  <ul>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                     <li>
                        <p><span>Icon</span>&nbsp;&nbsp;&nbsp;Title Goes here <span>5</span></p>
                        <p>By Jason, 2 hours ago</p>
                     </li>
                  </ul>
               </div>
            </div>
         </div>
      </div>
      <OnlineMembers/>
   </div>
</div>
)
}
export default HomePage;