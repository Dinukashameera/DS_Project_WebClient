const mongoose = require("mongoose");

const roomSchema = new mongoose.Schema({
  roomNo: {
    type: Number,
    unique: true,
  },
  floorNo: {
    type: Number,
  },
  user: {
    userNic: {
      type: String,
      default: null,
    },

    userEmail: {
      type: String,
      default: null,
    },
    userMobile: {
      type: String,
      default: null,
    },
  },
  isAlarmActive: {
    type: Boolean,
    default: false,
  },
  smokeLevel: {
    type: Number,
    default: 0,
  },
  co2Level: {
    type: Number,
    default: 0,
  },
});

const Room = mongoose.model("Room", roomSchema);

exports.Room = Room;
