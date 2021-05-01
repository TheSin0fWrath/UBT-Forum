import React from "react";
import EmptyPage from "../Components/EmptyPage"
import   "./EditProfile.css"
import ChangePassword from "../Components/ChangePassword.js"

export default function profileEdit(){

    return(
        <EmptyPage path={"/editProfile"}>
            <div className="editProfile">
                <nav>
                <ul>
                    <li><a style={{color:"white",fontSize:"15px"}}>User Settings</a></li>
                    <li><a>Change Password</a></li>
                </ul>
                </nav>
                
                <ChangePassword/>
            </div>
         
        </EmptyPage>
    );
}