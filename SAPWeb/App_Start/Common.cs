using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Imaging;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Web;
using System.Data.Odbc;
using System.Runtime.InteropServices;
using System.Globalization;
using SAPWeb.App_Start;


//{
public enum QuestionType
{
    Security = 1
}

public enum GenderType
{
    Male = 'M',
    Female = 'F'
}

public enum OptionType
{
    Any = '1',
    Many = '2',
    Descriptive = '3'
}

public enum QuotationBaseDocument
{
    Opportunity = '1',
    Quotation = '2'
}

public enum InvoiceBaseDocument
{
    Order = '1'
}

public enum QuotationStatus
{
    Open = '1'
    //Transfer = '2'
}

public enum OrderStatus
{
    Open = '1',
    Transfer = '2',
    Close = '3'

}

public enum InvRequestStatus
{
    Open = '1',
    Close = '2'

}

public enum DeliveryStatus
{
    Open = '1',
    Partial = '2',
    Close = '3'
}

public enum FeedbackType
{
    Material = '1',
    Service = '2',
    Other = '3'
}

public enum AddressType
{
    BillTo = '1',
    ShipTo = '2'
}

public enum MonthNames
{
    January = 1,
    February = 2,
    March = 3,
    April = 4,
    May = 5,
    June = 6,
    July = 7,
    August = 8,
    September = 9,
    October = 10,
    November = 11,
    December = 12
}

public enum StatusType

{
    Open = 1,
    InProcess = 2,
    Approved = 3,
    Modify = 4,
    Hold = 5,
    Rejected = 6,
    Submit = 7
}

public enum TaskEntryStatus
{
    Open = 1,
    InProcess = 2,
    Hold = 3,
    Completed = 4,
    Cancel = 5,
    Approved = 6,
    Differed = 7,
    Rejected = 8
}

public enum Operations
{
    Add = 1,
    Update = 2,
    Any = 3
}

public enum Conditions
{
    FINISH = 1,
    OR = 2,
    THEN = 3,
}

public enum SQLOperators
{
    AND = 1,
    OR = 2
}

//public enum TravelMode
//{
//    Bus = 1,
//    Train = 2,
//    Air = 3,
//    Auto = 4,
//    Cab = 5,
//    Bike = 6,
//    Other = 7
//}

public enum TimeSheetEntryMode
{
    Auto = 1,
    TimeSheet = 2,
    ExpenseEntry = 3,
    TaskEntry = 4
}

public enum QuestionMaster
{
    // Type
    Product = 'P',
    Service = 'S',
    Other = 'O',

    //DocType
    FeedBack = 'F',
    Campaign = 'C',
    SecurityQuestion = 'S'
}

public class EnumList
{
    public IEnumerable<KeyValuePair<int, string>> Of<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>().Select(p => new KeyValuePair<int, string>(Convert.ToInt32(p), p.ToString())).ToList();
    }
}

public class Constant
{
    public const string AuthKey = "=vCd&DBj=";

    public const string DateFormat = "dd/MM/yyyy";
    public const string TimeFormat = "hh:mm:ss";
    public const string Currency = "INR";

    //public const string EmployeePhoto = "~/Document/Employee/";
    // public const string Reports = "~/Document/Reports/";
}
namespace SAPWeb.App_Start
{

    public class Common
    {
        public static SQL_CONN_Class objCon = null;

        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        public static IDictionary<string, string> GetAll<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<string, string>();
            var ENUMS = Enum.GetValues(enumerationType);
            foreach (string value in ENUMS)
            {
                var name = Enum.GetName(enumerationType, value);
                dictionary.Add(value, name);
            }

            return dictionary;
        }

        public static long CheckSCM3(string ItemCode, Nullable<long> schemeID, long Scheme3ID)
        {
            objCon = new SQL_CONN_Class();

            string ParamName = "";
            string ParamVal = "";

            ParamName = "ItemCode|SchemeID|Scheme3ID|?";
            ParamVal = ItemCode + "|" + schemeID + "|" + Scheme3ID + "|?";
            string totParameters = Common.GetParameterArguments(4);
            long isExists = objCon.ByProcedureExecScalar_LONG("{Call Schema.A_CHECK_SCHM2(" + totParameters + ")}", 4, ParamName, ParamVal);

            return isExists;

        }

        //public static int GetKey(EntityObject table, decimal parentID)
        //{
        //    int KeyID = 0;
        //    using (var ctx = new EMSEntities())
        //    {
        //        if (parentID > 0)
        //        {
        //            var dat = table.EntityKey;
        //        }
        //        else
        //        {

        //        }
        //    }
        //    return KeyID;
        //}

        //public static void AttachUpdated(ObjectContext obj, EntityObject objectDetached)
        //{
        //    if (objectDetached.EntityState == EntityState.Detached)
        //    {
        //        object original = null;
        //        if (obj.TryGetObjectByKey(objectDetached.EntityKey, out original))
        //            obj.ApplyCurrentValues(objectDetached.EntityKey.EntitySetName, objectDetached);
        //        else
        //            throw new ObjectNotFoundException();
        //    }
        //}

        public static bool IsImageValid(Stream stream)
        {
            try
            {
                var i = System.Drawing.Image.FromStream(stream);
                stream.Seek(0, SeekOrigin.Begin);
                return ImageFormat.Png.Equals(i.RawFormat)
                    || ImageFormat.Gif.Equals(i.RawFormat)
                    || ImageFormat.Jpeg.Equals(i.RawFormat)
                    || ImageFormat.Bmp.Equals(i.RawFormat);
            }
            catch
            {
                return false;
            }
        }

        public static string EncryptNumber(String Key, String Str)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(Str);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptNumber(String Key, String Str)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(Str);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        //public static List<string> GetMACAddress()
        //{
        //    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        //    List<string> sMacAddress = new List<string>();
        //    int i = 0;
        //    foreach (NetworkInterface adapter in nics)
        //    {
        //        IPInterfaceProperties properties = adapter.GetIPProperties();
        //        sMacAddress.Add(adapter.GetPhysicalAddress().ToString());

        //        i += 1;
        //    }
        //    return sMacAddress;
        //}

        [DllImport("Iphlpapi.dll")]

        public static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 MacAddr, ref Int32 PhyAddrLen);

        [DllImport("Ws2_32.dll")]
        public static extern Int32 inet_addr(string ipaddr);

        public static string GetMACAddress(string RemoteIP)
        {

            StringBuilder macAddress = new StringBuilder();

            try
            {
                Int32 remote = inet_addr(RemoteIP);
                Int64 macInfo = new Int64();
                Int32 length = 6;
                SendARP(remote, 0, ref macInfo, ref length);
                string temp = Convert.ToString(macInfo, 16).PadLeft(12, '0').ToUpper();
                int x = 12;
                for (int i = 0; i < 6; i++)
                {
                    if (i == 5)
                    {
                        macAddress.Append(temp.Substring(x - 2, 2));
                    }
                    else
                    {
                        macAddress.Append(temp.Substring(x - 2, 2) + "-");
                    }

                    x -= 2;
                }
                return macAddress.ToString();
            }
            catch
            {
                return macAddress.ToString();
            }
        }

        public static DateTime DateTimeConvert(string Date)
        {
            var temp = Date.Split("/".ToCharArray());

            int Day = Convert.ToInt32(temp[0]);
            int Month = Convert.ToInt32(temp[1]);
            int Year = Convert.ToInt32(temp[2]);

            return new DateTime(Year, Month, Day);
        }

        public static string GetParameterArguments(int no)
        {
            string str = "";
            for (int i = 0; i < no; i++)
            {
                str += "?,";
            }
            str = str.Remove(str.Length - 1, 1);
            return str;
        }

        public static string CheckAccessRights(string actionName, string controllerName)
        {
            objCon = new SQL_CONN_Class();

            string ParamName = "";
            string ParamVal = "";
            ParamName = "ControllerName|ActionName|EmpGroupID|PositionID|?";
            ParamVal = controllerName + "|" + actionName + "|" + Convert.ToString(HttpContext.Current.Session["EmpGroupID"]) + "|" + Convert.ToString(HttpContext.Current.Session["PositionID"]) + "|" + "?";

            string totParameters = Common.GetParameterArguments(5);
            string accessRight = objCon.ByProcedureExecScalarInString("{Call Schema.A_CHECK_ACTIONRIGHTS(" + totParameters + ")}", 5, ParamName, ParamVal);

            return accessRight;

        }



        //public static string GetSeriesCode(string controllerName, string actionName, string mode, int primaryKey, string UserID)
        //{
        //    using (objCon = new SQL_CONN_Class())
        //    {
        //        string ParamName = "";
        //        string ParamVal = "";
        //        int userID = Convert.ToInt32(UserID);
        //        ParamName = "ControllerName|ActionName|UserID|InsertGetFlag|tablePrimaryKey|?";
        //        ParamVal = controllerName + "|" + actionName + "|" + userID + "|" + mode + "|" + primaryKey + "|?";

        //        string totParameters = Common.GetParameterArguments(6);
        //        string seriesCode = objCon.ByProcedureExecScalarInString("{Call Schema.A_GET_INSERT_SERIESCODE(" + totParameters + ")}", 6, ParamName, ParamVal);
        //        objCon.Dispose();
        //        return seriesCode;
        //    }
        //}

        public static string GetSeriesCode_SFA(string controllerName, string actionName, string mode, int primaryKey, string UserID, string BranchID)
        {
            objCon = new SQL_CONN_Class();

            string ParamName = "";
            string ParamVal = "";
            int userID = Convert.ToInt32(UserID);
            ParamName = "ControllerName|ActionName|UserID|InsertGetFlag|tablePrimaryKey|BRANCHID|?";
            ParamVal = controllerName + "|" + actionName + "|" + userID + "|" + mode + "|" + primaryKey + "|" + BranchID + "|?";

            string totParameters = Common.GetParameterArguments(7);
            string seriesCode = objCon.ByProcedureExecScalarInString("{Call Schema.A_GET_INSERT_SERIESCODE_SFA(" + totParameters + ")}", 7, ParamName, ParamVal);
            objCon.Dispose();
            return seriesCode;

        }


        public static void SetSAPDocEntry()
        {
            if (System.Web.HttpContext.Current.Session["UserID"] != null)
            {
                objCon = new SQL_CONN_Class();
                {
                    try
                    {
                        objCon.ByProcedureExecScalar("{Call Schema.A_SET_BLANKRECORD(?)}", 1, "USERID", Convert.ToString(System.Web.HttpContext.Current.Session["UserID"]));
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        public static string SAP_DOCUMENTNUMBER(string TableName, string DocumentNo, string FieldName)
        {
            objCon = new SQL_CONN_Class();


            DataTable dt_Details = new DataTable();
            string ParamName = "";
            string ParamVal = "";
            string totParameters = "";

            ParamName = "TABLENAME|DOCUMENTNO|FIELDNAME";
            ParamVal = TableName + "|" + DocumentNo + "|" + FieldName;


            //dt_Details = objCon.ByProcedureReturnDataTable("{Call Schema.A_GET_DOCUMENT_NUMBER_WITH_SERIES(" + totParameters + ")}", 3, ParamName, ParamVal);
            dt_Details = objCon.ByProcedureReturnDataTable("A_GET_DOCUMENT_NUMBER_WITH_SERIES", 3, ParamName, ParamVal);


            return Convert.ToString(dt_Details.Rows[0]["DOCUMENTNUMBER"]);

        }

        public static void TraceLogInfo(string content)
        {


            String IntegrationErrorLogPath = AppDomain.CurrentDomain.BaseDirectory + "\\DOCUMENTS\\LOG";
            if (!Directory.Exists(IntegrationErrorLogPath))
            {
                Directory.CreateDirectory(IntegrationErrorLogPath);
            }
            string path = IntegrationErrorLogPath + "\\" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            using (StreamWriter w = File.AppendText(path))
            {
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                string err = "Error Message: " + content;
                w.WriteLine(err);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }
        }

    }
}
namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}
