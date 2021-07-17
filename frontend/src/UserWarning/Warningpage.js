import React,{useEffect, useState,useMemo} from "react";
import EmptyPage from '../Shared/Components/EmptyPage'
import PopUp from "../Shared/Components/PopUp"
import "../UserWarning/Warning.css"
export default function WarningPage(){
const [data,setData]= useState();
const [warning,setWarning] = useState({Id:0,Text:null,Points:null,ToUserId:null});
const [updatewarning,setupWarning] = useState({Id:0,Text:null,Points:null,ToUserId:null});
const [deleteId,setDeleteId]= useState();
const [editpop,seteditpop] = useState(false);
const [deletepop,setdeletepop] = useState(false);
const[isBusy,setbusy]=useState(true);
const userid=window.location.pathname.split("/").pop();
warning.ToUserId= userid;
const {REACT_APP_BASIC}= process.env;


//popupcontrolls
 const openeditpop=(warn)=>{
    setupWarning(warn);
    seteditpop(true);
 }

 const opendeletepop=(id)=>{
setdeletepop(true)
setDeleteId(id);
 }

 //Fetch Data
 //Post
 const addwarning=async ()=>{
    let options ={
        method : "POST",
        headers:{
            'Content-Type': 'application/json',
        'Accept': 'application/json',
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
          },
        body: JSON.stringify(warning)};
     let replay = fetch( REACT_APP_BASIC+"api/warning",options).then(response =>response.json());
     setbusy(true);
 }
//Get
useEffect(()=>{
    fetchdata();
    async function fetchdata(){
         let options ={
        method : "Get",
        headers:{
            'Content-Type': 'application/json',
        'Accept': 'application/json',
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
          }};
 let response = await fetch(REACT_APP_BASIC+"api/warning/"+userid,options).then(x=>x.json());
 setData(response);
 setbusy(false);
    }
    
},[isBusy,userid]);

//Delete
const deletewarning =async ()=>{
    let options ={
        method : "DELETE",
        headers:{
            'Content-Type': 'application/json',
        'Accept': 'application/json',
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
          }};
     let replay = fetch(REACT_APP_BASIC+"api/warning/"+deleteId,options).then(response =>response.json());
     setdeletepop(false)
     setbusy(true);
     
}

//Update
const updateWarning=async ()=>{
    let options ={
        method : "PUT",
        headers:{
            "content-type":"application/json",
            "Authorization":`Bearer ${window.localStorage.getItem("token")}`
          },
        body: JSON.stringify(updatewarning)};
     let replay = fetch(REACT_APP_BASIC+"api/warning",options).then(response =>response.json());
     seteditpop(false)
     setbusy(true);
    }

const render=useMemo(()=>{
    if(!isBusy){
   return  data.map(warning=>{
            return(
                <div className="WaningBox">
                <div className="UserWarningHeader">
                   <label>Admin</label>
                   <label>{warning.points} Points</label>
                </div>
                <p>{warning.text}</p>
                <div className="editWarning">
                   <button  className="UbtForumButton" onClick={()=>{openeditpop(warning)}}>Edit </button>
                   <button  className="UbtForumButton" onClick={()=>opendeletepop(warning.id)}>Delete </button>
                </div>
             </div>
            );
        })

    }},[data])
return(
     <div className="Warning">
    <EmptyPage>
   
        <div className="AddWarning">
            <h3>Warnings</h3>
            <textarea placeholder="Warning Message" onChange={x=>setWarning({...warning,Text: x.target.value})}></textarea>
            <div className="OtherSettings">
            <label>Warning Points  </label>
            <input type="number" defaultValue="0" onChange={x=>setWarning({...warning,Points: x.target.value})}/>
            </div>
            <button className="UbtForumButton" onClick={()=>{addwarning()}}>Add Warning</button>
        </div>
        <div className="WarningsOfUser">
            {render}
        </div>
    <PopUp className="editPopUp" show={editpop} header="Update Warning">
        <div className="AddWarning">
            <textarea placeholder="Warning Message"  defaultValue={updatewarning.text} onChange={x=>setupWarning({...updatewarning, Text: x.target.value})}></textarea>
            <div className="OtherSettings">
            <label>Warning Points  </label>
            <input type="number" defaultValue={updatewarning.points} onChange={x=>setupWarning({...updatewarning, Points: x.target.value})}/>
            </div>
            <div className="popupfooter">
            <button className="UbtForumButton" onClick={()=>{updateWarning()}}>Update</button>
            <button className="UbtForumButton" onClick={()=>{
    seteditpop(false)
}}>Cancle</button>
            </div>
        </div>

    </PopUp>

     <PopUp className="deletepop" show={deletepop} header="Delete Warning">

      <p>Are you sure you wanna delete this warning?</p>
            <div className="popupfooter">
            <button className="UbtForumButton" onClick={()=>{deletewarning()}}>Delete</button>
            <button className="UbtForumButton" onClick={()=>{
    setdeletepop(false)
}}>Cancle</button>
            </div>
    </PopUp>


    </EmptyPage>
        </div>

);

}