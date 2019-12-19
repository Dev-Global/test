let readIniFile = require("../Utilities/Inifile.js");
let connect = readIniFile.globalConf("DBConfig kp8_Global");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[updateByBranchOrStation]");

module.exports = function(req, res) {
    try
    {
        let param = {};
        let uname = "boswebserviceusr";
        let pword = "boyursa805";
        let recordQuery = "";
        let catType = "";
        let response;
        let chkParam;

        param.username = req.body.username;
        param.password = req.body.password;
        param.zonecode = req.body.zonecode;
        param.branchcode = req.body.branchcode;
        param.stationcode = req.body.stationcode;
        param.releasetype = req.body.releasetype; // 5-By Branch, 6-By Station
        param.categorytype = req.body.categorytype; // 1-Upgrade, 0-Downgrade

        kplog.info("Parameters: " + JSON.stringify(req.body));
        chkParam = Object.keys(req.body);
        if(!((chkParam.length == 7) && (chkParam.includes("username")) && (chkParam.includes("password")) && (chkParam.includes("zonecode"))
        && (chkParam.includes("branchcode")) && (chkParam.includes("stationcode"))
        && (chkParam.includes("releasetype")) && (chkParam.includes("categorytype")) && (param.username == uname && param.password == pword)
        && (param.releasetype == 5 || param.releasetype == 6) && (param.categorytype == 0 || param.categorytype == 1)))
        {
            response = { respcode : -1, message : "Invalid Parameters: " + JSON.stringify(req.body)};
            kplog.error(response);
            return res.json(response);
        }

        if(param.categorytype == "1"){
            catType = "isallowupdate = 1, isallowdowngrade = 0";
        }
        else if (param.categorytype == "0"){
            catType = "isallowupdate = 0, isallowdowngrade = 1";
        }

            if(param.releasetype == 5){
                connect.query("update kp8globalcompliance.kp8mlbranchesstations Set sysmodified = now(), releasetype = "+ param.releasetype +", "+ catType +" WHERE zonecode = "+ param.zonecode +" and branchcode = "+ param.branchcode +";", function(err, result){
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
                        response = { respcode    : 1, message     : "Success", recordQuery : result.affectedRows + " rows Updated" }                 
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
            else if(param.releasetype == 6){
                connect.query("update kp8globalcompliance.kp8mlbranchesstations Set sysmodified = now(), releasetype = "+ param.releasetype +", "+ catType +" WHERE zonecode = '"+ param.zonecode +"' and branchcode = '"+ param.branchcode +"' and stationcode = '"+ param.stationcode +"';", function(err, result){
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
                            response = { respcode    : 1, message     : "Success", recordQuery : result.affectedRows + " rows Updated" };                  
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
    }
    catch(err)
    {
        response = { respcode : -1, message : "ERROR: " + err };
        kplog.fatal(response);
        return res.json(response);
    }
}