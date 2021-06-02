
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