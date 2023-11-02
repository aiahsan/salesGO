Pulling Docker Image

-- docker pull mongo

Checking Docker Process

-- docker ps

Creating and running docker container

-- docker run -d -p 27017:27018 --name mongo-customer mongo

-- docker run <mode -d for depeche and -i for interactive> < -p  binding port from docker image to external env 27017:27017> < -- name of the container> <image which is mongo here>

Executing docker container shel

-- docker exec -it mongo-customer /bin/bash

after that type 

mongosh

to run mongoDB from shell

//MongoDb commands


-- show dbs

-- use CustomerDB

-- db.createCollection('Setup_Customers')
-- db.createCollection('Setup_outlets')
-- show collections


Mongo DB connection settings in appsettings.json

 "DatabaseSettings": {
    "ConnectionString": " mongodb://localhost:27017",
    "DatabaseName": "vendorDB"
  },

