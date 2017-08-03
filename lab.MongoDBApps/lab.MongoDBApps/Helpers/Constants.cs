using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.MongoDBApps.Helpers
{
    public static class Constants
    {
        public static class Messages
        {
            public const string UnhandelledError = "We are facing some problem while processing the current request. Please try again later.";
            public const string NotFound = "Requested object not found.";
            public const string SaveSuccess = "Save successfully.";
            public const string UpdateSuccess = "Update successfully.";
            public const string DeleteSuccess = "Delete successfully.";

            public static string ExceptionError(Exception exception)
            {
                return "We are facing some problem while processing the current request. Please try again later. " + exception.Message;
            }
        }
    }
}