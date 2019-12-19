let readIniFile = require("../Utilities/Inifile.js");
let connectKP8 = readIniFile.globalConf("DBConfig kp8_Global");
let connectUser = readIniFile.globalConf("DBConfig User");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[sysAdTestMe]");

module.exports = function(req, res) {
    try
    {
        let conKP8Stat = "Connected";
        let conUserStat = "Connected";
        let response;
        let queryStr = "Select now();";
        connectUser.query(queryStr, function(err, rows, feilds) 
        {
            if(err){conUserStat = "Not Connected";}
            connectKP8.query(queryStr, function(err, rows, feilds) 
            {
                if(err){conKP8Stat = " Not Connected";}

                if(conKP8Stat == "Connected" && conUserStat == "Connected")
                {response = { respcode : 1, message: "All Configurations are connected"};} 
                else
                {response = { respcode : -1, message: "[DBConfig kp8_Global]: " +conKP8Stat+", [DBConfig User]: " + conUserStat};}    
                kplog.info("respcode: " + response.respcode + " message: " + response.message);
                return res.json(response);
            }); 
        }); 
    }
    catch(err)
    {
        response = { respcode : -1, message : "ERROR: " + err };
        kplog.fatal(response);
        return res.json(response);
    }
}