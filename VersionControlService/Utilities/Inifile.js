const mysql = require("mysql");
const fs = require('fs');
const ini = require("ini");
let logging = require("../Utilities/Logs.js");
let kplog = logging("[Inifile]");

module.exports.globalConf = function getConnection(Conf) {
try{
const path = "../../kpconfig/globalConf.ini";
//const path = "C:/kpconfig/globalConf.ini";
if (fs.existsSync(path)){
    const config = ini.parse(fs.readFileSync(path,"utf-8"));
    const connection = mysql.createConnection(
        {
            host        : config[Conf].Server,
            database    : config[Conf].Database,
            user        : config[Conf].UID,
            password    : config[Conf].Password,
        },(err) => {
            if(err)
            {
                const response = {status:0, connection : "Unable to Connect Database for " + Conf};
                kplog.error(response);
                return response;
            }
        });
        return connection;
}
else{
    const response = {status:0, message : "Database Configuration file does not exist"};
    kplog.error(response);
    return response;
}
}
catch(err)
{
    response = { status : -1, message : "Database Configuration Error"};
    kplog.fatal(response);
    return response;
}
};



module.exports.kp8GlobalPort = function getPort(Conf) {
    try{
    const path = "../../kpconfig/kp8GlobalPort.ini";
    //const path = "C:/kpconfig/kp8GlobalPort.ini";
    if (fs.existsSync(path)){
        const config = ini.parse(fs.readFileSync(path,"utf-8"));
        let portNo = {
            hostName    : config[Conf].Server,
            portNum     : config[Conf].Port
        };
        return portNo;
    }
    else{
        const response = {status:0, message : "Port Configuration file does not exist"};
        kplog.error(response);
        return response;
    }
    }
    catch(err)
{
    response = { status : -1, message : "Port Configuration Error"};
    kplog.fatal(response);
    return response;
}
};