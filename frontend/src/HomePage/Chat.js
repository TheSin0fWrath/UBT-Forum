import React, { useCallback, useEffect, useState } from "react";
import "./ChatBox.css";
import {updateChat,sendMessage,deleteMessage} from "./ChatCrud"
import UseFormInput from "../Shared/hooks/UseFormInput"
import DateDiff from "../Shared/hooks/DateDiff";

function Chat({user}) {
  const Message =UseFormInput("");
  const [post,setPosts]=useState([]);
  const [sendmessage,setSend] =useState("SEND")

async function send(){
  await sendMessage("user",Message.value)
}
function checkUser(i){
  console.log("a")
   if(user.id==i){
    return true;
  }
  return false
}

    // eslint-disable-next-line react-hooks/exhaustive-deps
    useEffect( async () => {
       const  interval = await setInterval(async ()=>{ await setPosts(await updateChat())},2000);
      return () => {
        clearInterval(interval);
      };
    }, [])
function clacdate(date){
  return DateDiff(date)
}

  const mes =post.map(d =>  (  
  
  <tr>
    <td>@</td>
    <td key={d.username}><a href={`/user/${d.userId}`}>{d.username}</a></td>
    <td key={d.text}>{d.text}</td>
    {(checkUser(d.userId))?(<td onClick={async ()=> await deleteMessage(d.id)} style ={{cursor:"pointer"}}key ={"delete"}>Delete</td>): <td></td>}
    <td key={d.time}>{ clacdate(d.time)}</td>
  </tr>
 ) );


  return (
    <div className="CBox">
      <div className="ChatTable">
        <table>
          <tbody>
           
            {mes }
          </tbody>
        </table>
      </div>
    
        {user?( <form><input   {...Message}type="text"placeholder="Message..."/> <input type="button" onClick={send} value={sendmessage} /> </form>):(null)}
        
       
      
    </div>
  );
}
export default Chat;

