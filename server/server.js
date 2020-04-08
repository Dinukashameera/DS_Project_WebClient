const express = require("express");
const mongoose = require("mongoose");
const app = express();


app.use(express.json());

//connecting to the dataBase
mongoose
  .connect("mongodb+srv://ds123:ds123@dswebprojectcluster-jvrhf.mongodb.net/test?retryWrites=true&w=majority", {
    useNewUrlParser: true,
    useUnifiedTopology: true
  })
  .then(() => console.log("connected to mongo DB"))
  .catch(() => console.error(error));

const PORT = process.env.PORT || 5000;

app.listen(PORT, () => console.log(`Listening to PORT ${PORT}`));