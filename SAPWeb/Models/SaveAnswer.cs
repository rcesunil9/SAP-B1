using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    public class AnswerDefaultSave
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }

    }
    public class A_OANSList
    {
        public List<A_OANS> SAVE_QUESTION_ANSWER { get; set; }
    }
    public class A_OANS
    {
        public string SchemaName { get; set; }
        public string QID { get; set; }
        public string EMPID { get; set; }
        public string CUSTOMEREMPLOYEECODE { get; set; }
        public string COMPETITORCODE { get; set; }
        public string EMPCODE { get; set; }
        public string REMARKS { get; set; }
        public string TYPE { get; set; }
        public string ANSWER { get; set; }
        public string ANSTYPE { get; set; }
        public string SYSTEMID { get; set; }

    }

    public class A_OANSCollection
    {
        public A_OANSCollection()
        {
            A_ANS1Collection = new List<A_ANS1Collection>();
            A_ANS3Collection = new List<A_ANS3Collection>();
        }

        public string SchemaName { get; set; }

        public string U_GUID { get; set; }
        public string U_QID { get; set; }
        public string U_CUSTOMEREMPLOYEECODE { get; set; }
        public string U_TYPE { get; set; }
        public string U_COMPETITORCODE { get; set; }
        public string U_EMPCODE { get; set; }
        public string U_REMARKS { get; set; }

        public string U_CREATEDBY { get; set; }
        public string U_UPDATEDBY { get; set; }
        public DateTime? U_CREATEDDATE { get; set; }
        public DateTime? U_UPDATEDDATE { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }

        public List<A_ANS1Collection> A_ANS1Collection { get; set; }
        public List<A_ANS3Collection> A_ANS3Collection { get; set; }
    }

    public class A_ANS1Collection
    {
        public string U_QID { get; set; }
        public string U_Q1ID { get; set; }
        public string U_TEXTANS { get; set; }
    }

    public class A_ANS3Collection
    {
        public string U_QID { get; set; }
        public string U_IMAGENAME { get; set; }
    }
}