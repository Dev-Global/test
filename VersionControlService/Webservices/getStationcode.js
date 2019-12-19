let readIniFile = require("../Utilities/Inifile.js");
let connect = readIniFile.globalConf("DBConfig kp8_Global");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[getStationcode]");

module.exports = function(req, res) {

    try
    {
        let param = {};
        let recordQuery  = "";
        let response;
        let chkParam;
        param.branchcode = req.query.branchcode;

        kplog.info("Parameters: " + JSON.stringify(req.query));
        chkParam = Object.keys(req.query);
        if(!((chkParam.length == 1) && (chkParam.includes("branchcode"))))
        {
            response = { respcode : -1, message : "Invalid Parameters: " + JSON.stringify(req.query)};
            kplog.error(response);
            return res.json(response);
        }

        connect.query("SELECT stationno, stationcode FROM kp8globalcompliance.kp8mlbranchesstations WHERE zonecode = 3 and branchcode = '" + param.branchcode + "' order by stationno;", function(err, rows, fields) {
        if(err){
            //connect.end();
            response = { respcode : -1, message : "ERROR: " + err };
            kplog.error(response);
            return res.json(response);
        }
        else {
            if(rows.length > 0) {
                response = { respcode    : 1, message     : "Success", recordQuery : rows }
            }
            else{
                response = { respcode    : 0, message     : "No Branch Station Found" };
            }
            //connect.end();
            kplog.info("respcode: " + response.respcode + " message: " + response.message);
            return res.json(response);
        }
        });
    }
    catch(error)
    {
        response = { respcode : -1, message : "ERROR: " + err };
        kplog.fatal(response);
        return res.json(response);
    }
}