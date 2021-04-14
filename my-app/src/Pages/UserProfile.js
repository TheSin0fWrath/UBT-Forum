import React, { useEffect, useState } from "react";
import EmptyPage from "../Components/EmptyPage"
import getUser from "./cruds/UerInfoCrud"

export default  function UserProfile(){

    const userid=window.location.pathname.split("/").pop();
    const [data,setData]=useState({username:"",likes:"",reputation:"",dateOfJoining:"",conntact:"",gjenerata:"",posts:"",threads:"",warningLevel:"" });
    
    async function getData (){
       const response= await getUser(userid);
        setData(await response.data)
    }
    getData();

    return(
        <div className="UserProfile">
           <EmptyPage  path="/user">
               <div className="header">
                   <div className="userPic">
                   <img src="https://uxwing.com/wp-content/themes/uxwing/download/12-people-gesture/user-profile.png" width="150px" height="150px"/>
                   <div className="userpicin">
                   <p>{data.username}</p>
                   <p>Student</p>
                   </div>
                   </div>
               </div>
               <div className="userstats">
                   <div className="information">
                       <div className="showBox">
                           <p>{data.likes}</p>
                           <p>Likes</p>
                       </div>
                       <div className="showBox">
                       <p>{data.reputation}</p>
                           <p>Reputation</p>
                       </div>
                   <div className="ContentBox">
               <div className="ContentBoxHeader">
                  <h3>Information </h3>
               </div>
               <div className="ContentBoxBody">
               <table>
                       <tbody>
                           <tr>
                           <td width="3%">Icon</td>
                               <td width="100%">Joined:</td>
                            <td>{data.dateOfJoining}</td>
                           </tr>
                           <tr>
                           <td width="5%">Icon</td>
                               <td>Email:</td>
                               <td>{data.conntact}</td>
                           </tr>
                           <tr>
                           <td width="5%">Icon</td>
                               <td>Gjenerata:</td>
                               <td>{data.gjenerata}</td>
                           </tr>
                           <tr>
                           <td width="5%">Icon</td>
                               <td>Drejtimi:</td>
                               <td>{data.drejtimi}</td>
                           </tr>
                           </tbody>
                           </table>
               </div>
            </div>
                   </div>
                   <div className="stats">
                   <div className="ContentBox">
               <div className="ContentBoxHeader">
                  <h3>Stats </h3>
               </div>
               <div className="ContentBoxBody">
                   <div className="statsTable">
                   <table>
                       <tbody>
                           <tr>
                           <td width="5%">Icon</td>
                               <td>Posts:</td>
                               <td>{data.posts}</td>
                           </tr>
                           <tr>
                           <td>Icon</td>
                               <td>Likes:</td>
                               <td>{data.likes}</td>
                           </tr>
                           <tr>
                           <td>Icon</td>
                               <td>Reputation:</td>
                               <td>{data.reputation}</td>
                           </tr>
                           <tr>
                           <td>Icon</td>
                               <td>Warning:</td>
                               <td>{data.warningLevel}</td>
                           </tr>
                       </tbody>
                   </table>
                   <table>
                       <tbody>
                           <tr>
                           <td width="5%">Icon</td>
                               <td>Threads:</td>
                               <td>{data.threads}</td>
                           </tr>
                           <tr>
                           <td>Icon</td>
                               <td>Credits:</td>
                               <td>{data.credits}</td>
                           </tr>
                           <tr>
                           <td>Icon</td>
                               <td>Reported posts:</td>
                               <td>{data.reportedPosts}</td>
                           </tr>
                           <tr>
                           <td>Icon</td>
                               <td>Warning:</td>
                               <td>{data.reportedPosts}</td>
                           </tr>
                       </tbody>
                   </table>
               
                 </div>
                
               </div>
               
            </div> <div className="ContentBox last">
               <div className="ContentBoxHeader">
                  <h3>TItulli</h3>
               </div>
               <div className="ContentBoxBody last">
                   <p>STUDENT</p>
               </div>
               </div>
                   </div>
               </div>
            </EmptyPage>

        </div>

    )
}