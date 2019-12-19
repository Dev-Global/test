let readIniFile = require("../Utilities/Inifile.js");
let conUsers = readIniFile.globalConf("DBConfig User");
let conKP8 = readIniFile.globalConf("DBConfig kp8_Global");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[saveBranches]");

module.exports = function(req, res) {

    try
    {
        let param = {};
        param.username = req.body.username;
        param.password = req.body.password;
        param.zonecode = req.body.zonecode;
        param.regioncode = req.body.regioncode;
        param.areacode = req.body.areacode;
        param.releasetype = req.body.releasetype;// 3-By Region, 4-By Area
        param.categorytype = req.body.categorytype; // 1-Upgrade, 0-Downgrade
        
        let uname = "boswebserviceusr";
        let pword = "boyursa805";
        let recordQuery ="";
        let catType = "";
        let response;
        let chkParam;

        kplog.info("Parameters: " + JSON.stringify(req.body));
        chkParam = Object.keys(req.body);
        if(!((chkParam.length == 7) && (chkParam.includes("username")) && (chkParam.includes("password")) && (chkParam.includes("zonecode"))
        && (chkParam.includes("regioncode")) && (chkParam.includes("areacode"))
        && (chkParam.includes("releasetype")) && (chkParam.includes("categorytype")) && (param.username == uname && param.password == pword)
        && (param.releasetype == 3 || param.releasetype == 4) && (param.categorytype == 0 || param.categorytype == 1)))
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

            if(param.releasetype == 3){
                conUsers.query("SELECT Branchcode, AreaCode FROM kpusersglobal.branches WHERE zonecode = '"+ param.zonecode +"' AND regioncode = '"+ param.regioncode +"' GROUP BY branchname ORDER BY branchcode;", function(err, result){
                    if(err)
                    {
                        //conUsers.end();
                        response = { respcode : -1, message : "ERROR: " + err };
                        kplog.error(response);
                        return res.json(response);
                    }
                    else
                    {
                        if(result.length > 0)
                        {
                            let bcode = [];
                            let acode = [];
                            for (let i=0; i<result.length; i++){
                                bcode[i] = result[i].Branchcode;
                                acode[i] = result[i].AreaCode;
                                conKP8.query("update kp8globalcompliance.kp8mlbranchesstations "+
                                            "Set sysmodified = now(), "+
                                            "releasetype = '"+ param.releasetype +"', "+ catType +" "+
                                            "where branchcode = '"+ bcode[i] +"' "+
                                            "and zonecode = '"+ param.zonecode +"';", function(err, result){                             
                                });
                            }          
                                response = { respcode : 1, message: "Success"};                  
                        }
                        else{
                            response = { respcode : 0, message: "No Available Branch For Regioncode - " + param.regioncode};
                        }
                        //conUsers.end();
                        //conKP8.end();
                        kplog.info(response);
                        return res.json(response);
                    }
                });
            }
            else if(param.releasetype == 4){
                conUsers.query("SELECT BranchCode FROM kpusersglobal.branches WHERE zonecode = '"+ param.zonecode +"' AND regioncode = '"+ param.regioncode +"' AND areacode = '"+ param.areacode +"' GROUP BY branchname ORDER BY branchcode;", function(err, result){
                    if(err)
                    {
                        //conUsers.end();
                        response = { respcode : -1, message : "ERROR: " + err };
                        kplog.error(response);
                        return res.json(response);
                    }
                    else
                    {
                        if(result.length > 0)
                        {
                            let bcode = [];
                            for (let i=0; i<result.length; i++){
                                bcode[i] = result[i].BranchCode;
                                conKP8.query("update kp8globalcompliance.kp8mlbranchesstations "+
                                            "Set sysmodified = now(), "+
                                            "releasetype = '"+ param.releasetype +"', "+ catType +" "+
                                            "where branchcode = '"+ bcode[i] +"' "+
                                            "and zonecode = '"+ param.zonecode +"';", function(err, result){                 
                                });
                            }          
                                response = { respcode : 1, message: "Success"};                 
                        }
                        else{
                            response = { respcode : 0, message: "No Available Branch For Regioncode - " + param.regioncode + " and Areacode - " + param.areacode};
                        }
                        //conUsers.end();
                        //conKP8.end();
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