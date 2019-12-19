using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallRestAPI;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;



namespace KP8_VersionControl
{
    public partial class VersionControl : Form
    {
        private int releasetype;
        private String stationcode;
        private Boolean chekReqfield = false;
        private const int ZoneCode = 3;
        private const string userName = "boswebserviceusr";
        private const string passWord = "boyursa805";

        private MLRestCaller GetDetails = new MLRestCaller();
        private ObjectJSON getResponse = new ObjectJSON();

        private RecordObjectAreas QueryAreas = new RecordObjectAreas();
        private RecordObjectBranches QueryBranches = new RecordObjectBranches();
        private RecordObjectRegions QueryRegions = new RecordObjectRegions();
        private RecordObjectStationCode QueryStation = new RecordObjectStationCode();

        private Dictionary<int, String> dataAreas = new Dictionary<int, string>();
        private Dictionary<int, String> dataBranches = new Dictionary<int, string>();
        private Dictionary<int, String> dataRegions = new Dictionary<int, string>();
        private Dictionary<int, String> dataStationCode = new Dictionary<int, string>();

        DialogResult answer = new DialogResult();

        public VersionControl()
        {
            InitializeComponent();
        }
        private void VersionControl_Load(object sender, EventArgs e)
        {
            if (AlreadyRunning() == true)
            {
                MessageBox.Show("Another instance is already running.", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            //this.Text = "KP8 Version Control v8.00"; //static sa..
            //this.Text += "KP8 Version Control ( v" + Read("version") + " )";
            this.Text += " v" + Read("version");
        }
        public void enableVersionDetails()
        {
            txtVersion.Enabled = true;
            txtBoxPerform.Enabled = true;
            txtBoxDescription.Enabled = true;
            cmbAction.Enabled = true;
            btnSave.Enabled = true;
            linkClear.Enabled = true;
        }
        public void disableVersionDetails()
        {
            cmbAction.Enabled = false;
            txtVersion.Enabled = false;
            txtBoxPerform.Enabled = false;
            txtBoxDescription.Enabled = false;
        }
        private void clearVersionDetails()
        {
            cmbAction.SelectedIndex = -1;
            txtVersion.Clear();
            txtBoxPerform.Clear();
            txtBoxDescription.Text = "Description Type Here..";
            this.DGdata.ColumnHeadersVisible = false;
            this.DGdata.ScrollBars = ScrollBars.None;
        }
        public void disableCategoryFields()
        {
            cmbZone.Enabled = false;
            cmbRegion.Enabled = false;
            cmbArea.Enabled = false;
            cmbBranchName.Enabled = false;
            cmbStationNo.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }
        public void clearCategoryFields(){
            cmbZone.SelectedIndex = -1;
            cmbRegion.Items.Clear();
            cmbArea.Items.Clear();
            cmbBranchName.Items.Clear();
            cmbStationNo.Items.Clear();
            DGdata.Rows.Clear();
        }
        public void catergorycheck(int cat){
            if (cat == 1)
            {
                ckBox.Visible = true;
                ckBox.Checked = true;
                ckBox.Enabled = true;
            }
            else
            {
                ckBox.Visible = false;
                ckBox.Checked = false;
                ckBox.Enabled = false;

            }
           switch (cat){
               case 1:
                   cmbZone.Enabled = false;
                   cmbRegion.Enabled = false;
                   cmbArea.Enabled = false;
                   cmbBranchName.Enabled = false;
                   cmbStationNo.Enabled = false;
                   btnAdd.Enabled = false;
                   btnDelete.Enabled = false;
                   break;
               case 2:
                   cmbZone.Enabled = true;
                   cmbRegion.Enabled = false;
                   cmbArea.Enabled = false;
                   cmbBranchName.Enabled = false;
                   cmbStationNo.Enabled = false;
                   btnAdd.Enabled = false;
                   btnDelete.Enabled = false;
                   break;
               case 3:
                   cmbZone.Enabled = true;
                   cmbRegion.Enabled = true;
                   cmbArea.Enabled = false;
                   cmbBranchName.Enabled = false;
                   cmbStationNo.Enabled = false;
                   btnAdd.Enabled = false;
                   btnDelete.Enabled = false;
                   break;
               case 4:
                   cmbZone.Enabled = true;
                   cmbRegion.Enabled = true;
                   cmbArea.Enabled = true;
                   cmbBranchName.Enabled = false;
                   cmbStationNo.Enabled = false;
                   btnAdd.Enabled = false;
                   btnDelete.Enabled = false;
                    break;
               case 5:
                   cmbZone.Enabled = true;
                   cmbRegion.Enabled = true;
                   cmbArea.Enabled = true;
                   cmbBranchName.Enabled = true;
                   cmbStationNo.Enabled = false;
                   break;
               case 6:
                    cmbZone.Enabled = true;
                    cmbRegion.Enabled = true;
                    cmbArea.Enabled = true;
                    cmbBranchName.Enabled = true;
                    cmbStationNo.Enabled = true;
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                    break;
               case 7:
                    cmbAction.SelectedIndex = 0;
                    cmbAction.Enabled = false;
                    cmbZone.Enabled = false;
                    cmbRegion.Enabled = false;
                    cmbArea.Enabled = false;
                    cmbBranchName.Enabled = false;
                    cmbStationNo.Enabled = false;
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
               case 0:
                    ckBox.Visible = false;
                    ckBox.Checked = false;
                    ckBox.Enabled = false;
                    break;
           }
         }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult answer = MessageBox.Show("Are you sure you want to reset all?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (answer == DialogResult.Yes)
                {
                    UserInfo _userinfo = new UserInfo
                    {
                        username = userName,
                        password = passWord
                    };

                    String _serialize = new JavaScriptSerializer().Serialize(_userinfo);
                    String _convert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "resetIsAllowUpdate/";
                    var _uri = new Uri(_convert);
                    Byte[] _dataresp = Encoding.UTF8.GetBytes(_serialize);
                    String _responseFrom = SendRequest(_uri, _dataresp, "application/json", "POST");
                    dynamic _agetResponse = JObject.Parse(_responseFrom);
                    getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFrom);
                                                      
                    if (getResponse.respcode == "1")
                    {
                        MessageBox.Show("All Branches are successfully reset.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbCategory.Enabled = true;
                        cmbCategory.SelectedIndex = -1;
                        linkClear_Click(sender, e);
                    }
                    else if (getResponse.respcode.Equals("0"))
                    {
                        MessageBox.Show("Branches are already resetted.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("Error in resetting all branches." + Convert.ToString(_agetResponse.message), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    
                }
                if (answer == DialogResult.No)
                {
                    MessageBox.Show("This application will be closed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                cmbCategory.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            dataAreas.Clear();
            dataBranches.Clear();
            dataRegions.Clear();
            dataStationCode.Clear();
            cmbArea.Items.Clear();
            cmbBranchName.Items.Clear();
            cmbRegion.Items.Clear();
            cmbStationNo.Items.Clear();
            //cmbZone.Items.Clear();
            
            switch (cmbCategory.Text)
            {
                case "BY NATIONWIDE":
                    releasetype = 1;
                    clearVersionDetails();
                    enableVersionDetails();
                    catergorycheck(1);
                    clearCategoryFields();

                    break;
                case "BY ZONE":
                    releasetype = 2;
                    clearVersionDetails();
                    enableVersionDetails();
                    catergorycheck(2);
                    clearCategoryFields();
                    break;

                case "BY REGION":
                    releasetype = 3;
                    clearVersionDetails();
                    enableVersionDetails();
                    catergorycheck(3);
                    clearCategoryFields();                  
                    break;

                case "BY AREA":
                    releasetype = 4;
                    clearVersionDetails();
                    enableVersionDetails();
                    catergorycheck(4);
                    clearCategoryFields();
                    break;

                case "BY BRANCH":
                    releasetype = 5;
                    clearVersionDetails();
                    enableVersionDetails();
                    catergorycheck(5);
                    clearCategoryFields();                   
                    break;

                case "BY STATION":
                    releasetype = 6;
                    clearVersionDetails();
                    enableVersionDetails();
                    catergorycheck(6);
                    clearCategoryFields();                  
                    break;

                case "BY NEW RELEASE":
                    releasetype = 7;
                    clearVersionDetails();
                    enableVersionDetails();
                    catergorycheck(7);
                    clearCategoryFields();
                    break;

            }

        }     
        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        private void cmbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRegion.Items.Clear();
            dataRegions.Clear();

            if (cmbZone.Text.Equals("USA"))
            {
                GetDetails = new MLRestCaller((ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "getRegions?zonecode=" + ZoneCode, HttpVerb.GET);
                GetDetails.ContentType = "application/json";
                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(GetDetails.MakeRequest());

                if (getResponse.respcode == "1")
                {
                    QueryRegions = JsonConvert.DeserializeObject<RecordObjectRegions>(GetDetails.MakeRequest());

                    for (int x = 0; x < QueryRegions.recordQuery.Count; x++)
                    {
                        dataRegions.Add(x, QueryRegions.recordQuery[x].regioncode);
                        cmbRegion.Items.Add(QueryRegions.recordQuery[x].regionname);
                    }
                }
                else { MessageBox.Show(getResponse.message); }
            }
        }
        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbArea.Items.Clear();
            dataAreas.Clear();


            if (cmbZone.Text.Equals("USA"))
            {
                GetDetails = new MLRestCaller((ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "getAreas?regioncode=" + dataRegions[(cmbRegion.SelectedIndex)], HttpVerb.GET);
                GetDetails.ContentType = "application/json";
                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(GetDetails.MakeRequest());

                if (getResponse.respcode == "1")
                {
                    QueryAreas = JsonConvert.DeserializeObject<RecordObjectAreas>(GetDetails.MakeRequest());

                    for (int x = 0; x < QueryAreas.recordQuery.Count; x++)
                    {
                        dataAreas.Add(x, QueryAreas.recordQuery[x].areacode);
                        cmbArea.Items.Add(QueryAreas.recordQuery[x].areaname);
                    }
                }
                else { MessageBox.Show(getResponse.message); }
            }
        }
        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBranchName.Items.Clear();
            dataBranches.Clear();

            if (cmbZone.Text.Equals("USA"))
            {
                GetDetails = new MLRestCaller((ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "getBranches?regioncode=" + dataRegions[(cmbRegion.SelectedIndex)] + "&areacode=" + dataAreas[(cmbArea.SelectedIndex)], HttpVerb.GET);
                GetDetails.ContentType = "application/json";
                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(GetDetails.MakeRequest());

                if (getResponse.respcode == "1")
                {
                    QueryBranches = JsonConvert.DeserializeObject<RecordObjectBranches>(GetDetails.MakeRequest());

                    for (int x = 0; x < QueryBranches.recordQuery.Count; x++)
                    {
                        dataBranches.Add(x, QueryBranches.recordQuery[x].branchcode);
                        cmbBranchName.Items.Add(QueryBranches.recordQuery[x].branchname);
                    }
                }
                else { MessageBox.Show(getResponse.message); }
            }
        }
        private void cmbBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStationNo.Items.Clear();
            dataStationCode.Clear();

            if (cmbZone.Text.Equals("USA"))
            {
                GetDetails = new MLRestCaller((ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "getStationcode?branchcode=" + dataBranches[(cmbBranchName.SelectedIndex)], HttpVerb.GET);
                GetDetails.ContentType = "application/json";
                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(GetDetails.MakeRequest());

                if (getResponse.respcode == "1")
                {
                    QueryStation = JsonConvert.DeserializeObject<RecordObjectStationCode>(GetDetails.MakeRequest());

                    for (int x = 0; x < QueryStation.recordQuery.Count; x++)
                    {
                        dataStationCode.Add(x, QueryStation.recordQuery[x].stationcode);
                        cmbStationNo.Items.Add(QueryStation.recordQuery[x].stationNo);
                        stationcode = QueryStation.recordQuery[x].stationcode;
                    }
                }
                else { MessageBox.Show(getResponse.message); }
                txtBrancCode.Enabled = true;
                txtBrancCode.Text = dataBranches[(cmbBranchName.SelectedIndex)];
                cmbStationNo.Equals(dataBranches[(cmbBranchName.SelectedIndex)]);
            }
        }
        private Boolean AlreadyRunning()
        {
            Process my_Proc = Process.GetCurrentProcess();
            String my_Name = my_Proc.ProcessName;

            Process[] process = Process.GetProcessesByName(my_Name);

            if (process.Length == 1) { return false; }

            for (int i = 0; i <= process.Length - 1; i++)
            {
                if (process[i].StartTime < my_Proc.StartTime) { return true; }
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                checkText();
                #region Upgrade
                if (chekReqfield.Equals(false)) { return; }                
                else
                {
                    if (cmbCategory.Text == "BY NATIONWIDE")
                    {
                        if (!(ckBox.Checked)) { MessageBox.Show("Please check nationwide.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    }
                    if (cmbAction.Text.Equals("UPGRADE"))
                    {
                        answer = MessageBox.Show("Are you sure you want to proceed", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (answer == DialogResult.Yes)
                        {
                            int categorytype = 1;

                            if ((releasetype.Equals(1) ||  releasetype.Equals(2)) && (categorytype.Equals(1)))
                            {
                                //---saving------//
                                SaveNationWide_Zone infosaving = new SaveNationWide_Zone
                                {
                                    username = userName,
                                    password = passWord,
                                    releasetype = Convert.ToString(releasetype),
                                    categorytype = Convert.ToString(categorytype),
                                    zonecode = Convert.ToString(ZoneCode)                                   
                                };
                                String _serialize = new JavaScriptSerializer().Serialize(infosaving);
                                String _convert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "allowUpdateForAll/";
                                var _uri = new Uri(_convert);
                                Byte[] _dataresp = Encoding.UTF8.GetBytes(_serialize);
                                String _responseFrom = SendRequest(_uri, _dataresp, "application/json", "POST");
                                dynamic _agetResponse = JObject.Parse(_responseFrom);
                                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFrom);
                              
                                if (getResponse.respcode == "1" || (getResponse.respcode == "0"))
                                {
                                    //--insertion--//                                   
                                    NewRelease_Insertion infoinsert = new NewRelease_Insertion
                                    {
                                        username = userName,
                                        password = passWord,
                                        releasetype = Convert.ToString(releasetype),
                                        categorytype = Convert.ToString(categorytype),
                                        versionno = txtVersion.Text,
                                        description = txtBoxDescription.Text,
                                        performby = txtBoxPerform.Text
                                    };
                                    String _serializeinsert = new JavaScriptSerializer().Serialize(infoinsert);
                                    String _convertinsert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "insertVersion/";
                                    var _uriinsert = new Uri(_convertinsert);
                                    Byte[] _datarespinsert = Encoding.UTF8.GetBytes(_serializeinsert);
                                    String _responseFromInsert = SendRequest(_uriinsert, _datarespinsert, "application/json", "POST");
                                    dynamic _agetResponseInsert = JObject.Parse(_responseFromInsert);
                                    getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFromInsert);

                                    if (getResponse.respcode == "1" || (getResponse.respcode == "0"))
                                    {
                                        MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        linkClear_Click(sender, e);
                                        catergorycheck(0);
                                        cmbCategory.SelectedIndex = -1;
                                        cmbCategory.Enabled = false;
                                        btnSave.Enabled = false;
                                        linkClear.Enabled = false;
                                    }
                                    else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }                                                                  
                                }
                                else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }

                            else if ((releasetype.Equals(3) || releasetype.Equals(4)) && (categorytype.Equals(1)))
                            {
                                String area;
                                if (cmbArea.Text == "") { area = String.Empty; }
                                else { area = dataAreas[cmbArea.SelectedIndex]; }
                                //---saving---//
                                SaveRegion_Area infosaving = new SaveRegion_Area
                                {
                                    username = userName,
                                    password = passWord,
                                    releasetype = Convert.ToString(releasetype),
                                    categorytype = Convert.ToString(categorytype),
                                    regioncode = dataRegions[(cmbRegion.SelectedIndex)],
                                    //areacode = dataAreas[cmbArea.SelectedIndex],
                                    areacode = area,
                                    zonecode = Convert.ToString(ZoneCode)                                                                    
                                };
                                String _serialize = new JavaScriptSerializer().Serialize(infosaving);
                                String _convert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "saveBranches/";
                                var _uri = new Uri(_convert);
                                Byte[] _dataresp = Encoding.UTF8.GetBytes(_serialize);
                                String _responseFrom = SendRequest(_uri, _dataresp, "application/json", "POST");
                                dynamic _agetResponse = JObject.Parse(_responseFrom);
                                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFrom);
                                
                                if (getResponse.respcode == "1" || getResponse.respcode == "0")
                                {
                                    //--insertion--//
                                    NewRelease_Insertion infoinsert = new NewRelease_Insertion
                                    {
                                        username = userName,
                                        password = passWord,
                                        releasetype = Convert.ToString(releasetype),
                                        categorytype = Convert.ToString(categorytype),
                                        versionno = txtVersion.Text,
                                        description = txtBoxDescription.Text,
                                        performby = txtBoxPerform.Text
                                    };
                                    String _serializeinsert = new JavaScriptSerializer().Serialize(infoinsert);
                                    String _convertinsert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "insertVersion/";
                                    var _uriinsert = new Uri(_convertinsert);
                                    Byte[] _datarespinsert = Encoding.UTF8.GetBytes(_serializeinsert);
                                    String _responseFromInsert = SendRequest(_uriinsert, _datarespinsert, "application/json", "POST");
                                    dynamic _agetResponseInsert = JObject.Parse(_responseFromInsert);
                                    getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFromInsert);

                                    if (getResponse.respcode == "1" || getResponse.respcode == "0")
                                    {
                                        MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        linkClear_Click(sender, e);
                                        cmbCategory.SelectedIndex = -1;
                                        cmbCategory.Enabled = false;
                                        btnSave.Enabled = false;
                                        linkClear.Enabled = false;
                                    }
                                    else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                }                                
                                else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }

                            else if ((releasetype.Equals(5) || releasetype.Equals(6)) && (categorytype.Equals(1)))
                            {
                                //--saving--//
                                SaveBranch_Station infosaving = new SaveBranch_Station
                                {
                                    username = userName,
                                    password = passWord,
                                    releasetype = Convert.ToString(releasetype),
                                    categorytype = Convert.ToString(categorytype),
                                    branchcode = dataBranches[(cmbBranchName.SelectedIndex)],
                                    stationcode = stationcode,
                                    zonecode = Convert.ToString(ZoneCode)
                                };
                                String _serialize = new JavaScriptSerializer().Serialize(infosaving);
                                String _convert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "updateByBranchOrStation/";
                                var _uri = new Uri(_convert);
                                Byte[] _dataresp = Encoding.UTF8.GetBytes(_serialize);
                                String _responseFrom = SendRequest(_uri, _dataresp, "application/json", "POST");
                                dynamic _agetResponse = JObject.Parse(_responseFrom);
                                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFrom);

                                if (getResponse.respcode == "1" || getResponse.respcode == "0")
                                {
                                    //--insertion--//
                                    NewRelease_Insertion infoinsert = new NewRelease_Insertion
                                    {
                                        username = userName,
                                        password = passWord,
                                        releasetype = Convert.ToString(releasetype),
                                        categorytype = Convert.ToString(categorytype),
                                        versionno = txtVersion.Text,
                                        description = txtBoxDescription.Text,
                                        performby = txtBoxPerform.Text
                                    };
                                    String _serializeinsert = new JavaScriptSerializer().Serialize(infoinsert);
                                    String _convertinsert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "insertVersion/";
                                    var _uriinsert = new Uri(_convertinsert);
                                    Byte[] _datarespinsert = Encoding.UTF8.GetBytes(_serializeinsert);
                                    String _responseFromInsert = SendRequest(_uriinsert, _datarespinsert, "application/json", "POST");
                                    dynamic _agetResponseInsert = JObject.Parse(_responseFromInsert);
                                    getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFromInsert);

                                    if (getResponse.respcode == "1" || getResponse.respcode == "0")
                                    {
                                        MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        linkClear_Click(sender, e);
                                        cmbCategory.SelectedIndex = -1;
                                        cmbCategory.Enabled = false;
                                        btnSave.Enabled = false;
                                        linkClear.Enabled = false;
                                    }
                                    else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                }
                                else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }
                            else if (releasetype.Equals(7) && categorytype.Equals(1))
                            {
                                NewRelease_Insertion infoinsert = new NewRelease_Insertion
                                {
                                    username = userName,
                                    password = passWord,
                                    releasetype = Convert.ToString(releasetype),
                                    categorytype = Convert.ToString(categorytype),
                                    versionno = txtVersion.Text,
                                    description = txtBoxDescription.Text,
                                    performby = txtBoxPerform.Text
                                };
                                String _serializeinsert = new JavaScriptSerializer().Serialize(infoinsert);
                                String _convertinsert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "insertVersion/";
                                var _uriinsert = new Uri(_convertinsert);
                                Byte[] _datarespinsert = Encoding.UTF8.GetBytes(_serializeinsert);
                                String _responseFromInsert = SendRequest(_uriinsert, _datarespinsert, "application/json", "POST");
                                dynamic _agetResponseInsert = JObject.Parse(_responseFromInsert);
                                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFromInsert);

                                if (getResponse.respcode == "1")
                                {
                                    MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    linkClear_Click(sender, e);
                                    cmbCategory.SelectedIndex = -1;
                                    cmbCategory.Enabled = false;
                                    btnSave.Enabled = false;
                                    linkClear.Enabled = false;
                                }
                                else if (getResponse.respcode == "0")
                                {
                                    MessageBox.Show(getResponse.message.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else { MessageBox.Show("Error has been occured." + getResponse.respcode + getResponse.message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                #endregion
                #region DownGrade
                    else if (cmbAction.Text.Equals("DOWNGRADE"))
                    {
                        answer = MessageBox.Show("Are you sure you want to proceed", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (answer == DialogResult.Yes)
                        {
                            int categorytype = 0;

                            if ((releasetype.Equals(1) || releasetype.Equals(2)) && (categorytype.Equals(0)))
                            {
                                //---saving------//
                                SaveNationWide_Zone infosaving = new SaveNationWide_Zone
                                {
                                    username = userName,
                                    password = passWord,
                                    releasetype = Convert.ToString(releasetype),
                                    categorytype = Convert.ToString(categorytype),
                                    zonecode =  Convert.ToString(ZoneCode)
                                };

                                String _serialize = new JavaScriptSerializer().Serialize(infosaving);
                                String _convert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "allowUpdateForAll/";
                                var _uri = new Uri(_convert);
                                Byte[] _dataresp = Encoding.UTF8.GetBytes(_serialize);
                                String _responseFrom = SendRequest(_uri, _dataresp, "application/json", "POST");
                                dynamic _agetResponse = JObject.Parse(_responseFrom);
                                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFrom);

                                if (getResponse.respcode == "1" || (getResponse.respcode == "0"))
                                {
                                    //--insertion--//
                                    NewRelease_Insertion infoinsert = new NewRelease_Insertion
                                    {
                                        username = userName,
                                        password = passWord,
                                        releasetype = Convert.ToString(releasetype),
                                        categorytype = Convert.ToString(categorytype),
                                        versionno = txtVersion.Text,
                                        description = txtBoxDescription.Text,
                                        performby = txtBoxPerform.Text
                                    };
                                    String _serializeinsert = new JavaScriptSerializer().Serialize(infoinsert);
                                    String _convertinsert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "insertVersion/";
                                    var _uriinsert = new Uri(_convertinsert);
                                    Byte[] _datarespinsert = Encoding.UTF8.GetBytes(_serializeinsert);
                                    String _responseFromInsert = SendRequest(_uriinsert, _datarespinsert, "application/json", "POST");
                                    dynamic _agetResponseInsert = JObject.Parse(_responseFromInsert);
                                    getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFromInsert);

                                    if (getResponse.respcode == "1" || (getResponse.respcode == "0"))
                                    {
                                        MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        linkClear_Click(sender, e);
                                        catergorycheck(0);
                                        cmbCategory.SelectedIndex = -1;
                                        cmbCategory.Enabled = false;
                                        btnSave.Enabled = false;
                                        linkClear.Enabled = false;
                                    }
                                    else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                }
                                else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }

                            else if ((releasetype.Equals(3) || releasetype.Equals(4)) && (categorytype.Equals(0)))
                            {
                                String area;
                                if (cmbArea.Text == "") { area = String.Empty; }
                                else { area = dataAreas[cmbArea.SelectedIndex]; }
                                //---saving---//
                                SaveRegion_Area infosaving = new SaveRegion_Area
                                {
                                    username = userName,
                                    password = passWord,
                                    releasetype = Convert.ToString(releasetype),
                                    categorytype = Convert.ToString(categorytype),
                                    regioncode = dataRegions[(cmbRegion.SelectedIndex)],
                                    //areacode = dataAreas[(cmbArea.SelectedIndex)],
                                    areacode = area,
                                    zonecode = Convert.ToString(ZoneCode)
                                };

                                String _serialize = new JavaScriptSerializer().Serialize(infosaving);
                                String _convert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "saveBranches/";
                                var _uri = new Uri(_convert);
                                Byte[] _dataresp = Encoding.UTF8.GetBytes(_serialize);
                                String _responseFrom = SendRequest(_uri, _dataresp, "application/json", "POST");
                                dynamic _agetResponse = JObject.Parse(_responseFrom);
                                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFrom);


                                if (getResponse.respcode == "1" || getResponse.respcode == "0")
                                {
                                    //--insertion--//
                                    NewRelease_Insertion infoinsert = new NewRelease_Insertion
                                    {
                                        username = userName,
                                        password = passWord,
                                        releasetype = Convert.ToString(releasetype),
                                        categorytype = Convert.ToString(categorytype),
                                        versionno = txtVersion.Text,
                                        description = txtBoxDescription.Text,
                                        performby = txtBoxPerform.Text
                                    };
                                    String _serializeinsert = new JavaScriptSerializer().Serialize(infoinsert);
                                    String _convertinsert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "insertVersion/";
                                    var _uriinsert = new Uri(_convertinsert);
                                    Byte[] _datarespinsert = Encoding.UTF8.GetBytes(_serializeinsert);
                                    String _responseFromInsert = SendRequest(_uriinsert, _datarespinsert, "application/json", "POST");
                                    dynamic _agetResponseInsert = JObject.Parse(_responseFromInsert);
                                    getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFromInsert);

                                    if (getResponse.respcode == "1" || getResponse.respcode == "0")
                                    {
                                        MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        linkClear_Click(sender, e);
                                        cmbCategory.SelectedIndex = -1;
                                        cmbCategory.Enabled = false;
                                        btnSave.Enabled = false;
                                        linkClear.Enabled = false;
                                    }
                                    else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                }
                                else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }
                            else if ((releasetype.Equals(5) || releasetype.Equals(6)) && (categorytype.Equals(0)))
                            {
                                //---saving---//
                                SaveBranch_Station infosaving = new SaveBranch_Station
                                {
                                    username = userName,
                                    password = passWord,
                                    releasetype = Convert.ToString(releasetype),
                                    categorytype = Convert.ToString(categorytype),
                                    branchcode = dataBranches[(cmbBranchName.SelectedIndex)],
                                    stationcode = stationcode,
                                    zonecode = Convert.ToString(ZoneCode)
                                };

                                String _serialize = new JavaScriptSerializer().Serialize(infosaving);
                                String _convert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "updateByBranchOrStation/";
                                var _uri = new Uri(_convert);
                                Byte[] _dataresp = Encoding.UTF8.GetBytes(_serialize);
                                String _responseFrom = SendRequest(_uri, _dataresp, "application/json", "POST");
                                dynamic _agetResponse = JObject.Parse(_responseFrom);
                                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFrom);

                                if (getResponse.respcode == "1" || getResponse.respcode == "0")
                                {
                                    //--insertion--//
                                    NewRelease_Insertion infoinsert = new NewRelease_Insertion
                                    {
                                        username = userName,
                                        password = passWord,
                                        releasetype = Convert.ToString(releasetype),
                                        categorytype = Convert.ToString(categorytype),
                                        versionno = txtVersion.Text,
                                        description = txtBoxDescription.Text,
                                        performby = txtBoxPerform.Text
                                    };
                                    String _serializeinsert = new JavaScriptSerializer().Serialize(infoinsert);
                                    String _convertinsert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "insertVersion/";
                                    var _uriinsert = new Uri(_convertinsert);
                                    Byte[] _datarespinsert = Encoding.UTF8.GetBytes(_serializeinsert);
                                    String _responseFromInsert = SendRequest(_uriinsert, _datarespinsert, "application/json", "POST");
                                    dynamic _agetResponseInsert = JObject.Parse(_responseFromInsert);
                                    getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFromInsert);

                                    if (getResponse.respcode == "1" || getResponse.respcode == "0")
                                    {
                                        MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        linkClear_Click(sender, e);
                                        cmbCategory.SelectedIndex = -1;
                                        cmbCategory.Enabled = false;
                                        btnSave.Enabled = false;
                                        linkClear.Enabled = false;
                                    }
                                    else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                }
                                else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }
                            
                            else if (releasetype.Equals(7) && categorytype.Equals(0))
                            {
                                //--insertion--//
                                NewRelease_Insertion infoinsert = new NewRelease_Insertion
                                {
                                    username = userName,
                                    password = passWord,
                                    releasetype = Convert.ToString(releasetype),
                                    categorytype = Convert.ToString(categorytype),
                                    versionno = txtVersion.Text,
                                    description = txtBoxDescription.Text,
                                    performby = txtBoxPerform.Text
                                };
                                String _serializeinsert = new JavaScriptSerializer().Serialize(infoinsert);
                                String _convertinsert = (ReadIniFile.fromIniFile("GetKp8VersionControl", "GetKp8VersionControlURL")) + "insertVersion/";
                                var _uriinsert = new Uri(_convertinsert);
                                Byte[] _datarespinsert = Encoding.UTF8.GetBytes(_serializeinsert);
                                String _responseFromInsert = SendRequest(_uriinsert, _datarespinsert, "application/json", "POST");
                                dynamic _agetResponseInsert = JObject.Parse(_responseFromInsert);
                                getResponse = JsonConvert.DeserializeObject<ObjectJSON>(_responseFromInsert);

                                if (getResponse.respcode == "1")
                                {
                                    MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    linkClear_Click(sender, e);
                                    cmbCategory.SelectedIndex = -1;
                                    cmbCategory.Enabled = false;
                                    btnSave.Enabled = false;
                                    linkClear.Enabled = false;
                                }
                                else if (getResponse.respcode == "0")
                                {
                                    MessageBox.Show(getResponse.message.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else { MessageBox.Show("Error has been occured.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                            }
                        }
                        else
                        {
                            this.Close();
                        }
                    }
#endregion
                else { return; }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var withBlock = this.DGdata;
            int a = 0;
            
            if (cmbCategory.Text == "BY BRANCH")
            {
                this.DGdata.ColumnHeadersVisible = true;
                withBlock.ColumnCount = 2;
                withBlock.Columns[0].Width = 243;
                withBlock.Columns[1].Width = 100;
                withBlock.Columns[0].HeaderText = "Branch Name";
                withBlock.Columns[1].HeaderText = "Branchcode";
                withBlock.Columns[0].ReadOnly = true;
                withBlock.Columns[1].ReadOnly = true;
                withBlock.Columns[0].Resizable = DataGridViewTriState.False;
                withBlock.Columns[1].Resizable = DataGridViewTriState.False;
                this.DGdata.ScrollBars = ScrollBars.Both;

                if (cmbBranchName.Text != "")
                {
                    if (withBlock.CurrentRow == null)
                    {
                        String[] row = new[] { cmbBranchName.Text.Trim(), txtBrancCode.Text };
                        withBlock.Rows.Add(row);
                        return;
                    }
                    for (var i = 0; i <= withBlock.Rows.Count - 1; i++)
                    {
                        if (withBlock[0, i].Value.ToString() == cmbBranchName.Text.Trim())
                        {
                            a += 1;
                        }
                    }
                    if (a != 0)
                    {
                        MessageBox.Show("Already added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        String[] row = new[] { cmbBranchName.Text.Trim(), txtBrancCode.Text };
                        withBlock.Rows.Add(row);
                    }
                }
            }
            else if (cmbCategory.Text == "BY STATION")
            {
                this.DGdata.ColumnHeadersVisible = true;
                withBlock.ColumnCount = 3;
                withBlock.Columns[0].Width = 243;
                withBlock.Columns[1].Width = 100;
                withBlock.Columns[2].Width = 100;
                withBlock.Columns[0].HeaderText = "Branch Code";
                withBlock.Columns[1].HeaderText = "Station No.";
                withBlock.Columns[0].ReadOnly = true;
                withBlock.Columns[1].ReadOnly = true;
                withBlock.Columns[2].Visible = false;
                withBlock.Columns[0].Resizable = DataGridViewTriState.False;
                withBlock.Columns[1].Resizable = DataGridViewTriState.False;
                this.DGdata.ScrollBars = ScrollBars.Both;

                if (cmbStationNo.Text != "")
                {
                    if (withBlock.CurrentRow == null)
                    {
                        String[] row = new[] { txtBrancCode.Text, cmbStationNo.Text.Trim(), stationcode };
                        withBlock.Rows.Add(row);
                        return;
                    }
                    for (var i = 0; i <= withBlock.Rows.Count - 1; i++)
                    {
                        if (withBlock[1, i].Value.ToString() == cmbStationNo.Text.Trim() & withBlock[0, i].Value.ToString() == txtBrancCode.Text.Trim()) { a += 1; }
                    }
                    if (a != 0) { MessageBox.Show("Already added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else
                    {
                        String[] row = new[] { txtBrancCode.Text, cmbStationNo.Text.Trim(), stationcode };
                        withBlock.Rows.Add(row);
                    }
                }
                else { MessageBox.Show("Please select station number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var withBlock = this.DGdata;

            if (withBlock.Rows.Count < 1) { return; }
            else { withBlock.Rows.Remove(withBlock.CurrentRow);
            }
        }
        private void checkText()
        {
            if ((cmbCategory.Text == string.Empty && cmbCategory.Enabled == true))
            {
                MessageBox.Show("Please select Category.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                cmbCategory.Focus();
            }
            else if (cmbZone.Text == string.Empty && cmbZone.Enabled == true)
            {
                MessageBox.Show("Please select Zone.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                cmbZone.Focus();

            }
            else if (cmbRegion.Text == string.Empty && cmbRegion.Enabled == true)
            {
                MessageBox.Show("Please select Region.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                cmbZone.Focus();

            }
            else if (cmbArea.Text == string.Empty && cmbArea.Enabled == true)
            {
                MessageBox.Show("Please select Area.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                cmbZone.Focus();

            }
            else if (cmbBranchName.Text == string.Empty && cmbBranchName.Enabled == true)
            {
                MessageBox.Show("Please select BranchName.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                cmbZone.Focus();

            }
            else if (cmbStationNo.Text == string.Empty && cmbStationNo.Enabled == true)
            {
                MessageBox.Show("Please select StationNo.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                cmbZone.Focus();

            }
            else if (cmbStationNo.Text != string.Empty && DGdata.Rows.Count == 0)
            {
                MessageBox.Show("No Station Number Added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                cmbZone.Focus();

            }
            else if ((txtVersion.Text == string.Empty && txtVersion.Enabled == true))
            {
                MessageBox.Show("Please input version number.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                txtVersion.Focus();
            }
            else if ((txtBoxPerform.Text == string.Empty && txtBoxPerform.Enabled == true))
            {
                MessageBox.Show("Please input name of performer.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                txtBoxPerform.Focus();
            }
            else if ((txtBoxDescription.Text == "Description Type Here.." || txtBoxDescription.Text == string.Empty && txtBoxDescription.Enabled == true))
            {
                txtBoxDescription.Text = "";
                MessageBox.Show("Please input description.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                txtBoxDescription.Focus();
            }
            else if ((cmbAction.Text == string.Empty && txtBoxPerform.Enabled == true))
            {
                MessageBox.Show("Please select action.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chekReqfield = false;
                cmbAction.Focus();
            }
            else { chekReqfield = true; }
            
        }
        private void txtVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }
            if ((e.KeyChar) == '.')
            {
                if (txtVersion.Text.IndexOf(".") > -1) { e.Handled = true; }
                else { e.Handled = false; }
            }
        }
        private void txtBoxPerform_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) { e.Handled = true; }
            if ((e.KeyChar) == '.')
            {
                if (txtBoxPerform.Text.IndexOf(".") > -1) { e.Handled = true; }
                else { e.Handled = false; }
            }
        }
        private void txtBoxDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) { e.Handled = true; }
        }
        private void linkClear_Click(object sender, EventArgs e)
        {
            clearVersionDetails();
            clearCategoryFields();
            disableVersionDetails();
            disableCategoryFields();

            DGdata.Rows.Clear();
            DGdata.ColumnHeadersVisible = false;
           
            this.DGdata.ScrollBars = ScrollBars.None;
        }
        private String SendRequest(Uri uri, Byte[] jsonDataBytes, String contentType, String method)
        {
            try
            {
                WebRequest req = WebRequest.Create(uri);
                req.ContentType = contentType;
                req.Method = method;
                req.ContentLength = jsonDataBytes.Length;

                Stream stream = req.GetRequestStream();
                stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
                stream.Close();

                WebResponse webresponse = req.GetResponse();
                Stream response = webresponse.GetResponseStream();

                String res = null;
                if (response != null)
                {
                    var reader = new StreamReader(response);
                    res = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                }
                return res;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private void txtBoxDescription_Enter(object sender, EventArgs e)
        {
            if (txtBoxDescription.Text == "Description Type Here..")
            {
                txtBoxDescription.Text = "";
            }
        }
        private void txtBoxDescription_Leave(object sender, EventArgs e)
        {
            if (txtBoxDescription.Text == "")
            {
                txtBoxDescription.Text = "Description Type Here..";
            }
       }
        private void linkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkClear_Click(sender, e);
        }
        private String Read(String keyname) 
        {
            try
            {
                String fileLoc = Application.StartupPath + "\\version.txt";

                if (File.Exists(fileLoc)) 
                {
                    return File.ReadAllText(fileLoc);
                }
                return String.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("Version Error" + keyname.ToUpper() + "Version Error ");
                return String.Empty;
            }
            
        }
        private void txtVersion_Leave(object sender, EventArgs e)
        {
            txtBoxPerform.Select();
            txtBoxPerform.Focus();
            
        }
        private void txtBoxPerform_Leave(object sender, EventArgs e)
        {
            txtBoxDescription.Select();
            txtBoxDescription.Focus();
        }
    }
}
