using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP8_VersionControl
{
    public class ObjectJSON
    {
        public String respcode { get; set; }
        public String message { get; set; }
    }
    public class RecordObjectAreas
    {
        public List<Areas> recordQuery { get; set; }
    }
    public class RecordObjectBranches
    {
        public List<Branches> recordQuery { get; set; }
    }
    public class RecordObjectRegions
    {
        public List<Regions> recordQuery { get; set; }
    }
    public class RecordObjectStationCode
    {
        public List<Station> recordQuery { get; set; }
    }
    public class RecordObjectVersion
    {
        public String recordQuery { get; set; }
    }
    public class Areas
    {
        public String areaname { get; set; }
        public String areacode { get; set; }
    }
    public class Branches
    {
        public String branchname { get; set; }
        public String branchcode { get; set; }
    }
    public class Regions
    {
        public String regionname { get; set; }
        public String regioncode { get; set; }
    }
    public class Station
    {
        public String stationcode { get; set; }
        public String stationNo { get; set; }
    }
    public class Version 
    {
        public String _version { get; set; }
    }
    public class UserInfo
    {
        public String username { get; set; }
        public String password { get; set; }
    }
    public class NewRelease_Insertion 
    {
        public String username { get; set; }
        public String password { get; set; }
        public String releasetype { get; set; }
        public String categorytype { get; set; }
        public String versionno { get; set; }
        public String description { get; set; }
        public String performby { get; set; }
    }
    public class SaveNationWide_Zone
    {
        public String username { get; set; }
        public String password { get; set; }
        public String releasetype { get; set; }
        public String categorytype { get; set; }
        public String zonecode { get; set; }
    }
    public class SaveRegion_Area
    {
        public String username { get; set; }
        public String password { get; set; }
        public String releasetype { get; set; }
        public String categorytype { get; set; }
        public String zonecode { get; set; }
        public String regioncode { get; set; }
        public String areacode { get; set; }
    }
    public class SaveBranch_Station
    {
        public String username { get; set; }
        public String password { get; set; }
        public String releasetype { get; set; }
        public String categorytype { get; set; }
        public String zonecode { get; set; }
        public String branchcode { get; set; }
        public String stationcode { get; set; }
    }

}
