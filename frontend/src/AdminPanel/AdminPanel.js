import React from "react";
import { Route, Switch } from "react-router";
import EmptyPage from "../Shared/Components/EmptyPage"
import Awards from "./Awards"
import "./Admin.css"

export default function AdminPanel(){

    return(
        <div className="adminPanel">
            
            <EmptyPage path="adminPanel">
            <div className="ContentBoxHeader">
                  <h3>Welcome To Admin Panel </h3>
               </div>
               <div className="panel">
               <div className="panelBody">
                   <Switch>
                       <Route path="/"> <Awards/></Route>
                   </Switch>
               </div>
                  <div className="panelNav">
                  <nav>
                <ul>
                    <li><a style={{color:"white",fontSize:"14px"}}>Awards</a></li>
                    <li><a style={{color:"white",fontSize:"14px"}}>Roles</a></li>
                    <li><a style={{color:"white",fontSize:"14px"}}>Citys</a></li>
                    
                </ul>
                </nav>
                  </div>
                  </div>
            </EmptyPage>

        </div>
    )
}