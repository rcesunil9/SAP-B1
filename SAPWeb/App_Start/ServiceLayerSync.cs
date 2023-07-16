using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Linq;
using System.Data;
using SAPWeb.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace SAPWeb.App_Start
{
    public class ServiceLayerSync
    {
        private string userData = string.Empty;
        private string url = Convert.ToString(ConfigurationManager.AppSettings["ServiceLayerURL"]);
        private static CookieCollection CookieData = new CookieCollection();
        private static DateTime? CheckTime;
        private static DateTime? CheckTimeSAPB1AddOn;
        private static string SchemaNameSAPB1AddOn;

        public class UserData
        {
            public string CompanyDB { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        private static bool RemoteSSLTLSCertificateValidate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        #region Login

        public Dictionary<int, string> SAPLoginB1AddOn(string SchemaName)
        {
            //if (CheckTimeSAPB1AddOn != null && !String.IsNullOrEmpty(SchemaNameSAPB1AddOn))
            //{
            //    if ((DateTime.Now - Convert.ToDateTime(CheckTimeSAPB1AddOn)).TotalMinutes <= 25 && SchemaNameSAPB1AddOn == SchemaName)
            //    {
            //        var data = new Dictionary<int, string>();
            //        data.Add(1, "Success");
            //        return data;
            //    }
            //}

            UserData Data = new UserData();
            Data.CompanyDB = SchemaName;
            Data.UserName = Convert.ToString(ConfigurationManager.AppSettings["SAPUserName"]);
            Data.Password = Convert.ToString(ConfigurationManager.AppSettings["SAPPassword"]);

            var result = this.Interact((url + "Login"), "POST", JsonConvert.SerializeObject(Data), true);
            if (result.FirstOrDefault().Key == 1)
            {
                CheckTimeSAPB1AddOn = DateTime.Now;
                SchemaNameSAPB1AddOn = SchemaName;
            }
            else
            {
                CheckTimeSAPB1AddOn = null;
                SchemaNameSAPB1AddOn = null;
            }
            return result;

        }

        public Dictionary<int, string> SAPLogin()
        {
            //if (CheckTime != null)
            //{
            //    if ((DateTime.Now - Convert.ToDateTime(CheckTime)).TotalMinutes <= 25)
            //    {
            //        var data = new Dictionary<int, string>();
            //        data.Add(1, "Success");
            //        return data;
            //    }
            //}

            UserData Data = new UserData();
            string connectString = ConfigurationManager.ConnectionStrings["SAPSQLCONN"].ToString();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);
            // Retrieve the DataSource property.    
            string DBName = builder.InitialCatalog;

            Data.CompanyDB = DBName;
            Data.UserName = Convert.ToString(ConfigurationManager.AppSettings["SAPUserName"]);
            Data.Password = Convert.ToString(ConfigurationManager.AppSettings["SAPPassword"]);

            var result = this.Interact((url + "Login"), "POST", JsonConvert.SerializeObject(Data), true);
            if (result.FirstOrDefault().Key == 1)
            {
                CheckTime = DateTime.Now;
            }
            else
            {
                CheckTime = null;
            }
            return result;

        }

        public Dictionary<int, string> SAPLogout()
        {
            var result = this.Interact((url + "Logout"), "POST");
            return result;
        }

        #endregion

        #region Documents

        public Documents SAPGetDocument(int DocEntry, string Document)
        {
            Documents Data = new Documents();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + Document + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<Documents>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPGetDocument1(int DocEntry, string Document, string SchemaName)
        {
            var result = this.Interact((url + Document + "(" + DocEntry + ")"), "GET");
            return result;
        }

        #endregion

        #region Drafts

        public Dictionary<int, string> SAPAddToDrafts(string Data)
        {
            var result = this.Interact((url + "Drafts"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToDrafts(string Data, int DocEntry)
        {
            var result = this.Interact((url + "Drafts(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPCancelToDrafts(int DocEntry)
        {
            var result = this.Interact((url + "Drafts(" + DocEntry + ")" + "/Cancel"), "POST");
            return result;
        }

        public Dictionary<int, string> SAPRemoveToDrafts(int DocEntry)
        {
            var result = this.Interact((url + "Drafts(" + DocEntry + ")"), "DELETE");
            return result;
        }

        public Dictionary<int, string> SAPAddToDraftsDetails(string Data)
        {
            var result = this.Interact((url + "A_ODRF"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToDraftsDetails(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_ODRF(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public A_ODRFDocuments SAPGetDraftsDetailsDocument(int DocEntry, string Document)
        {
            A_ODRFDocuments Data = new A_ODRFDocuments();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + Document + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_ODRFDocuments>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        #endregion

        #region SalesOpportunities

        public SAPSalesOpportunity SAPGetSalesOpportunities(int DocEntry)
        {
            SAPSalesOpportunity Data = new SAPSalesOpportunity();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "SalesOpportunities(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<SAPSalesOpportunity>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesOpportunities(string Data)
        {
            var result = this.Interact((url + "SalesOpportunities"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesOpportunities(string Data, int DocEntry)
        {
            var result = this.Interact((url + "SalesOpportunities(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPAddToSalesOpportunitiesItems(string Data)
        {
            var result = this.Interact((url + "A_OOPR"), "POST", Data);
            return result;
        }
        public Dictionary<int, string> SAPUpdateToSalesOpportunitiesItems(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OOPR(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region SalesQuotations

        public Documents SAPGetSalesQuotations(int DocEntry)
        {
            Documents Data = new Documents();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "Quotations" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<Documents>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesQuotations(string Data)
        {
            var result = this.Interact((url + "Quotations"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesQuotations(string Data, int DocEntry)
        {
            var result = this.Interact_Update((url + "Quotations(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesQuotations_Transfer(string Data, int DocEntry)
        {
            var result = this.Interact((url + "Quotations(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPCloseToSalesQuotations(int DocEntry)
        {
            var result = this.Interact((url + "Quotations(" + DocEntry + ")" + "/Close"), "POST");
            return result;
        }

        public Dictionary<int, string> SAPCancelToSalesQuotations(int DocEntry)
        {
            var result = this.Interact((url + "Quotations(" + DocEntry + ")" + "/Cancel"), "POST");
            return result;
        }

        public A_OQUTDocuments SAPGetSalesQuotationsAdditional(int DocEntry)
        {
            A_OQUTDocuments Data = new A_OQUTDocuments();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OQUT" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OQUTDocuments>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesQuotationsAdditional(string Data)
        {
            var result = this.Interact((url + "A_OQUT"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesQuotationsAdditional(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OQUT(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region SalesDeliveryNotes

        public Documents SAPGetSalesDeliveryNotes(int DocEntry)
        {
            Documents Data = new Documents();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "DeliveryNotes" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<Documents>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesDeliveryNotes(string Data)
        {
            var result = this.Interact((url + "DeliveryNotes"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesDeliveryNotes(string Data, int DocEntry)
        {
            var result = this.Interact_Update((url + "DeliveryNotes(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPCloseToSalesDeliveryNotes(int DocEntry)
        {
            var result = this.Interact((url + "DeliveryNotes(" + DocEntry + ")" + "/Close"), "POST");
            return result;
        }

        public Dictionary<int, string> SAPCancelToSalesDeliveryNotes(int DocEntry)
        {
            var result = this.Interact((url + "DeliveryNotes(" + DocEntry + ")" + "/Cancel"), "POST");
            return result;
        }

        public A_ODLNDocuments SAPGetSalesDeliveryNotesAdditional(int DocEntry)
        {
            A_ODLNDocuments Data = new A_ODLNDocuments();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_ODLN" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_ODLNDocuments>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesDeliveryNotesAdditional(string Data)
        {
            var result = this.Interact((url + "A_ODLN"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesDeliveryNotesAdditional(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_ODLN(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region SalesInvoices

        public Documents SAPGetSalesInvoices(int DocEntry)
        {
            Documents Data = new Documents();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "Invoices" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<Documents>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesInvoices(string Data)
        {
            var result = this.Interact((url + "Invoices"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesInvoices(string Data, int DocEntry)
        {
            var result = this.Interact_Update((url + "Invoices(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPCloseToSalesInvoices(int DocEntry)
        {
            var result = this.Interact((url + "Invoices(" + DocEntry + ")" + "/Close"), "POST");
            return result;
        }

        public Dictionary<int, string> SAPCancelToSalesInvoices(int DocEntry)
        {
            var result = this.Interact((url + "Invoices(" + DocEntry + ")" + "/Cancel"), "POST");
            return result;
        }

        public A_OINVDocuments SAPGetSalesInvoicesAdditional(int DocEntry)
        {
            A_OINVDocuments Data = new A_OINVDocuments();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OINV" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OINVDocuments>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesInvoicesAdditional(string Data)
        {
            var result = this.Interact((url + "A_OINV"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesInvoicesAdditional(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OINV(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region BusinessPartners
        public Dictionary<int, string> SAPAddToBusinessPartners(string Data)
        {
            var result = this.Interact((url + "BusinessPartners"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToBusinessPartners(string Data, string CardCode)
        {
            var result = this.Interact((url + "BusinessPartners('" + CardCode + "')"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPGetBusinessPartners(string CardCode)
        {
            var result = this.Interact((url + "BusinessPartners('" + CardCode + "')"), "GET", "");
            return result;
        }

        public BusinessPartners SAPGetBusinessPartnersAll(string CardCode, string SchemaName)
        {
            BusinessPartners Data = new BusinessPartners();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "BusinessPartners" + "('" + CardCode + "')"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<BusinessPartners>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToBusinessPartnersBankInformation(string Data)
        {
            var result = this.Interact((url + "A_OCRD"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToBusinessPartnersBankInformation(string Data, string CardCode)
        {
            var result = this.Interact((url + "A_OCRD('" + CardCode + "')"), "PATCH", Data);
            return result;
        }

        #endregion

        #region Attandence
        public Dictionary<int, string> SAPAddToAttendence(string Data)
        {
            var result = this.Interact((url + "Attendence"), "POST", Data);
            return result;
        }
        public Dictionary<int, string> SAPUpdateToAttendence(string Data, int DocEntry)
        {
            var result = this.Interact((url + "Attendence(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }
        #endregion

        #region Activity
        public Dictionary<int, string> SAPAddToActivity(string Data)
        {
            var result = this.Interact((url + "Activities"), "POST", Data);

            return result;
        }

        public Dictionary<int, string> SAPUpdateToActivity(string Data, int ActivityCode)
        {
            var result = this.Interact((url + "Activities(" + ActivityCode + ")"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPGetActivities(string id)
        {
            var result = this.Interact((url + "Activities(" + id + ")"), "GET", "");
            return result;
        }

        public Activities SAPGetActivitiesData(string id)
        {
            Activities Data = new Activities();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "Activities(" + id + ")"), "GET", "");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<Activities>(result.FirstOrDefault().Value);
                }
            }
            return Data;

        }

        #endregion

        #region SalesOrders

        public Documents SAPGetSalesOrders(int DocEntry, string SchemaName)
        {
            Documents Data = new Documents();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "Orders" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<Documents>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesOrders(string Data)
        {
            var result = this.Interact((url + "Orders"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesOrders(string Data, int DocEntry)
        {
            var result = this.Interact((url + "Orders(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public Dictionary<int, string> SAPCloseToSalesOrders(int DocEntry)
        {
            var result = this.Interact((url + "Orders(" + DocEntry + ")" + "/Close"), "POST");
            return result;
        }

        public Dictionary<int, string> SAPCancelToSalesOrders(int DocEntry)
        {
            var result = this.Interact((url + "Orders(" + DocEntry + ")" + "/Cancel"), "POST");
            return result;
        }

        public Dictionary<int, string> SAPAddToSalesOrdersAdditional(string Data)
        {
            var result = this.Interact((url + "A_ORDR"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesOrdersAdditional(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_ORDR(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region Attachments

        public Dictionary<int, string> SAPGetAttachment(string id)
        {
            var result = this.Interact((url + "Attachments2(" + id + ")"), "GET", "");
            return result;
        }

        public Dictionary<int, string> SAPAddAttachments(string Data)
        {
            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact_Attchtment((url + "Attachments2"), "POST", Data);
                return result;
            }
            else
            {
                var result = new Dictionary<int, string>();
                result.Add(2, Login.FirstOrDefault().Value);
                return result;
            }
        }


        public Dictionary<int, string> Interact_Attchtment(string url, string method, string body = "", bool saveCookie = false)
        {
            var result = new Dictionary<int, string>();
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = method.ToUpper();
            httpRequest.ContentType = "multipart/mixed";
            httpRequest.ServicePoint.Expect100Continue = false;

            ServicePointManager.ServerCertificateValidationCallback += RemoteSSLTLSCertificateValidate;
            httpRequest.CookieContainer = new CookieContainer();

            if (CookieData.Count > 0)
            {
                foreach (Cookie cookie in CookieData)
                {
                    httpRequest.CookieContainer.Add(new Uri(url), new Cookie(cookie.Name, cookie.Value));
                }
            }

            if (!string.IsNullOrEmpty(body))
            {
                using (var requestStream = httpRequest.GetRequestStream())
                {
                    var writer = new StreamWriter(requestStream);
                    writer.Write(body);
                    writer.Close();
                }
            }

            try
            {
                var WebResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var response = new StreamReader(WebResponse.GetResponseStream()))
                {
                    result.Add(1, response.ReadToEnd());
                }
                if (saveCookie)
                    CookieData = WebResponse.Cookies;

            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    result.Add(2, reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                result.Add(3, ex.ToString());
            }

            return result;
        }

        #endregion

        #region CustomerComplain

        public Dictionary<int, string> SAPAddToCustomerComplain(string Data)
        {
            var result = this.Interact((url + "A_OCCM"), "POST", Data);

            return result;
        }

        #endregion

        #region ServiceCall

        public ServiceCall SAPGetServiceCalls(int ServiceCallID, string SchemaName)
        {
            ServiceCall Data = new ServiceCall();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "ServiceCalls(" + ServiceCallID + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<ServiceCall>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToServiceCalls(string Data)
        {
            var result = this.Interact((url + "ServiceCalls"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToServiceCalls(string Data, int ServiceCallID)
        {
            var result = this.Interact((url + "ServiceCalls(" + ServiceCallID + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region PrincipalSPR

        public A_OSPRCollection SAPGetPrincipalSPR(int DocEntry, string SchemaName)
        {
            A_OSPRCollection Data = new A_OSPRCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OSPR" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OSPRCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToPrincipalSPR(string Data)
        {
            var result = this.Interact((url + "A_OSPR"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToPrincipalSPR(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OSPR(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region SalesProjection

        public A_OPRJCollection SAPGetSalesProjection(int DocEntry, string SchemaName)
        {
            A_OPRJCollection Data = new A_OPRJCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OPRJ" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OPRJCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesProjection(string Data)
        {
            var result = this.Interact((url + "A_OPRJ"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesProjection(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OPRJ(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public SalesForecast SAPGetSalesForecast(int DocEntry, string SchemaName)
        {
            SalesForecast Data = new SalesForecast();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "SalesForecast" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<SalesForecast>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToSalesForecast(string Data)
        {
            var result = this.Interact((url + "SalesForecast"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToSalesForecast(string Data, int DocEntry)
        {
            var result = this.Interact((url + "SalesForecast(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region GoodsReceipt

        public Dictionary<int, string> SAPAddToInventoryGenEntries(string Data)
        {
            var result = this.Interact((url + "InventoryGenEntries"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToInventoryGenEntries(string Data, int DocEntry)
        {
            var result = this.Interact((url + "InventoryGenEntries(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region GoodsIssue

        public Dictionary<int, string> SAPAddToInventoryGenExits(string Data)
        {
            var result = this.Interact((url + "InventoryGenExits"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToInventoryGenExits(string Data, int DocEntry)
        {
            var result = this.Interact((url + "InventoryGenExits(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region InventoryTransfer

        public Dictionary<int, string> SAPAddToStockTransfers(string Data)
        {
            var result = this.Interact((url + "StockTransfers"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToStockTransfers(string Data, int DocEntry)
        {
            var result = this.Interact((url + "StockTransfers(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        public InwardOutwardDocuments SAPGetStockTransfers(int DocEntry, string SchemaName)
        {
            InwardOutwardDocuments Data = new InwardOutwardDocuments();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "StockTransfers" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<InwardOutwardDocuments>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        #endregion

        #region InwardEntries

        public A_OINDCollection SAPGetInwardEntries(int DocEntry, string SchemaName)
        {
            A_OINDCollection Data = new A_OINDCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OIND" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OINDCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToInwardEntries(string Data)
        {
            var result = this.Interact((url + "A_OIND"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToInwardEntries(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OIND(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region OutwardEntries

        public A_OOTDCollection SAPGetOutwardEntries(int DocEntry, string SchemaName)
        {
            A_OOTDCollection Data = new A_OOTDCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OOTD" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OOTDCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToOutwardEntries(string Data)
        {
            var result = this.Interact((url + "A_OOTD"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToOutwardEntries(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OOTD(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region RepairEntry

        public RepairEntry SAPGetRepairEntry(int DocEntry, string SchemaName)
        {
            RepairEntry Data = new RepairEntry();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_ORPE" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<RepairEntry>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToRepairEntry(string Data)
        {
            var result = this.Interact((url + "A_ORPE"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToRepairEntry(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_ORPE(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }

        #endregion

        #region HRMSTravel

        public A_OTRVCollection SAPGetHRMSTravel(int DocEntry, string SchemaName)
        {
            A_OTRVCollection Data = new A_OTRVCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OTRV" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OTRVCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToHRMSTravel(string Data)
        {
            var result = this.Interact((url + "A_OTRV"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToHRMSTravel(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OTRV(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }


        #endregion

        #region HRMSExpense

        public A_OEXPCollection SAPGetHRMSExpense(int DocEntry, string SchemaName)
        {
            A_OEXPCollection Data = new A_OEXPCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OEXP" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OEXPCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToHRMSExpense(string Data)
        {
            var result = this.Interact((url + "A_OEXP"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToHRMSExpense(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OEXP(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }


        #endregion

        #region HRMSLeaveBalance

        public A_LEVBCollection SAPGetHRMSLeaveBalance(int DocEntry, string SchemaName)
        {
            A_LEVBCollection Data = new A_LEVBCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_LEVB" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_LEVBCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToHRMSLeaveBalance(string Data)
        {
            var result = this.Interact((url + "A_LEVB"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToHRMSLeaveBalance(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_LEVB(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }


        #endregion

        #region HRMSLeave

        public A_LEVRCollection SAPGetHRMSLeave(int DocEntry, string SchemaName)
        {
            A_LEVRCollection Data = new A_LEVRCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_LEVR" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_LEVRCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToHRMSLeave(string Data)
        {
            var result = this.Interact((url + "A_LEVR"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToHRMSLeave(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_LEVR(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }


        #endregion

        #region QuestionMaster

        public A_OQUECollection SAPGetQuestionMaster(int DocEntry, string SchemaName)
        {
            A_OQUECollection Data = new A_OQUECollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OQUE" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OQUECollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToQuestionMaster(string Data)
        {
            var result = this.Interact((url + "A_OQUE"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToQuestionMaster(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OQUE(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }


        #endregion

        #region Answer

        public A_OANSCollection SAPGetAnswer(int DocEntry, string SchemaName)
        {
            A_OANSCollection Data = new A_OANSCollection();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OANS" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OANSCollection>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToAnswer(string Data)
        {
            var result = this.Interact((url + "A_OANS"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToAnswer(string Data, int DocEntry)
        {
            var result = this.Interact((url + "A_OANS(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }


        #endregion

        #region EmployeesInfo

        public EmployeesInfo SAPGetEmployeesInfo(int DocEntry, string SchemaName)
        {
            EmployeesInfo Data = new EmployeesInfo();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "EmployeesInfo" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<EmployeesInfo>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToEmployeesInfo(string Data)
        {
            var result = this.Interact((url + "EmployeesInfo"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToEmployeesInfo(string Data, int DocEntry)
        {
            var result = this.Interact((url + "EmployeesInfo(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }


        #endregion

        #region ItemMaster

        public Dictionary<int, string> SAPAddToItems(string Data)
        {
            var result = this.Interact((url + "Items"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToItems(string Data, string ItemCode)
        {
            var result = this.Interact((url + "Items('" + ItemCode + "')"), "PATCH", Data);
            return result;
        }

        public ItemMaster SAPGetItemMasterAll(string ItemCode, string SchemaName)
        {
            ItemMaster Data = new ItemMaster();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "Items" + "('" + ItemCode + "')"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<ItemMaster>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        public Dictionary<int, string> SAPAddToItemsTemp(string Data)
        {
            var result = this.Interact((url + "A_OITM"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToItemsTemp(string Data, string Code)
        {
            var result = this.Interact((url + "A_OITM('" + Code + "')"), "PATCH", Data);
            return result;
        }

        public A_OITM SAPGetItemMasterAllTemp(string ItemCode, string SchemaName)
        {
            A_OITM Data = new A_OITM();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OITM" + "('" + ItemCode + "')"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<A_OITM>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }

        #endregion

        #region Interact

        public Dictionary<int, string> Interact(string url, string method, string body = "", bool saveCookie = false)
        {
            var result = new Dictionary<int, string>();
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = method.ToUpper();
            httpRequest.ServicePoint.Expect100Continue = false;

            //    httpRequest.Headers.Add("B1S-ReplaceCollectionsOnPatch:true");

            ServicePointManager.ServerCertificateValidationCallback += RemoteSSLTLSCertificateValidate;
            httpRequest.CookieContainer = new CookieContainer();

            if (CookieData.Count > 0)
            {
                foreach (Cookie cookie in CookieData)
                {
                    httpRequest.CookieContainer.Add(new Uri(url), new Cookie(cookie.Name, cookie.Value));
                }
            }

            if (!string.IsNullOrEmpty(body))
            {
                using (var requestStream = httpRequest.GetRequestStream())
                {
                    var writer = new StreamWriter(requestStream);
                    writer.Write(body);
                    writer.Close();
                }
            }

            try
            {
                var WebResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var response = new StreamReader(WebResponse.GetResponseStream()))
                {
                    result.Add(1, response.ReadToEnd());
                }
                if (saveCookie)
                    CookieData = WebResponse.Cookies;

            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    result.Add(2, reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                result.Add(3, ex.ToString());
            }

            return result;
        }

        public Dictionary<int, string> Interact_Update(string url, string method, string body = "", bool saveCookie = false)
        {
            var result = new Dictionary<int, string>();
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = method.ToUpper();
            httpRequest.ServicePoint.Expect100Continue = false;

            httpRequest.Headers.Add("B1S-ReplaceCollectionsOnPatch:true");

            ServicePointManager.ServerCertificateValidationCallback += RemoteSSLTLSCertificateValidate;
            httpRequest.CookieContainer = new CookieContainer();

            if (CookieData.Count > 0)
            {
                foreach (Cookie cookie in CookieData)
                {
                    httpRequest.CookieContainer.Add(new Uri(url), new Cookie(cookie.Name, cookie.Value));
                }
            }

            if (!string.IsNullOrEmpty(body))
            {
                using (var requestStream = httpRequest.GetRequestStream())
                {
                    var writer = new StreamWriter(requestStream);
                    writer.Write(body);
                    writer.Close();
                }
            }

            try
            {
                var WebResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var response = new StreamReader(WebResponse.GetResponseStream()))
                {
                    result.Add(1, response.ReadToEnd());
                }
                if (saveCookie)
                    CookieData = WebResponse.Cookies;

            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    result.Add(2, reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                result.Add(3, ex.ToString());
            }

            return result;
        }

        #endregion

        #region Leave Request
        public Dictionary<int, string> SAPAddToLeaveRequest(string Data)
        {
            var result = this.Interact((url + "LeaveRequest"), "POST", Data);
            return result;
        }

        #endregion

        #region Production
        public Dictionary<int, string> SAPAddToProductionOrder(string Data)
        {
            var result = this.Interact((url + "A_OPRD"), "POST", Data);
            return result;
        }

        public Dictionary<int, string> SAPUpdateToProductionOrder(string Data, int DocEntry)
        {
            var result = this.Interact_Update((url + "A_OPRD(" + DocEntry + ")"), "PATCH", Data);
            return result;
        }
        public Documents SAPGetProductionOrder(int DocEntry)
        {
            Documents Data = new Documents();

            var Login = SAPLogin();
            if (Login.FirstOrDefault().Key == 1)
            {
                var result = this.Interact((url + "A_OPRD" + "(" + DocEntry + ")"), "GET");
                if (result.FirstOrDefault().Key == 1)
                {
                    Data = JsonConvert.DeserializeObject<Documents>(result.FirstOrDefault().Value);
                }
            }
            return Data;
        }
        #endregion

        //#region SAP B1 Item PriceList Update

        //public Dictionary<int, string> SAPUpdateToItems(string Data, string ItemCode)
        //{
        //    var result = this.Interact((url + "Items('" + ItemCode + "')"), "PATCH", Data);
        //    return result;
        //}

        //#endregion

        #region GoodIssue
        public Dictionary<int, string> SAPAddToInventoryGenExit(string Data)
        {
            Common.TraceLogInfo("digvijat post" + (url + "InventoryGenExits"));
            var result = this.Interact((url + "InventoryGenExits"), "POST", Data);
            return result;
        }
        #endregion

        #region GoodReceipt
        public Dictionary<int, string> SAPAddToGoodsReceipt(string Data)
        {
            var result = this.Interact((url + "InventoryGenEntries"), "POST", Data);
            return result;
        }
        #endregion
    }
}