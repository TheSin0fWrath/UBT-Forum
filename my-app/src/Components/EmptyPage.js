import React, { Children } from 'react';
import UbtLog from '../Images/UbtLogo.png'
import importcss from "../hooks/importcss";



export default function EmptyPage  ({title,desc,path,children}){
   importcss(`${path}`,`Threads.css`);
return(
<div className="IndexPage">
   <div className="MainNavBar">
      <nav> </nav>
   </div>
   <div className="backgroundImage">
   <a href="/"> <img src={UbtLog} height="150px" width="150px"/></a>
   </div>
   <div className="mainWrapper">
      <div className="toplinecss"> UBT</div>
      <div className="secondWrapper">
         <div className="thirdWrapper">
        
         {children}
         </div>
      </div>
   </div>
</div>
)
}
