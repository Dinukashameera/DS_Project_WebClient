const express = require("express");
const mongoose = require("mongoose");
const users = require("./Routes/api/Users");
const rooms = require("./Routes/api/Rooms");

const app = express();


app.use(express.json());
app.use("/api/users", users);
app.use("/api/room", rooms);
//connecting to the dataBase
//mongodb+srv://ds123:ds123@dswebprojectcluster-jvrhf.mongodb.net/test?retryWrites=true&w=majority
mongoose
  .connect("mongodb://localhost:27017/ds_proj_remote", {
    useNewUrlParser: true,
    useUnifiedTopology: true
  })
  .then(() => console.log("connected to mongo DB"))
  .catch((error) => console.error(error));

const PORT = process.env.PORT || 5000;

app.listen(PORT, () => console.log(`Listening to PORT ${PORT}`));