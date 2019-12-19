let readIniFile = require("../Utilities/Inifile.js");
let connect = readIniFile.globalConf("DBConfig User");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[getRegions]");
//kplog.level = 'debug';


module.exports = function(req, res) {

    try
    {
        let param = {};
        let recordQuery = "";
        let response;
        let chkParam;
        param.zonecode  = req.query.zonecode;
        
        kplog.info("Parameters: " + JSON.stringify(req.query));
        chkParam = Object.keys(req.query);
        if(!((chkParam.length == 1) && (chkParam.includes("zonecode"))))
        {
            response = { respcode : -1, message : "Invalid Parameters: " + JSON.stringify(req.query)};
            kplog.error(response);
            return res.json(response);
        }

        connect.query("SELECT regionname, regioncode FROM kpusersglobal.region WHERE zonecode ="+ param.zonecode +" GROUP BY regionname ORDER BY regioncode", function(err, rows, feilds) {
            if(err)
            {   
                //connect.end();
                response = { respcode : -1, message : "ERROR: " + err };
                kplog.error(response);
                return res.json(response);
            }
            else
            {
                if(rows.length > 0)
                {    
                    response = { respcode    : 1, message     : "Success", recordQuery : rows }                  
                }
                else 
                {   
                    response = { respcode    : 0, message     : "No Regionname and Regioncode Found"}
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