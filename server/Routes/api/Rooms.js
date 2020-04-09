const express = require("express");
const mongoose = require("mongoose");

const router = express.Router();
const { Room } = require("../../models/Rooms");

//getting Rooms
router.get("/", async (req, res) => {
  try {
    const room = await Room.find();
    console.log("dinuka")
    res.send(room);
    console.log(room);
  } catch (e) {
    console.log(e);
  }
});

//addd new Rooms
//just to add users to no sql
router.post("/addroom", async (req, res) => {
  console.log(req.body);
  try {
    //destructuring the req body
    const {
      RoomNo,
      FloorNo,
      User,
      IsAlarmActive,
      SmokeLevel,
      Co2Level,
    } = req.body;
    //checking whether the user with same email address exist
    let room = await Room.findOne({ RoomNo });
    if (room) return res.status(400).send("Room already exists");

    room = new Room({
      RoomNo,
      FloorNo,
      User,
      IsAlarmActive,
      SmokeLevel,
      Co2Level,
    });
    const result = await room.save();
    res.status(200).json(result);
  } catch (e) {
    res.send(e);
  }
});

module.exports = router;
