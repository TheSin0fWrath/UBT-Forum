import React, { useContext, useEffect, useMemo, useState } from 'react';
import { Route, Switch,Link, HashRouter } from "react-router-dom";
import EmptyPage from "../Shared/Components/EmptyPage"
import {getUser,deleterole,addrole} from "./UerInfoCrud"
import "./Profile.css"
import { UserContext } from '../Shared/hooks/UserContext';
import PopUp from "../Shared/Components/PopUp.js"


export default  function UserProfile(){
    const {user,setUser} = useContext(UserContext)
    const userid=window.location.pathname.split("/").pop();
    const [data,setData]=useState({allroles:"",username:"",likes:"",reputation:"",dateOfJoining:"",conntact:"",gjenerata:"",posts:"",threads:"",warningLevel:"",role:"" });
    const [showpopup,setShowpop] = useState(false);
    const[confirmroledelete, setconfirmdelete]= useState(true);
    const [delrole,setdeleterole]=useState();
    const [updaterole,setupdateRole]=useState({name:"",id:""});
    const[refreshrole,setrefreshrole] =useState(false);

    const [busy,setbusy]= useState(true);
   useEffect(async ()=>{const response= await getUser(userid);
    setData(await response.data)

},[refreshrole])

    const role = useMemo(()=>{   
               if(data.role!=""){
        
                   switch(data.role[0].role.name){
                       case "Student":return <p className="student" style={{backgroundColor:data.role[0].role.color}}>Student</p>;break;
                       case "Profesor":return <p className="profesor" style={{backgroundColor:data.role.[0].role.color}}>Profesor</p>;break;
                       case "Admin":return <p className="admin" style={{backgroundColor:data.role[0].role.color}}>Admin</p>;break;
                   }
               }
         
        },[data])
        const allroles = useMemo(()=>{

            if(data.role !==""){
               return  data.role.map((role)=>{
                    return (<p  key={role.id} className="popuprole" style={{backgroundColor:role.role.color}}>{role.role.name} <span onClick={(e)=>{
                        setconfirmdelete(!confirmroledelete)
                        setdeleterole(role.id)
                        console.log(role)
                    }}>X</span></p>)
                
                })
            }
        },[data])

    
    return(
        <div className="UserProfile">
           <EmptyPage  path="/user">
               <div className="header">
                   <div className="userPic">
                   <img src="https://uxwing.com/wp-content/themes/uxwing/download/12-people-gesture/user-profile.png" width="150px" height="150px"/>
                   <div className="userpicin">
                   <p>{data.username}</p>
                   {role}
                   </div>
                   </div>
                   <div>
                   {(user!=null&&user!=""&&user.role.includes("Admin")) && <button class="UbtForumButton" onClick={()=>{setShowpop(true)}}>Update User</button>}
                   {(user!=null&&userid==user.nameid) && <button class="UbtForumButton" onClick={()=>{window.location.pathname=`editprofile`}}>Edit Profile</button>}
                   </div>
                   <PopUp header="User Managment" show={showpopup}>
                    <form>
                        <div className="useralloles">
                            <p
                            style={{
                                color:"white",
                                marginLeft:10,
                                fontSize:14
                            }}
                            >User roles: </p>
                        {allroles}
                        
                        </div>
                        {confirmroledelete?<></>:<div className="confirmroledelete">
                        <p>Are you sure you want to delete this role ?</p>
                        <button className="UbtForumButton" onClick={async (e)=>{
                            e.preventDefault();
                            var response = await deleterole(delrole);
                            setconfirmdelete(!confirmroledelete)
                            setrefreshrole(!refreshrole)
                            console.log(response)
                        }}>YES</button>
                        <button  className="UbtForumButton" onClick={async e=>{
                            e.preventDefault()
                          
                            setconfirmdelete(!confirmroledelete)

                        }}>NO</button>
                    </div>}
                        <div className="addrole">
                            <select  onChange={
                                (x)=>{
                                    setupdateRole({...updaterole, id:x.target.value})
                                  
                                }

                            }>
                                <option selected>Select Role</option>
                              {(data.allroles!=="") && data.allRoles.map(role=>{
                              return(<option value={role.id}>{role.name}</option>)
                            })
                              }
                              
                       
                            </select>
                            <button className="UbtForumButton" 
                            onClick={
                                async (x)=>{
                                    x.preventDefault();
                                    var response = await addrole(updaterole.id,userid)
                                    console.log(response)
                                  
                                       setrefreshrole(!refreshrole)
                                   
                                }

                            }
                            > Add Role</button>
                        </div>
                    <div className="formfoter">
                        
                        <button className="UbtForumButton" onClick={()=>{setShowpop(false)}}>Cancle</button><br></br>
                        </div>
                    </form>
                 
           </PopUp>
           
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
                               <td>{data.email}</td>
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
                               <td><a href={`http://localhost:3000/reputation/${userid}`}>Reputation:</a></td>
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
               <div className="ContentBoxBody last ">
                   {/* <p className="profesor">{data.role!=""&& data.role[0].role.name}</p> */}
                   {role}
               </div>
               </div>
                   </div>
                   <div className="awardsStats">
              <div className="ContentBox">
                  <div className="ContentBoxHeader">
                      <h3>Users Awards</h3>
                  </div>
                  <div className="ContentBoxBody">
                      
                  </div>
              </div>
               </div>
               </div>
            </EmptyPage>

        </div>

    )
}