const express = require("express");
const router = express.Router();
const { Room } = require("../../models/Rooms");

//getting Rooms
router.get("/", async (req, res) => {
  try {
    const room = await Room.find();
    res.send(room);
   // console.log(room);
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

//adding customers to the room
router.put('/addCustomer/:roomNo',async(req,res) => {
  try {
    //checking for the room existence
    console.log(req);
    let room = await Room.findOne({roomNo : req.params.roomNo})
    //console.log(room)
    if (!room) return res.status(400).send("No Such Room exist");

    room.user = req.body.nic
    room.isAlarmActive = true

    await room.save()
    res.send(200).json(room)
  } catch (error) {
    
  }
})


//adding sensor details to the room
router.put('/addSensor/:roomNo',async(req,res) => {
  try {

    //checking for the room existence
    let room = await Room.findOne({roomNo : req.params.roomNo})
    console.log(room)
    if (!room) return res.status(400).send("No Such Room exist");

    room.smokeLevel = req.body.smokeLevel
    room.co2Level = req.body.co2Level

    await room.save()
    res.send(200).json(room)
  } catch (error) {
    
  }
})


module.exports = router;
