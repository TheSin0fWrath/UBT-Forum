import React from "react";
import jwt_decode from "jwt-decode";
const {REACT_APP_AUTH}= process.env;
export async  function CheckLogin (){
    var dbresponse;
    var id;
    const options ={
        method: "Get",
        headers:{
            "content-type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
          }};
    await fetch(REACT_APP_AUTH+"checklogin", options).then(response =>{dbresponse=response.statusText});
    if (await dbresponse ==="OK"){
        var token =  window.localStorage.getItem("token");
        console.log(dbresponse)
        try {
          id= jwt_decode(token)
         
        } catch(error) {
          // invalid token format
        }
      
   
        
    }
  return (id);
}