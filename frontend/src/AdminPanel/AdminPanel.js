import React from "react";
import { Route, Switch,Link, HashRouter } from "react-router-dom";
import EmptyPage from "../Shared/Components/EmptyPage"
import Awards from "./Awards"
import RoleManager from "./RoleManager"
import "./Admin.css"
import Niveli from "./Niveli"


export default function AdminPanel(){

    return(
        <div className="adminPanel">
            
            <EmptyPage path="adminPanel">
            <div className="ContentBoxHeader">
                  <h3>Welcome To Admin Panel </h3>
               </div>
               <div className="panel">
               <div className="panelBody">
                   <HashRouter hashType="noslash">
                  
                   <Route  exact path="/rolemanager"> <RoleManager/></Route>
                  <Route exact path="/awards"> <Awards/></Route>
                  <Route exact path="/Niveli"> <Niveli/></Route>
                   
                   </HashRouter>
               </div>
                  <div className="panelNav">
                  <nav>
                <ul>
                <li><Link to={{hash:"awards"}} style={{color:"white",fontSize:"14px"}}>Awards</Link></li>
                    <li><Link to={{hash:"city"}} style={{color:"white",fontSize:"14px"}}>Citys</Link></li>
                    <li><Link to={{hash:"rolemanager"}} style={{color:"white",fontSize:"14px"}}>Roles</Link></li>
                    
                </ul>
                </nav>
                  </div>
                  </div>
            </EmptyPage>

        </div>
    )
}