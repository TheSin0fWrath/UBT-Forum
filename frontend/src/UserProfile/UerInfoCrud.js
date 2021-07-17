const {REACT_APP_BASIC}= process.env;

export   async function getUser(id){
    var returndata;
    const options={
        method : "Get",
        headers:{
            "content-type":"application/json"
           
        }};
        await fetch(REACT_APP_BASIC+`user/getuser/${id}`, options).then(response => response.json()).then(data => 
        {returndata=data}
        );   

        return await returndata;
      
}

export async function deleterole(id){
    var response;
    const options={
        method : "Delete",
        headers:{
            "content-type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        }};
    await fetch(REACT_APP_BASIC+"api/v1/userole/"+id,options).then(x=>x.json())
    .then(data=>{response=data});
    return await response;

}
export async function addrole(roleid,userid){

    const options={
        method : "Post",
        headers:{
            "content-type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        },
        body: JSON.stringify({
            UserId:userid,
            RoleId:roleid
        })
    };
    await fetch(REACT_APP_BASIC+"api/v1/userole",options).then(x=>x.json())
    .then(data=>console.log(data))
    .catch(e=>{
        console.log(e)
    });
}
