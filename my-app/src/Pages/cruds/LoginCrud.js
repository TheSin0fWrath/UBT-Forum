import React, { cloneElement, createContext } from 'react';

 async function LoginCrud( data){
    var message={
        message:"",
        data:"",
        success:false
    };
    const dataa={
        username:data.username,
        password : data.password
    }
  
const options= {
    method:"Post",
    headers: { "content-type":"application/json"},
    body: JSON.stringify(dataa)
}
await fetch("http://localhost:5000/auth/login",options).then(response => response.json())
.then(data => {
    message.message=data.message
    message.success=data.success
    message.data=data.data

});
if (message.success==true){
    localStorage.setItem('token', message.data)
    window.location.href = '/';

}
console.log(message)
return await message;
}

async function RegisterCrud(d){
var response;
const credintials=d;
const options= {
    method:"Post",
    headers: { "content-type":"application/json"},
    body: JSON.stringify(credintials)
}
await fetch("http://localhost:5000/auth/register",options).then(response => response.json())
.then(data => {
response =data;
});
console.log(response)
return await response;
}
export { LoginCrud,RegisterCrud};