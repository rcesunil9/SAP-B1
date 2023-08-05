using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    public class Message
    {
        public string lang { get; set; }
        public string value { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public Message message { get; set; }
    }

    public class ErrorObject
    {
        public Error error { get; set; }
    }
}