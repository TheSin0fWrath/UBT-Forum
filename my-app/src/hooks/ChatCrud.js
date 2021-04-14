

export  async function updateChat(){

    var dataArray;
        const options={
        method : "Get",
        headers:{
            "content-type":"application/json"
           
        }};
        await fetch("http://localhost:5000/api/v1/chatBox", options).then(response => response.json()).then(data => {
           dataArray= (data.data)
        });   
      
        return await dataArray

}
export async function  sendMessage(u, p){
    var date = new Date();

  const credintials ={ username:u,text: p,time:date};
  const dbData={
      message :"",
      success:false,
  data:""};
console.log(window.localStorage.getItem("token"))
  const options ={
      method : "POST",
      headers:{
          "content-type":"application/json",
          "Authorization":`Bearer ${window.localStorage.getItem("token")}`
        },
      body: JSON.stringify(credintials)};
      await fetch("http://localhost:5000/api/v1/chatBox", options).then(response => response.json()).then(data => {
          dbData.message =data.message;
          dbData.success = data.success;
          dbData.data = data.data;
        
      });   
      
  }
  export async function  deleteMessage(id){
  const dbData={
      message :"",
      success:false,data:""};

  const options ={
      method : "DELETE",
      headers:{"content-type":"application/json","Authorization":`Bearer ${window.localStorage.getItem("token")}`}
  }
      await fetch(`http://localhost:5000/api/v1/chatBox/${id}`, options).then(response => response.json()).then(data => {
          dbData.message =data.message;
          dbData.success = data.success;
          dbData.data = data.data;
      });   
      
  }