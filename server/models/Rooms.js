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
    nic: {
      type: String,
      default: null,
    },

    email: {
      type: String,
      default: null,
    },
    mobile: {
      type: String,
      default: null,
    },
    name:{
      type:String,
      default:null
    },
    password:{
      type:String,
      default:null
    }
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
  isCO2Active:{
    type:Boolean,
    default:false
  },
  isSmokeActive:{
    type:Boolean,
    default:false
  },
  isSmokeSMSSent:{
    type:Boolean,
    default:false
  },
  isCO2SMSSent:{
    type:Boolean,
    default:false
  },
  isMailSent:{
    type:Boolean,
    default:false
  }

});

const Room = mongoose.model("Room", roomSchema);

exports.Room = Room;
