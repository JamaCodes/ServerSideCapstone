import React, { useEffect, useState } from "react";
import Patient from "./Patient";
import { Table, Button } from "reactstrap";
import { getAllPatients } from "../../modules/patientManager";
import { useHistory } from "react-router";

const PatientList = () => {
    // const history = useHistory();
    const [patients, setPatients] = useState([]);
    const getPatients = () => {
        getAllPatients().then((patients) => setPatients(patients));
    };
    useEffect(() => {
        getPatients();
    }, []);

    return(
            <div className="row justify-content-center">
                {patients.map((patient) => (
                    <Patient patient={patient} key={patient.id} />
                ))}
            </div>
    )
};
export default PatientList