const mongoose = require("mongoose");

const roomSchema = new mongoose.Schema({
  roomNo: {
    type: Number,
    unique: true
  },
  floorNo: {
    type: Number
    
  },
  user: {
    type: String,
    default : null
    
  },
  isAlarmActive :{
      type : Boolean,
      default : false 
  },
  smokeLevel :{
    type : number
  },
  co2Level : {
      type : Number
  }
});


const Room = mongoose.model("Room", roomSchema);

exports.Room = Room;