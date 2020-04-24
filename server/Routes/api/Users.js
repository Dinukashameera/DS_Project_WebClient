const express = require("express");
const router = express.Router();
const { User } = require("../../models/User");
const bcrypt = require('bcryptjs');
const jwt = require('jsonwebtoken');
//getting user
router.get("/", async (req, res) => {
  console.log('Api call from Dot Net Remote')
  try {
    const user = await User.find();
    //res.send(user);
   // console.log(user)
    res.status(200).json(user)
  } catch (e) {
    console.log(e);
  }
});


//registering users
//just to add users to no sql
router.post("/adduser", async (req, res) => {
    console.log(req.body);
    try {
      //destructuring the req body
      const { name, email, password,nic, mobileNumber,isAdmin } = req.body;
      //checking whether the user with same email address exist
      let user = await User.findOne({ email });
      if (user) return res.status(400).send("User already exists");
  
      user = new User({
        name,
        email,
        password,
        nic,
        mobileNumber,
        isAdmin
      });
      const result = await user.save();
     res.status(200).json(result)
    } catch (e) {
      res.send(e);
    }
  });


//admin register
  router.post("/register",(req,res)=>{

    console.log(req.body);
    const adminData = {
      name:req.body.name,
      email:req.body.email,
      mobile:req.body.mobile,
      password:req.body.password
    }

    User.findOne({
      email:req.body.email
    })
    .then(user=>{
      if(!user){
        bcrypt.hash(req.body.password,10,(err,hash)=>{
          adminData.password = hash
          User.create(adminData)
          .then(user=>{
            res.sendStatus(200);
          })
          .catch(err=>{
            res.status(400).json({"error":err})
          })
        })
      }else{
        res.sendStatus(403);
      }
    })
    .catch(err=>{
      res.send(404).json({"error":err})
    })
  })


//admin login
router.post('/login',(req,res)=>{

    console.log(req.body)
    User.findOne({
      email:req.body.email
    })
    .then(user=>{
      if(user){
        if(bcrypt.compareSync(req.body.password,user.password)){
          const payload={
            _id:user._id,
            name:user.name,
            email:user.email,
            mobile:user.mobile,
          }

          jwt.sign(
            payload,
            "secretkey",  
            { expiresIn: "2000s" },
            (err, token) => {
              res.status(200).json({ 
                'token' : token
              });
            }
          )
        }else{
          res.status(400).json({"msg":"Invalid Password"});
        }
      }else{
        res.status(404).json({"msg":"User not Found"});
      }
    })
  })






module.exports = router;