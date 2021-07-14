import React from "react";
import { Route, Switch,Link, HashRouter, BrowserRouter } from "react-router-dom";
import EmptyPage from "../Shared/Components/EmptyPage"
import Awards from "./Awards"
import RoleManager from "./RoleManager";
import "./Admin.css"
import CitysList from "./Citys";

export default function AdminPanel(){

    return(
        <div className="adminPanel">
            
            <EmptyPage path="adminPanel">
            <div className="ContentBoxHeader">
                  <h3>Welcome To Admin Panel </h3>
               </div>
               <div className="panel">
               <div className="panelBody">
                   
                   <Route  exact path="/adminPanel/rolemanager" component={RoleManager}/>
                  <Route exact path="/adminPanel/awards"  component={Awards}/> 
                  <Route exact path="/adminPanel/City"  component={CitysList}/> 

                 
               </div>
                  <div className="panelNav">
                  <nav>
                <ul>
                 
                <li>
                    <Link to={"/adminPanel/awards"}  style={{color:"white",fontSize:"14px"}}>Awards</Link></li>
                    <li><Link to={"/adminPanel/rolemanager"} style={{color:"white",fontSize:"14px"}}>Roles</Link>
                    <li><Link to={"/adminPanel/City"} style={{color:"white",fontSize:"14px"}}>City</Link></li>

                    </li>
                   
                </ul>
                </nav>
                  </div>
                  </div>
            </EmptyPage>

        </div>
    )
}