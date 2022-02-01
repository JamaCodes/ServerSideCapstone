import React from "react";

const Patient = ({ patient }) => {
  return (
    <tbody>
    <tr className="text-left px-2">
      <td className="text-center px-2">{patient.id}</td>
      <td className="text-left px-2">{patient.fullName}</td>
      <td className="text-left px-2">{patient.dob}</td>
      <td className="text-left px-2">{patient.address}</td>
      <td className="text-left px-2">{patient.city}</td>
      <td className="text-left px-2">{patient.state}</td>
      <td className="text-left px-2">{patient.zipCode}</td>
      <td className="text-left px-2">{patient.phone}</td>
      <td className="text-left px-2">{patient.race.name}</td>
    </tr>
    </tbody>
  );
};
export default Patient;
