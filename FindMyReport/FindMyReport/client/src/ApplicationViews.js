import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import Login from "./components/Login";
import PlaceHolder from "./components/placeholder";


export default function ApplicationViews({ isLoggedIn }) {
    return (
        <main>
        <Switch> 
        <Route path="/" exact>
                    {isLoggedIn ? <PlaceHolder /> : <Redirect to="/login" />}
                </Route> 
                <Route path="/login" exact>
                  <Login />
                </Route> 
        </Switch>
        </main>
    )
}