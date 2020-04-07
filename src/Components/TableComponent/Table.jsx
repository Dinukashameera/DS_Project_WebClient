import React from "react";
import TableRow from "./TableRow";
export default function Table({ rooms }) {
  return (
    <div className="" style ={style.table}>
      <h2 className="text-center">ROOM DETAILS</h2>
      <div className="card-body">
        <table id="example1" className="table table-bordered table-striped">
          <thead>
            <tr>
              <th>ROOM NO</th>
              <th>FLOOR NO</th>
              <th>FIRE ALARM STATUS</th>
              <th>SMOKE LEVEL</th>
              <th>CO2 LEVEL</th>
            </tr>
          </thead>
          <tbody>
            {rooms.map(
              ({ roomNo, floorNo, alarmStatus, smokeLevel, co2Level }) => (
                <TableRow
                  room={roomNo}
                  floor={floorNo}
                  status={alarmStatus}
                  smoke={smokeLevel}
                  co2={co2Level}
                />
              )
            )}
          </tbody>
          <tfoot>
            <tr>
              <th>ROOM NO</th>
              <th>FLOOR NO</th>
              <th>FIRE ALARM STATUS</th>
              <th>SMOKE LEVEL</th>
              <th>CO2 LEVEL</th>
            </tr>
          </tfoot>
        </table>
        <div className="text-right mt-3">
          <span className="mr-3 font-weight-bold">LEGEND</span>
          <span className="badge badge-pill badge-success mr-3">GOOD</span>
          <span
            className="badge badge-pill mr-3"
            style={{ backgroundColor: "#FFCCCB" }}
          >
            MILD
          </span>
          <span className="badge badge-pill badge-danger mr-3">BAD</span>
        </div>
      </div>
    </div>
  );
}

const style = {
  table: {
    marginTop: "3%",
    borderTop: '5px solid darkgray',
    borderBottom: '5px solid darkgray',
    borderRadius:'5px',
    padding:'45px'
  }

};