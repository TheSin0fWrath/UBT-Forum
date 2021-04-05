import React, { useState } from "react";
import "./ComponentCss/ChatBox.css";

function Chat() {
  const [Message, setMessage] = useState("");

 

  return (
    <div className="CBox">
      <div className="ChatTable">
        <table>
          <tbody>
            <tr>
              <td width="10px">@</td>
              <td width="10%">SeadAhmeti</td>
              <td width="80%">Message</td>
              <td>Delete</td>
              <td>21:09</td>
            </tr>
            <tr className="CboxGrey">
              <td>@</td>
              <td>SeadAhmeti</td>
              <td>Message</td>
              <td>Delete</td>
              <td>21:03</td>
            </tr>
            
          </tbody>
        </table>
      </div>
      <form>
        <input
          type="text"
          onChange={(x) => setMessage(x.target.value)}
          placeholder="Message..."
        />
        <input type="button" value="Send" />
      </form>
    </div>
  );
}
export default Chat;

//message.map(d => (
  //     <tr className={d.id % 2 === 0 ? '' : 'CboxGrey'}>
  //       <td>@</td>
  //       <td key={d.name}>{d.name.toString()}</td>
  //       <td key={d.message}>{d.message.toString()}</td>
  //       <td>Delete</td>
  //       <td key={d.time}>{d.time.toString()}</td>
  //     </tr>
  //    ) );