using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace SAPWeb.App_Start
{
    public class SQL_CONN_Class
    {
        SqlConnection objConnection = new SqlConnection();
        SqlTransaction objTranscation;
        SqlDataAdapter objAdpter = new SqlDataAdapter();
        SqlCommand objCommand = new SqlCommand();
        DataSet objDataSet = null;
        DataTable objDataTable = null;
        SqlDataReader objDataReader;


        private const string _RESTAUTS = "ERROR";
        private const string _RSSTATUS = "SUCCESS";
        private string ReturnString = "";
        private int ReturnVal = 0;
        private double ReturnValDbl = 0.0;
        private long ReturnValMax = 0;
        private string ReturnValStr = "";
        string sqlString;
        bool RtnTF;
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~SQL_CONN_Class()
        {
            Dispose(false);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        #region " Begin Transaction"
        private void BeginTranscation()
        {
            objConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SAPSQLCONN"].ConnectionString);
            objCommand = new SqlCommand();
            objCommand.CommandTimeout = 1800;
            objCommand.Connection = objConnection;
            objCommand.Connection.Open();
            objTranscation = objCommand.Connection.BeginTransaction();
            objCommand.Transaction = objTranscation;
        }
        #endregion

        #region " End Transaction "
        public void EndTranscation(string Type)
        {
            try
            {
                if (objCommand.Connection.State == ConnectionState.Open)
                {
                    switch (Type)
                    {
                        case _RESTAUTS:
                            objTranscation.Rollback();
                            objCommand.Connection.Close();
                            break;
                        // break 
                        case _RSSTATUS:
                            objTranscation.Commit();
                            objCommand.Connection.Close();
                            break;
                            // break 
                    }
                }
            }
            catch (Exception Ex)
            {
            }
        }
        #endregion

        #region " By Procedure Execute  "
        public int ByProcedureExec(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;
                if (ParameterCount > 0)
                {
                    string[] ParaMeterNm = new string[ParameterCount + 1];
                    string[] ParaMeterVal = new string[ParameterCount + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    for (Pcount = 0; Pcount <= ParameterCount - 1; Pcount++)
                    {
                        objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);
                    }
                }
                ReturnVal = objCommand.ExecuteNonQuery();
                this.EndTranscation("SUCCESS");
            }
            catch (Exception Ex)
            {

                this.EndTranscation("ERROR");
                ReturnVal = 0;
            }
            return ReturnVal;
        }
        #endregion

        #region " By Procedure ExecuteScalar  "

        public string ByProcedureExecScalarInString(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;
                if (ParameterCount > 0)
                {
                    string[] ParaMeterNm = new string[ParameterCount + 1];
                    string[] ParaMeterVal = new string[ParameterCount + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    for (Pcount = 0; Pcount <= ParameterCount - 1; Pcount++)
                    {

                        objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);

                    }
                }

                ReturnValStr = Convert.ToString(objCommand.ExecuteScalar());

                this.EndTranscation("SUCCESS");
            }
            catch (Exception Ex)
            {

                this.EndTranscation("ERROR");
                ReturnValStr = "";
            }
            return ReturnValStr;
        }

        public int ByProcedureExecScalar(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;
                if (ParameterCount > 0)
                {
                    string[] ParaMeterNm = new string[ParameterCount + 1];
                    string[] ParaMeterVal = new string[ParameterCount + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    for (Pcount = 0; Pcount <= ParameterCount - 1; Pcount++)
                    {
                        objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);
                    }
                }
                ReturnVal = Convert.ToInt32(objCommand.ExecuteScalar());
                this.EndTranscation("SUCCESS");
            }
            catch (Exception Ex)
            {

                this.EndTranscation("ERROR");
                ReturnVal = 0;
            }
            return ReturnVal;
        }

        public long ByProcedureExecScalar_LONG(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;

                if (ParameterCount > 0)
                {
                    string[] ParaMeterNm = new string[ParameterCount + 1];
                    string[] ParaMeterVal = new string[ParameterCount + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    for (Pcount = 0; Pcount <= ParameterCount - 1; Pcount++)
                    {
                        objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);
                    }
                }

                ReturnValMax = Convert.ToInt64(objCommand.ExecuteScalar());

                this.EndTranscation("SUCCESS");
            }
            catch (Exception Ex)
            {

                this.EndTranscation("ERROR");
                ReturnValMax = 0;
            }
            return ReturnValMax;
        }

        public long ByProcedureExecScalar_Return(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;

                if (ParameterCount > 0)
                {
                    string[] ParaMeterNm = new string[ParameterCount + 1];
                    string[] ParaMeterVal = new string[ParameterCount + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    for (Pcount = 0; Pcount <= ParameterCount - 1; Pcount++)
                    {
                        if (ParaMeterNm[Pcount] == "RETURNID" || ParaMeterNm[Pcount] == "@RETURNID")
                        {
                            objCommand.Parameters.Add(ParaMeterNm[Pcount], SqlDbType.Int).Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);
                        }
                    }
                }

                if (objCommand.Parameters.Contains("@RETURNID"))
                {
                    objCommand.ExecuteScalar();
                    ReturnValMax = Convert.ToInt32(objCommand.Parameters["@RETURNID"].Value);
                }
                else
                {
                    ReturnValMax = Convert.ToInt64(objCommand.ExecuteScalar());
                }

                this.EndTranscation("SUCCESS");
            }
            catch (Exception Ex)
            {
                this.EndTranscation("ERROR");
                ReturnValMax = 0;
            }
            return ReturnValMax;
        }

        #endregion

        #region " By Procedure Return DataTable "
        public DataTable ByProcedureReturnDataTable(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;
                int i = ParameterCount;
                if (i > 0)
                {
                    string[] ParaMeterNm = new string[i + 1];
                    string[] ParaMeterVal = new string[i + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    for (Pcount = 0; Pcount <= i - 1; Pcount++)
                    {
                        objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);
                    }
                }
                objAdpter.SelectCommand = objCommand;
                objDataTable = new DataTable();
                objAdpter.Fill(objDataTable);
                this.EndTranscation("SUCCESS");
                return objDataTable;
            }
            catch (Exception Ex)
            {

                this.EndTranscation("ERROR");
                return null;
            }
        }

        public IEnumerable<dynamic> ByProcedureReturnDataTable_New(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            List<dynamic> result = new List<dynamic>();
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;

                int i = ParameterCount;
                if (i > 0)
                {
                    string[] ParaMeterNm = new string[i + 1];
                    string[] ParaMeterVal = new string[i + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    for (Pcount = 0; Pcount <= i - 1; Pcount++)
                    {
                        objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);
                    }
                }
                objAdpter.SelectCommand = objCommand;
                objDataTable = new DataTable();
                objAdpter.Fill(objDataTable);
                this.EndTranscation("SUCCESS");
                result.Add("Success");
                result.Add(objDataTable);

            }
            catch (Exception Ex)
            {

                this.EndTranscation("ERROR");
                result.Add("Error");
                result.Add(Ex.Message.ToString());

            }
            return result;

        }
        #endregion

        #region " BY Query Return DataTable"
        public DataTable ByQueryReturnDataTable(string SQLQuery)
        {
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.Text;
                objCommand.CommandText = SQLQuery;
                objAdpter.SelectCommand = objCommand;
                objDataTable = new DataTable();
                objAdpter.Fill(objDataTable);
                this.EndTranscation("SUCCESS");
                return objDataTable;
            }
            catch (Exception Ex)
            {
                this.EndTranscation("ERROR");
                return null;
            }
        }
        #endregion

        #region " By Procedure Return DataSet "

        public DataSet ByProcedureReturnDataSet(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;
                int i = ParameterCount;
                if (i > 0)
                {
                    string[] ParaMeterNm = new string[i + 1];
                    string[] ParaMeterVal = new string[i + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    for (Pcount = 0; Pcount <= i - 1; Pcount++)
                    {
                        objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);
                    }
                }
                objAdpter.SelectCommand = objCommand;
                objDataSet = new DataSet();
                objAdpter.Fill(objDataSet);
                this.EndTranscation("SUCCESS");
                return objDataSet;
            }
            catch (Exception Ex)
            {
                this.EndTranscation("ERROR");
                return null;
            }
        }

        public IEnumerable<dynamic> ByProcedureReturnDataSet_New(string StoreProcName, int ParameterCount = 0, string ParameterName = "", string ParameterValue = "")
        {
            List<dynamic> result = new List<dynamic>();
            try
            {
                BeginTranscation();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = StoreProcName;

                int i = ParameterCount;
                if (i > 0)
                {
                    string[] ParaMeterNm = new string[i + 1];
                    string[] ParaMeterVal = new string[i + 1];
                    int Pcount = 0;
                    ParaMeterNm = ParameterName.Split(new string[] { "|" }, StringSplitOptions.None);
                    ParaMeterVal = ParameterValue.Split(new string[] { "|" }, StringSplitOptions.None);
                    for (Pcount = 0; Pcount <= i - 1; Pcount++)
                    {
                        objCommand.Parameters.AddWithValue(ParaMeterNm[Pcount], ParaMeterVal[Pcount]);
                    }
                }
                objAdpter.SelectCommand = objCommand;
                objDataSet = new DataSet();
                objAdpter.Fill(objDataSet);
                this.EndTranscation("SUCCESS");
                result.Add("Success");
                result.Add(objDataSet);

            }
            catch (Exception Ex)
            {

                this.EndTranscation("ERROR");
                result.Add("Error");
                result.Add(Ex.Message.ToString());

            }
            return result;

        }
        #endregion

    }
}