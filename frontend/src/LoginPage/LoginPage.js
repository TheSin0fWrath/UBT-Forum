import EmptyPage from "../Shared/Components/EmptyPage";
import Forum from "../Shared/Components/Forum";
import React, { useEffect, useMemo, useState } from "react";
import "./Login.css";
import {LoginCrud,RegisterCrud,getDrejtimet} from "./LoginCrud"

export default function LoginPage() {
  const [loginerror, setloginerror] = useState();
  const [registererror, setreerror] = useState();
  const [login, setlogin] = useState({ username: "", password: "" });
  const [drejtimet,setDrejtimet] = useState();
  const [loaded,setLoaded]= useState(false);
  const [register, setregister] = useState({
    username: "",
    password: "",
    repassword: "",
    email: "",
    drejtimi: "",
    dateofjoining:""
  });

  useEffect(async ()=>{
    var drejtimet= await getDrejtimet();
    setLoaded(true);
    setDrejtimet(drejtimet);
    console.log(drejtimet);
  },[])

  async function  trylogin(e) {
    e.preventDefault();
    
    if (login.username == "" || login.password == "") {
      setloginerror("Please Fill Both Of The Fields");
    }
    const response =await LoginCrud(login);
    setloginerror(response.message)
    if(response.success==true){
   
    }
    
  }
  
  async function tryregister(e) {
    e.preventDefault();
    if (
      register.username == "" ||
      register.password == "" ||
      register.email == "" ||
      register.drejtimi == "Slect" 
      
    ) {
      setloginerror("Please Fill Both Of The Fields");
    } 
    else if (register.password != register.repassword) {
      setreerror("Pleas Make Sure You Type The Same Password In Both Fields");
    } 
    else if (!register.email.toLowerCase().includes("@ubt-uni.net")) {
      setreerror("You Must Use A UBT Email");
    }
    else if (register.drejtimi==""){
      setreerror("Please Chose Drejtimin");

    }
    else{
    register.dateofjoining= new Date().toISOString().slice(0,10);  
   const response= await RegisterCrud(register);
   setreerror(response.message)
   console.log(response.message)
    }
  }
  const renderdrejtimet = useMemo(()=>{
    if(loaded){
      return(
   drejtimet.data.drejtimet.map(x=>{
     return(
    <option value={x.id}>{x.drejtimi}</option>
    ) })
   )
  }
  },[drejtimet])
  return (
    <div class="Loginpage">
      <EmptyPage  path="/Login">
        <div className="LoginWrap">
          <div className="Login">
            <div className="ContentBox">
              <div className="ContentBoxHeader">
                <h3>LogIn </h3>
              </div>
            </div>
            <form onSubmit={trylogin}>
              <label htmlFor="Username">Username</label>
              <input
              className="Firs-Input-Text"
                type="text"
                required
                onChange={(x) =>
                  setlogin({ ...login, username: x.target.value })
                }
              />
              <label htmlFor="Password">Password</label>
              <input
              className="Firs-Input-Text"
                type="password"
                onChange={(x) =>
                  setlogin({ ...login, password: x.target.value })
                }
                required
              />
              <p>{loginerror}</p>
              <input type="submit"   className="UbtForumButton" value="Submit" />
            </form>
          </div>
          <div className="Register">
            <div className="ContentBox">
              <div className="ContentBoxHeader">
                <h3>Register </h3>
              </div>
            </div>
            <form onSubmit={tryregister}>
              <label htmlFor="Username">Username</label>
              <input
              className="Firs-Input-Text"
                type="text"
                onChange={(x) =>
                  setregister({ ...register, username: x.target.value })
                }
              />
              <label htmlFor="Password">Password</label>
              <input
              className="Firs-Input-Text"
                type="Password"
                minLength={8}
                required
                onChange={(x) =>
                  setregister({ ...register, password: x.target.value })
                }
              />
              <label htmlFor="Password">Repeat Password</label>
              <input
              className="Firs-Input-Text"
                type="Password"
                minLength={8}
                required
                onChange={(x) =>
                  setregister({ ...register, repassword: x.target.value })
                }
              />
              <label htmlFor="Email">Email</label>
              <input
              className="Firs-Input-Text"
                type="Email"
                required
                onChange={(x) =>
                  setregister({ ...register, email: x.target.value })
                }
              />
              <select
                name="drejtimi"
                id=""
                required
               
                onChange={(x) =>
                  setregister({ ...register, drejtimi: x.target.value })
                }
              >
                 <option value="null">Drejtimi</option>
               
             
               {renderdrejtimet}
              </select>
            
              <p>{registererror}</p>
              <input
              className="UbtForumButton"
                type="submit"
                onSubmit={e=>e.preventDefault()}
                value="Register"
              />
            </form>
          </div>
        </div>
      </EmptyPage>
    </div>
  );
}
