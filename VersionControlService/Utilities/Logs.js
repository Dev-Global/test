let logs = require("log4js");

module.exports = function (method){
    var yy = new Date().getFullYear()
    var mm = parseInt(new Date().getMonth()) + 1
      , mm = mm < 10 ? '0' + mm : mm;                  
    var dd = parseInt(new Date().getDate())
      , dd = dd < 10 ? '0' + dd : dd;
                    
      logs.configure({ // configure to use all types in different files.
        appenders: { Logs: { 
                            type: "file", 
                            //filename: "C:\\kpwslogs\\VersionControlService\\VersionControlLogs - " + yy + mm + dd + ".log",
                            filename: "../../kp8globallogs/VersionControlService/VCLogs - " + yy + mm + dd + ".log",
                            maxLogSize: 10485760,
                            backups: 10
                            } 
                    },
		    categories: { default:  { 
                                appenders : ['Logs'], 
                                level     : 'all' }
    }

    });
    const log = logs.getLogger(method)
    return log;
}