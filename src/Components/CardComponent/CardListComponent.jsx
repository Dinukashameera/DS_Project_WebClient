import React from "react";
import Card from "./Card";
export default function CardListComponent({rooms}) {
   const array = [];
  let average = 0;
  rooms.map(room => {
    array.push(room.smokeLevel)
  })

  for (let index = 0; index < rooms.length; index++) {
    average = parseFloat(average) + parseFloat(rooms[index].co2Level)
    
  }
 
  return (
    <div class="row">
      <Card
        count={rooms.length}
        color={"bg-info"}
        name={"Total Rooms"}
        icon={"fas fa-arrow-circle-right"}
      />
      <Card
        count={Math.max(...array)}
        color={"bg-success"}
        name={"Highest Recorded Smoke Level"}
        icon={"fas fa-arrow-circle-right"}
      />
      <Card
        count={(average / rooms.length).toFixed(3)}
        color={"bg-warning"}
        name={"Average"}
        icon={"ion ion-person-add"}
      />
      <Card
        count={Math.min(...array)}
        color={"bg-danger"}
        name={"Lowest Recorded Smoke Level"}
        icon={"ion ion-pie-graph"}
      />
    </div>
  );
}
