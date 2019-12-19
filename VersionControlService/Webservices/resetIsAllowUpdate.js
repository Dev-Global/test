let readIniFile = require("../Utilities/Inifile.js");
let connect = readIniFile.globalConf("DBConfig kp8_Global");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[resetIsAllowUpdate]");


module.exports = function(req, res) {

    try
    {
        let param = {};
        let uname = "boswebserviceusr";
        let pword = "boyursa805";
        let response;
        let recordQuery = "";
        let chkParam;
        
        param.username = req.body.username;
        param.password = req.body.password;

        kplog.info("Parameters: " + JSON.stringify(req.body));
        chkParam = Object.keys(req.body);
        if(!((chkParam.length == 2) && (chkParam.includes("username")) && (chkParam.includes("password")) && 
        (param.username == uname && param.password == pword)))
        {
            response = { respcode : -1, message : "Invalid Parameters: " + JSON.stringify(req.body)};
            kplog.error(response);
            return res.json(response);
        }
            connect.query("update kp8globalcompliance.kp8mlbranchesstations Set sysmodified = now(), releasetype = 0, isallowupdate = 0, isallowdowngrade = 0 where branchcode NOT REGEXP '[A-Z]';", function(err, result){
                if(err)
                {
                    //connect.end();
                    response = { respcode : -1, message : "ERROR: " + err };
                    kplog.error(response);
                    return res.json(response);
                }
                else
                {
                    if(result.affectedRows > 0)
                    {
                        response = { respcode    : 1, message     : "Successfully Updated", recordQuery : result.affectedRows + " rows Updated" }                  
                    }
                    else 
                    {
                        response = { respcode    : 0, message     : "No Data to be Updated" };
                    }
                    //connect.end();
                    kplog.info(response);
                    return res.json(response);
                }
            });

    }
    catch(err)
    {
        response = { respcode : -1, message : "ERROR: " + err };
        kplog.fatal(response);
        return res.json(response);
    }
}