import React from 'react';
import "../Subjects/Subject.css"
import Forum from "../Components/Forum"

export default function Home(){
    return(
        <div className="Home">      
          <div className="Subject" >
         <div className="ContentBox">
                <div className="ContentBoxHeader"> <h3>UBT</h3></div>
                <div className="ContentBoxBody"> 
                <table>
                 <thead>
                    <tr>
                    <td width="5%"></td>
                     <td width="40%">Forum</td>
                     <td width="10%">Threads</td>
                    <td width="10%">Posts</td>
                    <td width="30%">Posts</td>
                  </tr>
                    </thead>
                <tbody>
           <Forum icon="i" name="Announcments" desc="Look here for announcements regarding UBT."threads="22" posts="22" lastPost="This post"/>
           <Forum icon="i" name="Feedback and Suggestions" desc="Leave feedback or post suggestions to improve the sites quality."threads="22" posts="22" lastPost="This post"/>
           <Forum icon="i" name="Support" desc="If you need help with anything site-related, this is the right place to ask for help."threads="22" posts="22" lastPost="This post"/>

        
                </tbody>    
                 </table>
                </div>
                </div>
           
        </div>
        </div>


    )
}

