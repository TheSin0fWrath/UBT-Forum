import React from "react";
import jwt_decode from "jwt-decode";

export async  function CheckLogin (){
    var dbresponse;
    var id;
    const options ={
        method: "Get",
        headers:{
            "content-type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
          }};
    await fetch("http://localhost:5000/auth/checklogin", options).then(response =>{dbresponse=response.statusText});
    if (await dbresponse ==="OK"){
        var token =  window.localStorage.getItem("token");
        console.log(dbresponse)
        id= jwt_decode(token)
   
        
    }
  return (id);
}