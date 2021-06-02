
 import React from 'react'
 import {Link, Route}  from "react-router-dom";


function Forum({icon,name,linku,desc,threads,posts,lastPost}){
    function direct(){
        window.location.href="/announcments"
    }
    return(
        
            <tr onClick={direct}>
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