const express = require("express");
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

//adding customers to the room
router.patch('/addCustomer/:Nic&:RoomNo',async(req,res) => {
  try {
    console.log(req.params.Nic)
    console.log(req.params.RoomNo)
    //checking for the room existence
    let room = await Room.findOne({RoomNo : req.params.RoomNo})
    console.log(room)
    if (!room) return res.status(400).send("No Such Room exist");

    room.User = req.params.Nic
    room.IsAlarmActive = true

    await room.save()
    res.send(200).json(room)
  } catch (error) {
    
  }
})


//adding sensor details to the room
router.patch('/addSensor/:Smoke&:Co2&:RoomNo',async(req,res) => {
  try {
    console.log(req.params.Smoke)
    console.log(req.params.Co2)
    //checking for the room existence
    let room = await Room.findOne({RoomNo : req.params.RoomNo})
    console.log(room)
    if (!room) return res.status(400).send("No Such Room exist");

    room.SmokeLevel = req.params.Smoke
    room.Co2Level = req.params.Co2

    await room.save()
    res.send(200).json(room)
  } catch (error) {
    
  }
})


module.exports = router;
