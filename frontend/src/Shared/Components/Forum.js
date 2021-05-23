
 import React from 'react'
 import {Link, Route}  from "react-router-dom";


function Forum({icon,name,linku,desc,threads,posts,lastPost}){
    return(
        
                <tr>
                <td >{icon}</td>
                <td><a href={linku} title={name}>{name}</a>
                <p>{desc}</p>
                </td>
                    <td >{threads}</td>
                    <td >{posts}</td>
                    <td >{lastPost}</td>
                </tr>

    );
}
export default Forum;