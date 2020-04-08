const express = require("express");
const mongoose = require("mongoose");

const router = express.Router();
const { User } = require("../../models/User");

//getting user
router.get("/", async (req, res) => {
  try {
    const user = await User.find();
    res.send(user);
    //res.status(200).json(user)
  } catch (e) {
    console.log(e);
  }
});


//registering users
//just to add users to no sql
router.post("/", async (req, res) => {
    console.log(req.body);
    try {
      //destructuring the req body
      const { name, email, password,NIC } = req.body;
      //checking whether the user with same email address exist
      let user = await User.findOne({ email });
      if (user) return res.status(400).send("User already exists");
  
      user = new User({
        name,
        email,
        password,
        NIC
      });
      const result = await user.save();
     res.status(200).json(result)
    } catch (e) {
      res.send(e);
    }
  });


module.exports = router;