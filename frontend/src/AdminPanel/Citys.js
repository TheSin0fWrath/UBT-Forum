import React from "react";
import "./Citys.css";
const {REACT_APP_LOCAL}= process.env;


const fetchURL = REACT_APP_LOCAL+'qytetet/';
const getItems = () => fetch(fetchURL).then(res => res.json());

function CitysList () {
   const [citys, setCitys] = React.useState([]);
   const [cityInput, setCityInput] = React.useState([]);
   const [cityEdit, setCityEdit] = React.useState([]);
   


    React.useEffect(() => {
        getItems().then(data => setCitys(data));
    }, []);
    function addcity() {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', "Authorization": `Bearer ${window.localStorage.getItem("token")}`},
            body: JSON.stringify({ QytetiName: cityInput })
        };
        fetch(fetchURL, requestOptions).then(response => response.json());
        
    }
    function editcity(e) {
        let id = e.target.id;
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', "Authorization": `Bearer ${window.localStorage.getItem("token")}`},
            body: JSON.stringify({ QytetiName: cityEdit })
        };
        fetch(fetchURL+id, requestOptions);
        // console.log(e.target.id);
    }
    function deleteCity(e) {
        let id = e.target.id;
        const requestOptions = {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json', "Authorization": `Bearer ${window.localStorage.getItem("token")}`},
            body: JSON.stringify({})
        };
        fetch(fetchURL+id, requestOptions);
    }
    return(
        <div className="city">
            <div className="current">
                <div className="ContentBoxHeader">
                    <h3>Current Citys</h3>
                    <ul>
                    {citys.map(city => ( <li key={city.qytetiId}>{city.qytetiName} <span id={city.qytetiId} onClick={editcity}>Edit</span><input onChange={event => setCityEdit(event.target.value)} placeholder="Change city name"></input><span id={city.qytetiId} onClick={deleteCity}>Delete</span></li>))}
                    </ul>
                </div>
            </div>
            <div className="city">
                <div className="ContentBoxHeader">
                    <h3>Add Citys</h3>
                    <input onChange={event => setCityInput(event.target.value)} id="cityNameInput" type="text" placeholder="Write a city name"></input>
                    <button onClick={addcity}>Add new City</button>
                </div>
            </div>
        </div>
    );
}

export default CitysList;

