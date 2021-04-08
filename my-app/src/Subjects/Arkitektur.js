import React from 'react';
import "../Subjects/Subject.css"
import Forum from "../Components/Forum"

export default function Arkitektur(){
    return(
        <div className="Arkitektur">      
          <div className="Subject" >
         <div className="ContentBox">
                <div className="ContentBoxHeader"> <h3>Lendet </h3></div>
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
           <Forum icon="i" name="Viti I" desc="Look here for announcements regarding Ubt."threads="22" posts="22" lastPost="This post"/>
           <Forum icon="i" name="Viti II" desc="Look here for announcements regarding Ubt."threads="22" posts="22" lastPost="This post"/>
           <Forum icon="i" name="Viti III" desc="Look here for announcements regarding Ubt."threads="22" posts="22" lastPost="This post"/>

        
                </tbody>    
                 </table>
                </div>
                </div>
           
        </div>

        <div className="Subject" >
         <div className="ContentBox">
                <div className="ContentBoxHeader"> <h3>Arkitektur </h3></div>
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
           <Forum icon="i" name="Arkitektur" desc="Look here for announcements regarding Ubt."threads="22" posts="22" lastPost="This post"/>
           <Forum icon="i" name="Viti II" desc="Look here for announcements regarding Ubt."threads="22" posts="22" lastPost="This post"/>
           <Forum icon="i" name="Viti III" desc="Look here for announcements regarding Ubt."threads="22" posts="22" lastPost="This post"/>

        
                </tbody>    
                 </table>
                </div>
                </div>
           
        </div>


        </div>


    )
}

