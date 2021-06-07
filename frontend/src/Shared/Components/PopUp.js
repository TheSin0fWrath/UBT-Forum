import React from "react";
import "./PopUp.css";

export default function PopUp({header,show,children}){
    
    if(!show){
        return null
    }
    return(
        <div className="popup">
        <div className="ContentBoxHeader popupheader">
                    <h3>{header}</h3>
                </div>
        <div className="popupbody">
            {children}
        </div>
        </div>

    );
}