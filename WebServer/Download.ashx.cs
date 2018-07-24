using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;

namespace WebServer
{
    /// <summary>
    /// Summary description for Download
    /// </summary>
    public class Download : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            string fileName = "Software Requirements 3, 3rd Edition.pdf";
            string filePath = context.Server.MapPath("~/Storage/");
            FileInfo file = new FileInfo(filePath + fileName);
            System.Diagnostics.Debug.WriteLine(file.Length);
            long length = file.Length/*file length*/;
            string range = request.Headers["Range"];
            long start = 0;
            long end = 0;
            if (range != null)
            {
                if (!Regex.IsMatch(range, "^bytes=\\d*-\\d*$"))
                {
                    sendError(HttpStatusCode.RequestedRangeNotSatisfiable, response);
                }
                else
                {
                    int dash = range.IndexOf("-");
                    start = long.Parse(range.Substring(6, dash - 6));
                    string part="";
                    if (range.Length > dash)
                    {
                        part = range.Substring(dash + 1, range.Length-dash-1);
                        end = string.IsNullOrEmpty(part.Trim()) ? length - 1 : long.Parse(part);
                        System.Diagnostics.Debug.WriteLine(start + " " + string.IsNullOrEmpty(part.Trim()) + " " + end + " " + range);
                    }
                    
                }
            }
            else
            {
                start = 0;
                end = length - 1;
            }
            if (start > end)
            {
                sendError(HttpStatusCode.RequestedRangeNotSatisfiable, response);
            }

            response.Clear();
            response.ContentType = MimeMapping.GetMimeMapping(fileName);
            response.AddHeader("Content-Disposition", $"attachment;filename=\"{fileName}\"");
            response.AddHeader("Accept-Ranges", "bytes");
            response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + length);
            response.AddHeader("Content-Length", "" + (end - start + 1));
            if (start != 0)
            {  
                response.StatusCode = (int)HttpStatusCode.PartialContent;
                System.Diagnostics.Debug.WriteLine("SomeText");
            }
            response.TransmitFile(filePath + fileName, start, end - start);
            response.End();

        }
        void sendError(HttpStatusCode code, HttpResponse response)
        {
            response.StatusCode = (int)code;
            response.Flush();
        }
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }

}