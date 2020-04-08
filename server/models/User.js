const mongoose = require("mongoose");

const userSchema = new mongoose.Schema({
  name: {
    type: String,
    minlength: 5,
    maxlength: 20
  },
  NIC : {
      type : String,
      unique : true,
      required : true
  },
  email: {
    type: String,
    unique: true
  },
  password: {
    type: String,
    minlength: 5,
    maxlength: 1024
  },
  isAdmin :{
      type : Boolean,
      default : false 
  },
  mobileNumber : {
    type : Number,
    required : true
  }
});


const User = mongoose.model("User", userSchema);

exports.User = User;