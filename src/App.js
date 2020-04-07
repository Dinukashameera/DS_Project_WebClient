import React, { Component } from "react";
import axios from 'axios'
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import NavBar from "./Components/NavComponent/navcomponent";
import Cardlist from "./Components/CardComponent/CardListComponent";

import Table from "./Components/TableComponent/Table";
import Chart from "./Components/ChartComponent/Chart";
import Footer from "./Components/Footer/Footer";
import "./App.css";

class App extends Component {
  state = {
    rooms: [
      {
        roomNo: "1",
        floorNo: "1",
        alarmStatus: false,
        smokeLevel: "5",
        co2Level: "3",
      },
      {
        roomNo: "2",
        floorNo: "1",
        alarmStatus: true,
        smokeLevel: "8",
        co2Level: "3",
      },
      {
        roomNo: "3",
        floorNo: "1",
        alarmStatus: false,
        smokeLevel: "9",
        co2Level: "6",
      },
      {
        roomNo: "4",
        floorNo: "1",
        alarmStatus: true,
        smokeLevel: "1",
        co2Level: "5",
      },
    ]
  };
  
  //test code

  // fetchUsers = async function name() {
  //   try{
  //     const response = await axios.get('https://jsonplaceholder.typicode.com/users');
  //     console.log(response.data)
  //   } catch (error) {
  //     console.error(error);
  //   }
  // }

  // componentDidMount(){
  //   this.fetchUsers()
  // }

  render() {
    return (
      <Router>
        <div className="App">
          <NavBar />
          <div className="container">
            <div className="cardList">
              <Route
                exact
                path="/"
                component={() => <Cardlist rooms={this.state.rooms} />}
              />
            </div>
            <div className="tableContainer">
              <Route
                exact
                path="/"
                component={() => <Table rooms={this.state.rooms} />}
              />
            </div>

            <div className="chartcontainer">
              <Chart />
            </div>
          </div>
          <Footer />
        </div>
      </Router>
    );
  }
}

export default App;
