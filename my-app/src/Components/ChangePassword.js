import React, { useState } from "react";
import  "./ComponentCss/ChangePassword.css"

export default function ChangePassword (){
const [password,setPassword]=useState({password:null,rpassword:null,currentpassword:null})
const [message,setMessage] =useState();

async function changePassword(e){
    e.preventDefault();
    if (password.password==null &&password.rpassword==null){
        return;
    }
    else if(password.password != password.rpassword){
        setMessage("Please make sure to use the same password")
    }
    else{
        const options ={
            method:"Put",
            headers:{
                "Content-Type":"application/json",
                "Authorization":`Bearer ${window.localStorage.getItem("token")}`
            },
            body: JSON.stringify(password)
        };
           fetch("http://localhost:5000/auth/",options)
           .then(resp => resp.json())
           .then(data=>{setMessage(data.message)});
     
    }
}

    return(
<div className="changePassword">
    <form onSubmit={changePassword}>
        <label>Current Password </label>
        <input type="text" onChange={x=>setPassword({...password,currentpassword:x.target.value})} />  <br/><br/>
        <label>New Password  </label>
        <input type="text" onChange={x=>setPassword({...password,password:x.target.value})} minLength="8" required/>  <br/><br/>
        <label>Repeat Password</label>
        <input type="text" onChange={x=>setPassword({...password,rpassword:x.target.value})} minLength="8" required/>   <br/><br/>
        <p>{message}</p><br></br>
        <input type="Submit" value="Submit"/>
        </form>
        
    
</div>

    );
}