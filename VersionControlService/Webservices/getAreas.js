let readIniFile = require("../Utilities/Inifile.js");
let connect = readIniFile.globalConf("DBConfig User");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[getAreas]");

module.exports = function(req, res) {

    try
    {
        let recordQuery  = "";
        let param = {};
        let response;
        let chkParam;
        param.regioncode = req.query.regioncode;

        kplog.info("Parameters: " + JSON.stringify(req.query));
        chkParam = Object.keys(req.query);
        if(!((chkParam.length == 1) && (chkParam.includes("regioncode"))))
        {
            response = { respcode : -1, message : "Invalid Parameters: " + JSON.stringify(req.query)};
            kplog.error(response);
            return res.json(response);
        }
    
        connect.query("SELECT areaname, areacode FROM kpusersglobal.area WHERE zonecode = 3 and regioncode = " + param.regioncode +" GROUP BY areaname ORDER BY areacode;", function(err, rows, fields) {
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
                response = { respcode    : 0, message     : "No Areaname and Areacode Found" };
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