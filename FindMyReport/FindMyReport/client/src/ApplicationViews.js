import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./components/Login";
import PatientList from "./components/Patient/PatientList";



export default function ApplicationViews({ isLoggedIn }) {
    return (
        <main>
        <Switch> 
        <Route path="/" exact>
                    {isLoggedIn ? <PatientList /> : <Redirect to="/login" />}
                </Route> 
                <Route path="/login" exact>
                  <Login />
                </Route> 
        </Switch>
        </main>
    )
}