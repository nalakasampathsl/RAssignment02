using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RA02.Helpers
{
    public static class Extentions
    {
        /// <summary>
        /// Add Application errors the the headers
        /// </summary>
        /// <param name="response"></param>
        /// <param name="message"></param>
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
