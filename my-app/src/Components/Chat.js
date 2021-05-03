import React, { useCallback, useEffect, useState } from "react";
import "./ComponentCss/ChatBox.css";
import {updateChat,sendMessage,deleteMessage} from "../hooks/ChatCrud"
import UseFormInput from "../hooks/UseFormInput"
import DateDiff from "../hooks/DateDiff";

function Chat({user}) {
  const Message =UseFormInput("");
  const [post,setPosts]=useState([]);
  const [sendmessage,setSend] =useState("SEND")

async function send(){
  await sendMessage("user",Message.value)
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
  <tr className={d.id % 2 === 0 ? '' : 'CboxGrey'}>
    <td>@</td>
    <td key={d.username}><a href={`/user/${d.userId}`}>{d.username}</a></td>
    <td key={d.text}>{d.text}</td>
    {d.userId==user.nameid && <td onClick={async ()=> await deleteMessage(d.id)} style ={{cursor:"pointer"}}key ={"delete"}>Delete</td>}
    {d.userId!=user.nameid && <td></td>}
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

