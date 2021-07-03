import React from "react";
<<<<<<< HEAD
import { Route, Switch,Link, HashRouter } from "react-router-dom";
import EmptyPage from "../Shared/Components/EmptyPage";
import Awards from "./Awards";
import RoleManager from "./RoleManager";
import CitysList from "./Citys";
import "./Admin.css";
=======
import { Route, Switch,Link, HashRouter, BrowserRouter } from "react-router-dom";
import EmptyPage from "../Shared/Components/EmptyPage"
import Awards from "./Awards"
import RoleManager from "./RoleManager";
import "./Admin.css"
>>>>>>> 5df4f7f2b0e2d41c072e45a8c8c559417cbd3de3

export default function AdminPanel(){

    return(
        <div className="adminPanel">
            
            <EmptyPage path="adminPanel">
            <div className="ContentBoxHeader">
                  <h3>Welcome To Admin Panel </h3>
               </div>
               <div className="panel">
               <div className="panelBody">
<<<<<<< HEAD
                    <HashRouter hashType="noslash">
                  
                    <Route  exact path="/rolemanager"> <RoleManager/></Route>
                    <Route exact path="/awards"> <Awards/></Route>
                    <Route exact path="/citys"> <CitysList/></Route>

=======
>>>>>>> 5df4f7f2b0e2d41c072e45a8c8c559417cbd3de3
                   
                   <Route  exact path="/adminPanel/rolemanager" component={RoleManager}/>
                  <Route exact path="/adminPanel/awards"  component={Awards}/> 
                 
               </div>
                  <div className="panelNav">
                  <nav>
                <ul>
<<<<<<< HEAD
                <li><Link to={{hash:"awards"}} style={{color:"white",fontSize:"14px"}}>Awards</Link></li>
                    <li><Link to={{hash:"citys"}} style={{color:"white",fontSize:"14px"}}>Citys</Link></li>
                    <li><Link to={{hash:"rolemanager"}} style={{color:"white",fontSize:"14px"}}>Roles</Link></li>
                    
=======
                 
                <li>
                    <Link to={"/adminPanel/awards"}  style={{color:"white",fontSize:"14px"}}>Awards</Link></li>
                    <li><Link to={"/adminPanel/rolemanager"} style={{color:"white",fontSize:"14px"}}>Roles</Link>
                    </li>
                   
>>>>>>> 5df4f7f2b0e2d41c072e45a8c8c559417cbd3de3
                </ul>
                </nav>
                  </div>
                  </div>
            </EmptyPage>

        </div>
    )
}