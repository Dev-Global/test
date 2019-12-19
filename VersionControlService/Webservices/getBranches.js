let readIniFile = require("../Utilities/Inifile.js");
let connect = readIniFile.globalConf("DBConfig User");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[getBranches]");

module.exports = function(req, res) {

    try
    {
        let param = {};
        let recordQuery = "";
        let response;
        let chkParam;
        param.regioncode = req.query.regioncode;
        param.areacode = req.query.areacode;

        kplog.info("Parameters: " + JSON.stringify(req.query));
        chkParam = Object.keys(req.query);
        if(!((chkParam.length == 2) && (chkParam.includes("regioncode")) && (chkParam.includes("areacode"))))
        {
            response = { respcode : -1, message : "Invalid Parameters: " + JSON.stringify(req.query)};
            kplog.error(response);
            return res.json(response);
        }

        connect.query("SELECT branchname, branchcode FROM kpusersglobal.branches WHERE zonecode = 3 and regioncode = " + param.regioncode +" and areacode = '" + param.areacode + "' GROUP BY branchname ORDER BY branchcode;", function(err, rows, fields) {
        
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
                response = { respcode    : 0, message     : "No Branchname and Branchcode Found" };
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