import React, { useEffect, useState } from "react";
import Patient from "./Patient";
import { Table } from "reactstrap";
import { getAllPatients } from "../../modules/patientManager";

const PatientList = () => {
  // const history = useHistory();
  const [patients, setPatients] = useState([]);
  const getPatients = () => {
    getAllPatients().then((patients) => setPatients(patients));
  };
  useEffect(() => {
    getPatients();
  }, []);

  return (
    <Table className="patientList" size="sm" striped="true">
    <thead>
    <tr>
      <th scope="row">#</th>
      <th scope="row">Full Name</th>
      <th scope="row">DOB</th>
      <th scope="row">Address</th>
      <th scope="row">City</th>
      <th scope="row">State</th>
      <th scope="row">Zip Code</th>
      <th scope="row">Phone</th>
      <th scope="row">Race</th>
    </tr>
    </thead>
   
        {patients.map((patient) => (
          <Patient patient={patient} key={patient.id} />
        ))}
    
    </Table>
  );
};
export default PatientList;
