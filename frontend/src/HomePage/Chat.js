import React, { useCallback, useEffect, useState,useMemo,useContext } from "react";
import "./ChatBox.css";
import {updateChat,sendMessage,deleteMessage} from "./ChatCrud"
import UseFormInput from "../Shared/hooks/UseFormInput"
import DateDiff from "../Shared/hooks/DateDiff";
import { UserContext } from '../Shared/hooks/UserContext';

function Chat() {
  const Message =UseFormInput("");
  const [post,setPosts]=useState([]);
  const [sendmessage,setSend] =useState("SEND")
  const {user,setUser} = useContext(UserContext);

async function send(){
  await sendMessage("user",Message.value)
}
function checkUser(i){
   if(user!=null){
     if(user.nameid==i || user.role=="Admin"){
      return true;
     }
   
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

  const mes = useMemo(()=>{ return post.map(d => { 
    var index=1;
    return(  
    <tr>
      <td>@</td>
      <td key={d.username+index++}><a href={`/user/${d.userId}`}>{d.username}</a></td>
      <td key={d.text+index++}>{d.text}</td>
      {(checkUser(d.userId))?(<td onClick={async ()=> await deleteMessage(d.id)} style ={{cursor:"pointer"}}key ={"delete"}>Delete</td>): <td></td>}
      <td key={d.time+index++}>{ clacdate(d.time)}</td>
    </tr>
   ) })},[post]);


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

