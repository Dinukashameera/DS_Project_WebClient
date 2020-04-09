const mongoose = require("mongoose");

const userSchema = new mongoose.Schema({
  Name:{
    type: String,
    minlength: 5,
    maxlength: 20
  },
  Nic:{
      type : String,
      unique : true,
      required : true
  },
  Email:{
    type: String,
    unique: true
  },
  Password:{
    type: String,
    minlength: 5,
    maxlength: 1024
  },
  isAdmin:{
      type : Boolean,
      default : false 
  },
  MobileNumber:{
    type : String,
    required : true
  }
});


const User = mongoose.model("User", userSchema);

exports.User = User;