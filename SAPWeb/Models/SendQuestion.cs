using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    public class GETTYPE
    {
        public string SchemaName { get; set; }
        public string TYP_ID { get; set; }
        
    }

    public class QuestionListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }
    public class ParamQuestionList
    {
        public string SchemaName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }
        public string EMPID { get; set; }
    }
    public class SendQuestion
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<GetQuestion> GETQUESTION { get; set; }
    }
    public class GetQuestion
    {
        public string QuestionID { get; set; }
        public string Question { get; set; }
        public string QuestionTypeID { get; set; }
        public string QuestionType { get; set; }
        public string QuestionCategoryID { get; set; }
        public string QuestionCategory { get; set; }
        public string QuestionSubCategoryID { get; set; }
        public string QuestionSubCategory { get; set; }
        public string OptionsCount { get; set; }
        public string Options { get; set; }
        public string OptionsInputType { get; set; }
        public string Compulsory { get; set; }
        public string MinLength { get; set; }
        public string MaxLength { get; set; }
        public string Hint { get; set; }

    }
    public class QUESTIONPARAMETER
    {
        public string EMPID { get; set; }
    }

    public class QuestionMasterDefaultSave
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class A_OQUECollection
    {
        public A_OQUECollection()
        {
            A_QUE1Collection = new List<A_QUE1Collection>();
        }

        public string SchemaName { get; set; }
        public string U_EMPID { get; set; }

        public int? DocEntry { get; set; }

        public string U_QUESTION { get; set; }
        public string U_GUID { get; set; }
        public string U_TYPE { get; set; }
        public string U_CATEGORY { get; set; }
        public string U_SUBCATEGORY { get; set; }
        public string U_DESCRIPTION_TYPE { get; set; }
        public string U_MINLENGTH { get; set; }
        public string U_MAXLENGTH { get; set; }
        public string U_ANS_HINT { get; set; }
        public string U_MACADDRESS { get; set; }
        public string U_ISMANDATORY { get; set; }
        public int? U_OPTION_COUNT { get; set; }
        public string U_REMARKS { get; set; }
        public string U_ISACTIVE { get; set; }

        public string U_CREATEDBY { get; set; }
        public DateTime? U_CREATEDDATE { get; set; }
        public string U_UPDATEDBY { get; set; }
        public DateTime? U_UPDATEDDATE { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }

        public List<A_QUE1Collection> A_QUE1Collection { get; set; }
    }

    public class A_QUE1Collection
    {
        public int? LineId { get; set; }
        public string U_ANSWER { get; set; }
        public string U_SCORE { get; set; }
    }

    public class ParameterForQuestionByQuestionID
    {
        public string SchemaName { get; set; }
        public int? QID { get; set; }
    }
}