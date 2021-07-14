import React,{useContext} from "react";
import { UserContext } from '../Shared/hooks/UserContext';
import EmptyPage from "../Shared/Components/EmptyPage"

export default function UserReputation(){
    const {user,setUser} = useContext(UserContext);

    return(
        <div className="Reputation">
        <EmptyPage path="/reputation">
        <div className="ContentBox">
               <div className="ContentBoxHeader">
                  <h3>Reputation for Sead </h3>
               </div>
               
            </div>
            <div className="reputationstats">
            <h1>Total Reputation</h1>

            </div>
            <div className="reputationComments">
                <ul>
                    <li className="replist">
                        <li>seadi
                        </li><span className="posrep">Positive(-1):   </span> kew
                        </li>
                     <li className="replist">
                        <li>seadi
                        </li><span className="negrep">Positive(-1):   </span> kew
                        </li>
                </ul>
            </div>
        </EmptyPage>
        </div>


    );

}