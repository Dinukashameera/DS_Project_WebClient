const express = require("express");
const router = express.Router();
const { Room } = require("../../models/Rooms");
const nodemailer = require("nodemailer");
const axios = require("axios");

//getting Rooms
//getting Rooms
router.get("/", async (req, res) => {
  try {
    const room = await Room.find();

    // //sending email to the client
    for (let index = 0; index < room.length; index++) {
      if (
        ((room[index].co2Level >= 5 && room[index].co2Level <= 10) ||
          (room[index].smokeLevel >= 5 && room[index].smokeLevel <= 10)) &&
        room[index].isAlarmActive === true &&
        room[index].isMailSent === false
      ) {
        let transporter = nodemailer.createTransport({
          host: "smtp.mailtrap.io",
          port: 2525,
          auth: {
            user: "cd1d2b8d863288",
            pass: "41ff48f6db0ffa",
          },
        });

        // send mail with defined transport object
        let info = await transporter.sendMail({
          from: "dinuka@gmail.com", // sender address
          to: room[index].user.email, // list of receivers
          subject: "Item Approved", // Subject line
          text: "Hello world?", // plain text body
          html: `<h1>Hello ${room[index].user.name}</h1><br/>
                  <span><h3>Room No : ${room[index].roomNo}</h3></span>
                  <span>CO2 Level = ${room[index].co2Level}</span><br/>
                  <span>Smoke Level = ${room[index].smokeLevel}</span> `, // html body
        });

        transporter.sendMail(info, function (err, info) {
          if (err) {
            console.log(err);
          } else {
            console.log(info);
          }
        });
        room[index].isMailSent = true;
        await room[index].save();
      }
    }

    res.send(room);
    //console.log(room);
  } catch (e) {
    console.log(e);
  }
});

router.put("/smsEmailStatus", async (req, res) => {
  try {
    const room = await Room.find();
    console.log("excuted The put method");
    setTimeout(async function () {
      try {
        for (let index = 0; index < room.length; index++) {
          if (
            ((room[index].co2Level >= 5 && room[index].co2Level <= 10) ||
              (room[index].smokeLevel >= 5 && room[index].smokeLevel <= 10)) &&
            room[index].isAlarmActive === true
          ) {
            room[index].isMailSent = true;
            await room[index].save();
          } else {
            room[index].isMailSent = false;
            await room[index].save();
          }
        }
      } catch (error) {}
    }, 2000);

    const result = await room.save();
    res.send(result);
  } catch (error) {}
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
      isCO2Active,
      isSmokeActive,
      isSmokeSMSSent,
      isCO2SMSSent,
      isCO2MailSent,
      isSmokeMailSent,
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
      isCO2Active,
      isSmokeActive,
      isSmokeSMSSent,
      isCO2SMSSent,
      isCO2MailSent,
      isSmokeMailSent,
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

    console.log("DOT NET sending request is : " ,req.body);


    let room = await Room.findOne({ roomNo: req.params.roomNo });
    if (!room) return res.status(400).send("No Such Room exist");

    room.user.nic = req.body.nic;
    room.user.email = req.body.email;
    room.user.mobile = req.body.mobile;
    room.user.name = req.body.name;
    room.user.password = req.body.password;

    room.isAlarmActive = true;

    await room.save();
    res.json(room);
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

    async function updateAlarms(id) {
      const updatedRoom = await Room.findById(id);
      if (!updatedRoom) {
        res.status(404).json({ msg: "Not Found" });
      }

      if (updatedRoom.smokeLevel <= 10 && updatedRoom.smokeLevel >= 5) {
        updatedRoom.isSmokeActive = true;
        updatedRoom.save();
      }

      if (updatedRoom.co2Level <= 10 && updatedRoom.co2Level >= 5) {
        updatedRoom.isCO2Active = true;
        updatedRoom.save();
      }

      res.sendStatus(200);
    }
    updateAlarms(room._id);

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
    const room = await Room.find();

    for (let i = 0; i < room.length; i++) {
      if (room[i].isCO2Active === true) {
        console.log("CO2 Active");

        if (room[i].isCO2SMSSent === false) {
          axios({
            method: "get",
            url: `http://api.liyanagegroup.com/sms_api.php?sms=Room ${room[i].roomNo}-CO2 Alarm is Active&to=94${room[i].user.mobile}&usr=0766061689&pw=4873`,
          });
        }

        async function updateSmsStatus(id) {
          const smsRoom = await Room.findById(id);
          if (!smsRoom) {
            res.status(404).json({ msg: "Not Found" });
          }

          smsRoom.isCO2SMSSent = true;
          smsRoom.save();
        }

        updateSmsStatus(room[i]._id);
      }
      if (room[i].isSmokeActive === true) {
        console.log("Smoke Active");

        if (room[i].isSmokeSMSSent === false) {
          axios({
            method: "get",
            url: `http://api.liyanagegroup.com/sms_api.php?sms=Room ${room[i].roomNo}- Smoke Alarm is Active&to=94${room[i].user.mobile}&usr=0766061689&pw=4873`,
          });
        }

        async function updateSmsStatus(id) {
          const smsRoom = await Room.findById(id);
          if (!smsRoom) {
            res.status(404).json({ msg: "Not Found" });
          }

          smsRoom.isSmokeSMSSent = true;
          smsRoom.save();
        }

        updateSmsStatus(room[i]._id);
      }
    }

    res.send(room);
  } catch (e) {
    console.log(e);
  }
});

router.get("/alertUserInformation", async (req, res) => {});

module.exports = router;
