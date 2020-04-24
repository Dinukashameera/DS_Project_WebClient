import React, { Component } from "react";
import axios from "axios";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import NavBar from "./Components/NavComponent/navcomponent";
import Cardlist from "./Components/CardComponent/CardListComponent";

import Table from "./Components/TableComponent/Table";
import Chart from "./Components/ChartComponent/Chart";
import Footer from "./Components/Footer/Footer";
import "./App.css";

class App extends Component {
  state = {
    rooms: [],
  };

  autoFetch = () => {
    axios.get(`/api/room`).then((res) => {
      const rooms = res.data;
      console.log(res.data);
      this.setState({ rooms });
      console.log(this.state.rooms)
    });

    axios.put('/api/room/smsEmailStatus').then((res) => {
      console.log(res)
    }).catch((err) => console.error(err))


    axios.get('api/room/alert')
    .then(res=>{
      console.log(res);
    })
    .catch(err=>{
      console.log(err);
    })

  };

  componentDidMount() {
    // need to make the initial call to autoFetch() to populate
    // data right away
    this.autoFetch();
    console.log(this.state.rooms);
    // Now we need to make it run at a specified interval
    setInterval(this.autoFetch, 30000); // runs every 30 seconds
  }

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
              {/* <Chart /> */}
            </div>
          </div>
          <Footer />
        </div>
      </Router>
    );
  }
}

export default App;
