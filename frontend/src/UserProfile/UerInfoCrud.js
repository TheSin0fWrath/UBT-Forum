
export default  async function getUser(id){
    var returndata;
    const options={
        method : "Get",
        headers:{
            "content-type":"application/json"
           
        }};
        await fetch(`http://localhost:5000/user/getuser/${id}`, options).then(response => response.json()).then(data => 
        {returndata=data}
        );   

        return await returndata;
      
}

export function deleterole(roleid,userid){
    const options={
        method : "Delete",
        headers:{
            "content-type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        }};
    fetch("http://localhost:5000/deleterole"+roleid+"/"+userid).then(x=>x.json())
    .then(data=>console.log(data))
    .catch(e=>{
        console.log(e)
    });
}
export function addrole(roleid,userid){

    const options={
        method : "Post",
        headers:{
            "content-type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        },
        body: JSON.stringify({
            User:userid,
            RoleId:roleid
        })
    };
    fetch("http://localhost:5000/api/addrole").then(x=>x.json())
    .then(data=>console.log(data))
    .catch(e=>{
        console.log(e)
    });
}
