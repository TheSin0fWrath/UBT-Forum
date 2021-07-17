import React,{useState} from "react";
import EmptyPage from '../Shared/Components/EmptyPage'
import PopUp from "../Shared/Components/PopUp"
import "../UserWarning/Warning.css"
export default function WarningPage(){
const [waning,setWarning] = useState({Id:null,Message:null,Points:null});
const [isBusy,setIsBusy] = useState(false);
const [editpop,seteditpop] = useState(false);
const [deletepop,setdeletepop] = useState(false);

 const openeditpop=()=>{
     
    seteditpop(true)

 }

 const opendeletepop=()=>{
setdeletepop(true)
 }

return(
     <div className="Warning">
    <EmptyPage>
   
        <div className="AddWarning">
            <h3>Warnings</h3>
            <textarea placeholder="Warning Message"></textarea>
            <div className="OtherSettings">
            <label>Warning Points  </label>
            <input type="number"/>
            </div>
            <button className="UbtForumButton"> Add Warning</button>
        </div>
        <div className="WarningsOfUser">
          <div className="WaningBox">
              <div className="UserWarningHeader">
              <label>Admin</label>
            <label>20 Points</label>
              </div>
               <p>Message goes here</p>
            <div className="editWarning">
                <button  className="UbtForumButton" onClick={openeditpop}>Edit </button>
                 <button  className="UbtForumButton" onClick={setdeletepop}>Delete </button>
            </div>
          </div>
           
        </div>
    <PopUp className="editPopUp" show={editpop} header="Update Warning">

        <div className="AddWarning">
            <textarea placeholder="Warning Message"></textarea>
            <div className="OtherSettings">
            <label>Warning Points  </label>
            <input type="number"/>
            </div>
            <div className="popupfooter">
            <button className="UbtForumButton">Update</button>
            <button className="UbtForumButton" onClick={()=>{
    seteditpop(false)
}}>Cancle</button>
            </div>
        </div>

    </PopUp>

     <PopUp className="deletepop" show={deletepop} header="Delete Warning">

      <p>Are you sure you wanna delete this warning?</p>
            <div className="popupfooter">
            <button className="UbtForumButton">Delete</button>
            <button className="UbtForumButton" onClick={()=>{
    setdeletepop(false)
}}>Cancle</button>
            </div>
    </PopUp>


    </EmptyPage>
        </div>

);

}