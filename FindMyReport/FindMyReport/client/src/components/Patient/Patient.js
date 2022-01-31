import React from "react";
import { Card, CardBody, Button } from "reactstrap";
import { Link } from "react-router-dom";
import { useHistory } from "react-router-dom";


// let userId = parseInt(localStorage.getItem("LoggedInUserId"));

const Patient = ({ patient }) => {
    // const history = useHistory();

    // const handleDelete = () => {
    //     history.push(`/deletepost/${patient.id}`);
    // };

    // const handleEdit = () => {
    //     history.push(`/editPost/${patient.id}`);
    // };

    return (
        <Card className="patient">
            <Link
                to={`/patient/${patient.id}`}
                style={{ textDecoration: "none", color: "black" }}
            />
                <p className="text-left px-2">
                    FullName: {patient.fullName}
                </p>
             
        </Card>
    );
};

export default Patient;
