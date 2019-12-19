let readIniFile = require("../Utilities/Inifile.js");
let connect = readIniFile.globalConf("DBConfig kp8_Global");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[insertVersion]");


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
        param.versionno = req.body.versionno;
        param.description = req.body.description;
        param.performby = req.body.performby;
        param.releasetype = req.body.releasetype; //1 to 7
        param.categorytype = req.body.categorytype; // 1-Upgrade, 0-Downgrade

        kplog.info("Parameters: " + JSON.stringify(req.body));
        chkParam = Object.keys(req.body);
        if(!((chkParam.length == 7) && (chkParam.includes("username")) && (chkParam.includes("password")) && (chkParam.includes("versionno"))
        && (chkParam.includes("description")) && (chkParam.includes("performby"))
        && (chkParam.includes("releasetype")) && (chkParam.includes("categorytype")) && (param.username == uname && param.password == pword)
        && (param.releasetype >= 1 && param.releasetype <= 7) && (param.categorytype == 0 || param.categorytype == 1)))
        {
            response = { respcode : -1, message : "Invalid Parameters: " + JSON.stringify(req.body)};
            kplog.error(response);
            return res.json(response);
        }

        if(param.categorytype == "1"){
            catType = "1, 0";
        }
        else if (param.categorytype == "0"){
            catType = "0, 1";
        }

            connect.query("INSERT INTO kp8globalcompliance.kp8versions(versionno, performedby, description,datereleased,releasetype,forUpdate,forDowngrade) VALUES ('"+ param.versionno +"', '"+ param.performby +"', '"+param.description+"', NOW(), '"+ param.releasetype +"', "+ catType +");", function(err, result){
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
                        response = { respcode    : 1, message     : "Successfully Save.", recordQuery : result.affectedRows + " rows Updated" }                  
                    }
                    else 
                    {
                        let response = { respcode    : 0, message     : "No Data to be save." };
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