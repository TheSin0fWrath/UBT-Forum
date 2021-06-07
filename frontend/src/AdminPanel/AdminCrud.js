
const {REACT_APP_API}= process.env;

export async function addRole(data){
    var replay;
    const options ={
        method:"Post",
        headers:{
            "Content-Type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        },
        body: JSON.stringify(data)
    };

   await fetch(REACT_APP_API+"role",options).
   then(x=>x.json())
   .then(y=>{  replay = y})
   return await replay
}
export async function getRoles(){
    var replay;
    const options ={
        method:"Get",
        headers:{
            "Content-Type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        }
      
    };

   await fetch(REACT_APP_API+"role",options).
   then(x=>x.json())
   .then(y=>{  replay = y})
   return await replay
}


export async function deleteRole(id){
    var replay;
    const options ={
        method:"Delete",
        headers:{
            "Content-Type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        }
      
    };

   await fetch(REACT_APP_API+`role/${id}`,options).
   then(x=>x.json())
   .then(y=>{  replay = y})
   return await replay
}


export async function updateRole(data){
    var replay;
    const options ={
        method:"Put",
        headers:{
            "Content-Type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        },
        body: JSON.stringify(data)
    };

   await fetch(REACT_APP_API+"role",options).
   then(x=>x.json())
   .then(y=>{  replay = y})
   return await replay;
}