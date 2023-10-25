using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SAPWeb.Utility
{
    public class ReportUtility
    {
        public static ReportDocumentsDefault GetReport(ReportRequest reportRequest)
        {
            ReportDocumentsDefault response = new ReportDocumentsDefault();
            response.errorMsg = string.Empty;
            response.errorCode = "1";
            try
            {
                ReportDocument oReportDocument = new ReportDocument();
                var path = HttpContext.Current.Server.MapPath("~/Report/" + reportRequest.ReportName + ".rpt");
                oReportDocument.Load(path);
                //oReportDocument.Refresh();
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
                crParameterFieldDefinitions = oReportDocument.DataDefinition.ParameterFields;
                foreach (ParameterFieldDefinition oParameterFieldDefinition in crParameterFieldDefinitions)
                {
                    if (oParameterFieldDefinition.ReportName != string.Empty)
                    {
                        continue;
                    }
                    string value = GetParameterValue(reportRequest, oParameterFieldDefinition.ParameterFieldName);
                    if (string.IsNullOrEmpty(value))
                    {
                        switch (oParameterFieldDefinition.ValueType)
                        {
                            case FieldValueType.NumberField:
                            case FieldValueType.CurrencyField:
                                value = "0";
                                break;
                            case FieldValueType.BooleanField:
                                value = "false";
                                break;
                            case FieldValueType.DateField:
                            case FieldValueType.DateTimeField:
                            case FieldValueType.TimeField:
                                value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                break;
                        }
                    }
                    if (!oParameterFieldDefinition.EnableAllowMultipleValue)
                    {
                        crParameterDiscreteValue = new ParameterDiscreteValue();
                        crParameterDiscreteValue.Value = value;
                        crParameterValues = oParameterFieldDefinition.CurrentValues;

                        crParameterValues.Clear();
                        crParameterValues.Add(crParameterDiscreteValue);
                        oParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                    }
                    else
                    {
                        crParameterValues.Clear();
                        if (value.IndexOf(',') == -1)
                        {
                            crParameterDiscreteValue = new ParameterDiscreteValue();
                            crParameterDiscreteValue.Value = value;
                            crParameterValues = oParameterFieldDefinition.CurrentValues;

                            crParameterValues.Add(crParameterDiscreteValue);
                            oParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                        }
                        else
                        {
                            foreach (string str in value.Split(','))
                            {
                                crParameterDiscreteValue = new ParameterDiscreteValue();
                                crParameterDiscreteValue.Value = str;
                                crParameterValues = oParameterFieldDefinition.CurrentValues;

                                crParameterValues.Add(crParameterDiscreteValue);
                            }
                            oParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
                        }
                    }
                }
                /*string serverName = ConfigurationManager.AppSettings["ServerName"].ToString();
                string dbName = ConfigurationManager.AppSettings["DatabaseName"].ToString();
                string username = ConfigurationManager.AppSettings["UserName"].ToString();
                string password = ConfigurationManager.AppSettings["Password"].ToString();
                if (oReportDocument.DataSourceConnections.Count > decimal.Zero)
                {
                    oReportDocument.DataSourceConnections[0].SetConnection(serverName, dbName, username, password);
                }
                for (int i = 0; i <= oReportDocument.Subreports.Count - 1; i++)
                {
                    oReportDocument.Subreports[i].DataSourceConnections[0].SetConnection(serverName, dbName, username, password);
                }*/
                string connectionString = ConfigurationManager.ConnectionStrings["SAPSQLCONN"].ConnectionString;
                var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);

                string serverName = builder["Server"].ToString();
                string dbName = builder["Database"].ToString();
                string username = builder["User"].ToString();
                string password = builder["Password"].ToString();
                if (oReportDocument.DataSourceConnections.Count > decimal.Zero)
                {
                    oReportDocument.DataSourceConnections[0].SetConnection(serverName, dbName, username, password);
                    //oReportDocument.DataSourceConnections[0].SetConnection(connectionString, "", "", "");
                }
                for (int i = 0; i <= oReportDocument.Subreports.Count - 1; i++)
                {
                    oReportDocument.DataSourceConnections[0].SetConnection(serverName, dbName, username, password);
                    //oReportDocument.Subreports[i].DataSourceConnections[0].SetConnection(connectionString, "", "", "");
                }
                string exportPath = HttpContext.Current.Server.MapPath("~/Report/temp");
                if (!Directory.Exists(exportPath))
                {
                    Directory.CreateDirectory(exportPath);
                }
                string exportFileName = reportRequest.DocKey + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".pdf";
                exportPath = Path.Combine(exportPath, exportFileName);
                oReportDocument.ExportToDisk(ExportFormatType.PortableDocFormat, exportPath);
                response.path = HttpContext.Current.Request.Url.OriginalString.Replace(HttpContext.Current.Request.Url.PathAndQuery, "/Report/temp/" + exportFileName);
                response.fileName = exportFileName;
            }
            catch (Exception ex)
            {
            }
            return response;
        }
        private static string GetParameterValue(ReportRequest oReportParameterList, string fieldName)
        {
            string value = string.Empty;
            try
            {
                fieldName = fieldName.Replace("@", "");
                Type obj = oReportParameterList.GetType();
                if (obj != null)
                {
                    PropertyInfo[] oPropertyInfos = obj.GetProperties();
                    PropertyInfo oPropertyInfo = oPropertyInfos.AsEnumerable().Where(p => p.Name.ToUpper() == fieldName.ToUpper()).FirstOrDefault();
                    if (oPropertyInfo != null)
                    {
                        object propertyValue = oPropertyInfo.GetValue(oReportParameterList);
                        if (propertyValue != null)
                        {
                            value = Convert.ToString(propertyValue);
                            return value;
                        }
                    }
                }
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class ReportRequest
    {
        public string ReportName { get; set; }
        public string DocKey { get; set; }
        public string ObjectId { get; set; }
    }
    public class ReportDocumentsDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public string path { get; set; }
        public string fileName { get; set; }
    }
}