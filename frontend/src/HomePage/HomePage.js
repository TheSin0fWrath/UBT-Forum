import React, { useContext, useEffect, useState } from 'react';
// import "../src/HomePage.css"

import {Home,Arkitektur, CSE} from './Subjects/Subjects'
import {Link, Route}  from "react-router-dom";
import UbtLog from '../Shared/Images/UbtLogo.png'
import { Icon, InlineIcon } from '@iconify/react';

import likeIcon from '@iconify-icons/topcoat/like';
import starFill from '@iconify-icons/bi/star-fill';
import OnlineMembers from './OnlineMembers'
import Chat from "./Chat";
import "./HomePage.css"
import { UserContext } from '../Shared/hooks/UserContext';
import getUser from "../UserProfile/UerInfoCrud"

function HomePage(){
   const {user,setUser} = useContext(UserContext)
   const [data,setData]=useState({username:"",likes:"",reputation:"",dateOfJoining:"",conntact:"",gjenerata:"",posts:"",threads:"",warningLevel:"" });

   
   useEffect(async()=>{
      if(user!=""){
         console.log(user)
      const response= await getUser(user.nameid)
      setData(await response.data);    
      console.log(response); 
   }
   },[user])

  
   if (window?.location.pathname=== `/`)
  require(`../HomePage/HomePage.css`)

return(
<div className="IndexPage" >
   <div className="MainNavBar">
     
      {user?(<nav> <p onClick={async ()=>{window.localStorage.removeItem("token");window.location.reload()}}>SignOut</p> <a href={`/user/${user.nameid}`}>MyProfile</a></nav>):(  <nav> <a href="/login">SignUp</a></nav>)}
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
                      <Chat user={user}/>
                  </div>
               </div>
               <nav className="secondNav">
                  <ul>
                     <li>
                        <Link to="/" >
                        &nbsp;Home</Link>
                     </li>
                  
                     <li>
                        <Link to="/CSE" >
                        &nbsp;CSE</Link>
                     </li>
   
                        
                  </ul>
               </nav>
               <Route exact path="/" component={Home}/>
               <Route exact path="/CSE" component={CSE}/>
            </div>
         </div>
         <div className="secondFeed">
            {user?(<div className="userstats">
               <div className="ContentBox">
                  <div className="ContentBoxHeader">
                     <h3>Welcome Back {user.name} </h3>
                  </div>
                  <div className="ContentBoxBody">
                     <ul>
                        <li>
                           <a>
                              <span>
                                 <InlineIcon icon={likeIcon} />
                              </span>
                              &nbsp;&nbsp;&nbsp;Likes <span>{data.likes}</span>
                           </a>
                        </li>
                        <li>
                           <a>
                              <span>
                                 <InlineIcon icon={starFill} />
                              </span>
                              &nbsp;&nbsp;&nbsp;Reputation <span>{data.reputation}</span>
                           </a>
                        </li>
                        <li>
                           <a>
                              <span>
                                 <InlineIcon icon={likeIcon} />
                              </span>
                              &nbsp;&nbsp;&nbsp;Likes <span>{data.likes}</span>
                           </a>
                        </li>
                        <li>
                           <a>
                              <span>
                                 <InlineIcon icon={likeIcon} />
                              </span>
                              &nbsp;&nbsp;&nbsp;Likes <span>{data.likes}</span>
                           </a>
                        </li>
                     </ul>
                  </div>
               </div>
            </div>):(null)}
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