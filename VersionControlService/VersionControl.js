var express = require('express');
var app = express();
var bodyParser = require('body-parser');

app.use(bodyParser.json());

// GET Method
var getAreas = require('./Webservices/getAreas');
app.use('/getAreas', getAreas);

var getBranches = require('./Webservices/getBranches');
app.use('/getBranches', getBranches);

var getRegions = require('./Webservices/getRegions');
app.use('/getRegions', getRegions);

var getStationcode = require('./Webservices/getStationcode');
app.use('/getStationcode', getStationcode);

var getVersionForDowngrade = require('./Webservices/getVersionForDowngrade');
app.use('/getVersionForDowngrade', getVersionForDowngrade);

var sysAdTestMe = require('./Webservices/sysAdTestMe');
app.use('/sysAdTestMe', sysAdTestMe);

// POST Method
var allowUpdateForAll = require('./Webservices/allowUpdateForAll');
app.post('/allowUpdateForAll', allowUpdateForAll);

var insertVersion = require('./Webservices/insertVersion');
app.post('/insertVersion', insertVersion);

var resetIsAllowUpdate = require('./Webservices/resetIsAllowUpdate');
app.post('/resetIsAllowUpdate', resetIsAllowUpdate);

var saveBranches = require('./Webservices/saveBranches');
app.post('/saveBranches', saveBranches);

var updateByBranchOrStation = require('./Webservices/updateByBranchOrStation');
app.post('/updateByBranchOrStation', updateByBranchOrStation);

// For PortNo
var readIniFile = require("./Utilities/Inifile.js");
var Port = readIniFile.kp8GlobalPort("WSConfig KPVersionControl");

var server  = app.listen(Port.portNum,function() {
//var server  = app.listen(2018,function() {
var host    = server.address().address
var port    = server.address().port

console.log("Example of the app listening at http:localhost",host,port)
})