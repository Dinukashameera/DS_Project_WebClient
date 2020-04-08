const express = require("express");
const mongoose = require("mongoose");

const router = express.Router();
const { Room } = require("../../models/Rooms");

//getting Rooms
router.get("/", async (req, res) => {
  try {
    const room = await Room.find();
    res.send(room);
    console.log(room);
  } catch (e) {
    console.log(e);
  }
});

//addd new Rooms
//just to add users to no sql
router.post("/", async (req, res) => {
  console.log(req.body);
  try {
    //destructuring the req body
    const {
      roomNo,
      floorNo,
      user,
      isAlarmActive,
      smokeLevel,
      co2Level,
    } = req.body;
    //checking whether the user with same email address exist
    let room = await Room.findOne({ roomNo });
    if (room) return res.status(400).send("Room already exists");

    room = new Room({
      roomNo,
      floorNo,
      user,
      isAlarmActive,
      smokeLevel,
      co2Level,
    });
    const result = await room.save();
    res.status(200).json(result);
  } catch (e) {
    res.send(e);
  }
});

module.exports = router;
