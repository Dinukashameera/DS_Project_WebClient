const express = require("express");
const router = express.Router();
const { Room } = require("../../models/Rooms");

//getting Rooms
router.get("/", async (req, res) => {
  try {
    const room = await Room.find().select('-user');
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
    //checking whether the user with same room address exist

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
    console.log(e);
  }
});

//adding customers to the room
router.put("/addCustomer/:roomNo", async (req, res) => {
  try {
    //checking for the room existence
    //console.log(req);
    let room = await Room.findOne({ roomNo: req.params.roomNo });
    if (!room) return res.status(400).send("No Such Room exist");

    room.user.userNic = req.body.nic;
    room.user.userEmail = req.body.email;
    room.user.userMobile = req.body.mobile;

    room.isAlarmActive = true;

    await room.save();
    res.json(room)
  } catch (error) {
    res.send(error);
  }
});

//adding sensor details to the room
router.put("/addSensor/:roomNo", async (req, res) => {
  try {
    //checking for the room existence
    let room = await Room.findOne({ roomNo: req.params.roomNo });
    console.log(room);
    if (!room) return res.status(400).send("No Such Room exist");

    room.smokeLevel = req.body.smokeLevel;
    room.co2Level = req.body.co2Level;

    await room.save();
    res.json(room);
  } catch (error) {}
});

//get rooms with users
router.get("/withUsers", async (req, res) => {
  try {
    let room = await Room.find({ user: { $ne: null } });
    console.log(room);
    res.send(room);
  } catch (error) {
    res.send(error);
  }
});

//alert needed rooms
router.get("/alert", async (req, res) => {
  try {
    const room = await Room.find().or([
      { co2Level: { $gte: 5, $lt: 10 } },
      { smokeLevel: { $gte: 5, $lt: 10 } },
    ]);

    res.sendStatus(200).json(room)
    // console.log(room);
  } catch (e) {
    console.log(e);
  }
});

router.get("/alertUserInformation", async (req, res) => {});

module.exports = router;
