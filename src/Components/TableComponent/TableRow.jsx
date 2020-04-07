import React from "react";

export default function TableRow({ room, floor, status, smoke, co2 }) {
  let co2Level;
  let smokeLevel;
  let alarmStatus;

  //if condition statement for getting the status of the smoke level
  if (smoke >= 8) {
    smokeLevel = "#DC143C";
  } else if (smoke >= 5 && smoke < 8) {
    smokeLevel = "#FFCCCB";
  } else {
    smokeLevel = "lightgreen";
  }

  //if condition statement ot get the status of the CO2 level
  if (co2 >= 8) {
    co2Level = "#DC143C";
  } else if (co2 >= 5 && co2 < 8) {
    co2Level = "#FFCCCB";
  } else {
    co2Level = "lightgreen";
  }

  //if condtion to get the status of the alarm
  if (status == 1) alarmStatus = "Active ";
  else alarmStatus = "Inactive";

  return (
    <tr>
      <td className = "font-weight-bold">{room}</td>
      <td className = "font-weight-bold">{floor}</td>
      <td className = "font-weight-bold" style={{ color: alarmStatus ? "green" : "red" }} >{alarmStatus}</td>
      <td className = "font-weight-bold" style={{ backgroundColor: `${smokeLevel}` }}>{smoke}</td>
      <td className = "font-weight-bold" style={{ backgroundColor: `${co2Level}` }}>{co2}</td>
    </tr>
  );
}
