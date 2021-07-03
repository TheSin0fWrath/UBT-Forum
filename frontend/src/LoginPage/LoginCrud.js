const {REACT_APP_AUTH}= process.env;

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
await fetch(REACT_APP_AUTH+"login",options).then(response => response.json())
.then(data => {
    message.message=data.message
    message.success=data.success
    message.data=data.data

});
if (message.success===true){
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
await fetch(REACT_APP_AUTH+"register",options).then(response => response.json())
.then(data => {
response =data;
});
<<<<<<< HEAD
console.log(response,'Registered');
=======
>>>>>>> 5df4f7f2b0e2d41c072e45a8c8c559417cbd3de3
return await response;
}
export { LoginCrud,RegisterCrud};