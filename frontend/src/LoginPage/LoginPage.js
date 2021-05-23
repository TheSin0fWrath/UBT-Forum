import EmptyPage from "../Shared/Components/EmptyPage";
import Forum from "../Shared/Components/Forum";
import React, { useState } from "react";
import "./Login.css";
import {LoginCrud,RegisterCrud} from "./LoginCrud"

export default function LoginPage() {
  const [loginerror, setloginerror] = useState();
  const [registererror, setreerror] = useState();
  const [login, setlogin] = useState({ username: "", password: "" });
  const [register, setregister] = useState({
    username: "",
    password: "",
    repassword: "",
    email: "",
    drejtimi: "",
    gjenerata: "",
    dateofjoining:""
  });


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
      register.drejtimi == "Slect" ||
      register.gjenerata == "Select"
    ) {
      setloginerror("Please Fill Both Of The Fields");
    } 
    else if (register.password != register.repassword) {
      setreerror("Pleas Make Sure You Type The Same Password In Both Fields");
    } 
    else if (!register.email.toLowerCase().includes("@ubt-uni.net")) {
      setreerror("You Must Use A UBT Email");
    }
    else if (register.drejtimi==""||register.gjenerata==""){
      setreerror("Please Chose Gjenerata and Drejtimi");

    }
    else{
    register.dateofjoining= new Date().toISOString().slice(0,10);  
   const response= await RegisterCrud(register);
   setreerror(response.message)
   console.log(response.message)
    }
  }

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
                type="text"
                required
                onChange={(x) =>
                  setlogin({ ...login, username: x.target.value })
                }
              />
              <label htmlFor="Password">Password</label>
              <input
                type="password"
                onChange={(x) =>
                  setlogin({ ...login, password: x.target.value })
                }
                required
              />
              <p>{loginerror}</p>
              <input type="submit" value="Submit" />
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
                type="text"
                onChange={(x) =>
                  setregister({ ...register, username: x.target.value })
                }
              />
              <label htmlFor="Password">Password</label>
              <input
                type="Password"
                minLength={8}
                required
                onChange={(x) =>
                  setregister({ ...register, password: x.target.value })
                }
              />
              <label htmlFor="Password">Repeat Password</label>
              <input
                type="Password"
                minLength={8}
                required
                onChange={(x) =>
                  setregister({ ...register, repassword: x.target.value })
                }
              />
              <label htmlFor="Email">Email</label>
              <input
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
                <option value="Arkitektur">Arkitektur</option>
                <option value="CSE">CSE</option>
                <option value="Juridik">Juridik</option>
              </select>
              <select
                name="Gjenerata"
                id=""
              
                onChange={(x) =>
                  setregister({ ...register, gjenerata: x.target.value })
                }
              >
                <option value="null" >
                  {" "}
                  Gjenerata
                </option>
                <option value="19/20">19/20</option>
                <option value="18/19">18/19</option>
                <option value="17/18">17/18</option>
              </select>
              <p>{registererror}</p>
              <input
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
