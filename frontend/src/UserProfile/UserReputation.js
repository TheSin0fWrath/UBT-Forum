import React, { useContext } from "react";
import "./Reputation.css";
import { UserContext } from '../Shared/hooks/UserContext';
import EmptyPage from "../Shared/Components/EmptyPage";
import RepPage from "../Shared/Components/RepPage";
import { CheckLogin } from "../Shared/hooks/CheckLogin";
import getUser from "./UerInfoCrud";
const userid = window.location.pathname.split("/").pop();
const {REACT_APP_BASIC}= process.env;
const fetchURL = REACT_APP_BASIC+'user/getuser/' + userid;
const getRepListApi = () => fetch( REACT_APP_BASIC+"reputation/" + userid).then(response => response.json());

export default function UserReputation() {
    const [isBusy, setBusy] = React.useState(true);
    const [repId, setRepId] = React.useState([]);
    const [getRepId, setGetRepId] = React.useState([]);
    const [getRepDetails, setGetRepDetails] = React.useState({ repRate: "2" });
    const [getRepList, setGetRepList] = React.useState([]);
    const { user, setUser } = useContext(UserContext);
    const [currentUser, setCurrentUser] = React.useState([]);
    const [hasgiverep,sethasgivenrep]= React.useState(false);


    React.useEffect(async () => {
        async function fetchMyUser() {
            let response = await fetch(fetchURL);
            response = await response.json();
            setRepId(response.data);
            setBusy(false);
        }
        fetchMyUser();

        getRepListApi().then(res => setGetRepList(res));
    }, []);
    React.useEffect(()=>{
        if(!isBusy){
            var hasrepted=false;
            for(var i=0;i<getRepList.length;i++){
                if( getRepList[i].fromuser=user.nameid){
                    hasrepted=true;
                }
                           }
            if(user.nameid==userid){
                hasrepted=true;

            }
            if(hasrepted){
                sethasgivenrep(true)
            }
        }

    },[isBusy])
    function addRep() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', "Authorization": `Bearer ${window.localStorage.getItem("token")}` },
            body: JSON.stringify({
                Message: getRepDetails.repMessage,
                Reputation: getRepDetails.repRate,
                fromUserId: user.nameid,
                ToUserId: userid
            })
        };
        window.location.reload()

        fetch( REACT_APP_BASIC+"api/reputation", requestOptions).then(response => response.json()).then();
    }
    function deleteRep(e) {
        let id = e.target.id;
        const requestOptions = {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json', "Authorization": `Bearer ${window.localStorage.getItem("token")}` },
            body: JSON.stringify({})
        };
        fetch( REACT_APP_BASIC+'api/reputation/' + id, requestOptions);
    }
    function editRep(e) {
        let id = e.target.id;
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', "Authorization": `Bearer ${window.localStorage.getItem("token")}` },
            body: JSON.stringify({
                Message: getRepDetails.repMessage,
                Reputation: getRepDetails.repRate,
                fromUserId: user.nameid,
                ToUserId: userid
            })
        };
        fetch( REACT_APP_BASIC+'api/reputation/' + id, requestOptions);
        // console.log(e.target.id);
    }
    
    const renderep = getRepList.map(rep => {
    

        if (rep.points > 0) {
            
            if (user.nameid == rep.fromuser) {

                return (
                    <li key={rep.id} className="replist">
                        <li>{rep.username}
                        </li><span className="posrep">Positive({rep.points}):   </span> {rep.message}
                        <span id={rep.id} onClick={deleteRep}> Delete -</span>
                        <span id={rep.id} onClick={editRep}> Edit </span>
                    </li>)
            }
            else {
                return (
                    <li key={rep.id} className="replist">
                        <li>{rep.username}
                        </li><span className="posrep">Positive({rep.points}):   </span> {rep.message}
                    </li>)
            }
        }

        else {
            if (user.nameid == rep.fromuser) {
                return (
                    <li key={rep.id} className="replist">
                        <li>{rep.username}
                        </li><span className="negrep">Positive({rep.points}):   </span> {rep.message}
                        <span id={rep.id} onClick={deleteRep}>  Delete -</span><br />
                        <span id={rep.id} onClick={editRep}> Edit </span>
                    </li>

                )

            }
            else {
                return (
                    <li key={rep.id} className="replist">
                        <li>{rep.username}
                        </li><span className="negrep">Positive({rep.points}):   </span> {rep.message}
                    </li>
                )
            }
        }

    })



    return (
        <div className="Reputation">
            <RepPage path="/id">

                <div className="ContentBox">
                    <div className="ContentBoxHeader">
                        <h3>Reputation for {isBusy ? ('null') : (<p>{repId.username}</p>)} </h3>
                    </div>
                    {(hasgiverep)?<></>:
                    <div className="submitRep">
                        <select onChange={event => setGetRepDetails({
                            ...getRepDetails,
                            repRate: event.target.value
                        })} name="submitUserRep" id="userRepSelect">
                            <option value="2">Positive</option>
                            <option value="0">Neutral</option>
                            <option value="-2">Negative</option>
                        </select>
                        <input onChange={event => setGetRepDetails({
                            ...getRepDetails,
                            repMessage: event.target.value
                        })} type="text" placeholder="Write a comment" />
                        <button onClick={addRep}>Rate</button>
                    </div>
               } </div>
                <div className="reputationstats">
                    <h1>Total Reputation</h1>

                </div>
                <div className="reputationComments">
                    <ul>
                        {/* {getRepList.map(repList => ( 
                        
                    <li key={repList.id}>
                        {repList.fromUser} <span>
                            {(repList.reputation > 0)? 'Positive(': ((repList.reputation == 0)? 'Neutral(': 'Negative(')}
                            {repList.reputation}) </span> 
                        <p>{repList.message}</p>
                        
                    </li> ))} */}
                        {
                            renderep
                        }



                    </ul>
                </div>
            </RepPage>
        </div>


    );

}