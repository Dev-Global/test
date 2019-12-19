let readIniFile = require("../Utilities/Inifile.js");
let connect = readIniFile.globalConf("DBConfig kp8_Global");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[getVersionForDowngrade]");

module.exports = function(req, res) {

    try
    {
        let param = {};
        let recordQuery = "";
        let response;
        let chkParam;
        param.releasetype = req.query.releasetype;
        
        kplog.info("Parameters: " + JSON.stringify(req.query));
        chkParam = Object.keys(req.query);
        if(!((chkParam.length == 1) && (chkParam.includes("releasetype"))))
        {
            response = { respcode : -1, message : "Invalid Parameters: " + JSON.stringify(req.query)};
            kplog.error(response);
            return res.json(response);
        }

        connect.query("SELECT FORMAT(versionno,2) AS versionno FROM `kp8globalcompliance`.`kp8versions` WHERE releasetype = "+ param.releasetype +" ORDER BY datereleased DESC Limit 1;", function(err, rows, fields) {
        
        if(err){
            //connect.end();
            response = { respcode : -1, message : "ERROR: " + err };
            kplog.error(response);
            return res.json(response);
        }
        else {
            if(rows.length > 0) {
                response = { respcode    : 1, message     : "Success", recordQuery : rows[0].versionno}
            }
            else{
                response = { respcode    : 0, message     : "No Version Found" };
            }
        //connect.end();
        kplog.info("respcode: " + response.respcode + " message: " + response.message);
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