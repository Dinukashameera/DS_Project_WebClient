const mongoose = require("mongoose");

const roomSchema = new mongoose.Schema({
  RoomNo: {
    type: Number,
    unique: true
  },
  FloorNo: {
    type: Number
  },
  User: {
    type: String,
    default : null
    
  },
  IsAlarmActive :{
      type : Boolean,
      default : false 
  },
  SmokeLevel :{
    type : Number,
    default : 0
  },
  Co2Level : {
      type : Number,
      default : 0
  }
});


const Room = mongoose.model("Room", roomSchema);

exports.Room = Room;