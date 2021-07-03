import React, { useState,useMemo, useEffect } from "react";
import PopUp from "../Shared/Components/PopUp.js"
import {addRole,getRoles,deleteRole,updateRole} from "./AdminCrud";

export default function RoleManager(){
<<<<<<< HEAD
=======
    const [showPop,setShowPop]= useState(false);
    const [role,setRole]= useState({name:null,color:null});
    const [replayMessage,setReplay] =useState();
    const[showUpdatePop,setUpdatePop] =useState(false);
   const [data,setData]= useState([]);

   const test= async (id)=>{
   await deleteRole(id);
   window.location.reload();
   }
   const upRoleCrud = async ()=>{
    var replay =await updateRole(role);
    if(!replay.success){
        setReplay(replay.message)
    }
    else{
    window.location.reload();
}
   }
   const upRole =async (d) =>{
       setRole(d);
       setUpdatePop(true);
   }


   const submit = async ()=>{
       if(!(role.name==null || role.color==null)){
        var replay =await addRole(role); 
        console.log(replay);
        if(replay.success){
            setShowPop(false);
            window.location.reload();
        }
        else{
            setReplay(replay.message)
        }
       }
       else{
           setReplay("You need to pick a name and a color");
       }
        
    }
    useEffect( async ()=>{
       var replay = await getRoles();
       console.log(replay.data[0])
       setData(replay.data);
    },[]);
    const renderRoles = useMemo(()=>{ return data.map(d => { 
        return(  
        <tr>
        <td><div className="prewiewrole" style={{backgroundColor:d.color}}> 
        <p>{d.name}</p>
        </div></td>
        <td>{d.name}</td>
        <td>{d.date}</td>
        <td>{d.color}</td>
        <td>{d.default.toString()}</td>
        <td><span onClick={()=>{upRole(d)}}> Edit</span> | <span onClick={async ()=> await test(d.id)}>Delete</span> </td>
        </tr>
        
       ) })},[data]);
>>>>>>> 5df4f7f2b0e2d41c072e45a8c8c559417cbd3de3
    
    return(
        
        <>
      
            <div className="role">
            <button className="UbtForumButton" onClick={()=>{setShowPop(true)}}> Add Role </button><br></br>

                <div className="ContentBoxHeader">
                    <h3>Roles</h3>
                </div>
                <PopUp header="Role Managment" show={showPop}>
                    <form onSubmit={submit}>
                        <label style={{color:"white"}}>Role Name  {'\u00A0'}  
                        <input onChange={x=>setRole({...role,name:x.target.value})} className="Firs-Input-Text" type="text" required/> </label>
                        <label  style={{color:"white"}}>Role Color  {'\u00A0'}       
                        <input onChange={x=>setRole({...role,color:x.target.value})}  type="color" required/> </label>
                        <p style={{color:"red"}}>{replayMessage}</p>
                        <div className="formfoter">
                        <input className="UbtForumButton"  type="submit"value="Submit"/><br></br>
                        <button className="UbtForumButton" onClick={()=>{setShowPop(false)}}>Cancle</button><br></br>
                        </div>
                    </form>
           </PopUp>
                    {!showUpdatePop?<></>:<PopUp header="Role Managment" show={true}>
    <form onSubmit={upRoleCrud}>
        <label style={{color:"white"}}>Role Name  {'\u00A0'}  
        <input onChange={x=>setRole({...role,name:x.target.value})} defaultValue={role.name} className="Firs-Input-Text" type="text" required/> </label>
        <label  style={{color:"white"}}>Role Color  {'\u00A0'}       
        <input onChange={x=>setRole({...role,color:x.target.value})} defaultValue={role.color} type="color" required/> </label>
        <p style={{color:"red"}}>{replayMessage}</p>
        <div className="formfoter">
        <input className="UbtForumButton"  type="submit"value="Submit"/><br></br>
        <button className="UbtForumButton" onClick={()=>{setUpdatePop(false)}}>Cancle</button><br></br>
        </div>
    </form>
</PopUp>}
                <table>
                  <thead>
                     <tr>
                        <td width="20%">Preview</td>
                        <td width="20%">Role Name</td>
                        <td width="20%">Added Date</td>
                        <td width="15%">Color</td>
                        <td width="5%">Default</td>
                        <td width="20%">Settings </td>
                     </tr>
                  </thead>
                  <tbody>
                      {renderRoles}
                  </tbody>
               </table>
            </div>
       
        </>

    );
}