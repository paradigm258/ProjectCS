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
            try
            {
                string fileName = "Software Requirements 3, 3rd Edition.pdf";
                string filePath = context.Server.MapPath("~/Storage/");
                FileInfo file = new FileInfo(filePath + fileName);
                long length = 2/*file.Length*/;
                string range = request.Headers["Range"];
                long start = 0;
                long end = 0;
                if (range != null)
                {
                    if (!Regex.IsMatch(range, "^bytes=\\d*-\\d*$"))
                    {
                        sendError(HttpStatusCode.RequestedRangeNotSatisfiable, response);
                        return;
                    }
                    else
                    {
                        int dash = range.IndexOf("-");
                        start = long.Parse(range.Substring(6, dash - 6));
                        string part = "";
                        if (range.Length > dash)
                        {
                            part = range.Substring(dash + 1, range.Length - dash - 1);
                            end = string.IsNullOrEmpty(part.Trim()) ? length - 1 : long.Parse(part);
                            System.Diagnostics.Debug.WriteLine(start + " " + string.IsNullOrEmpty(part.Trim()) + " " + end + " " + range);
                        }
                        if (start > end)
                        {
                            sendError(HttpStatusCode.RequestedRangeNotSatisfiable, response);
                            return;
                        }
                    }
                }
                else
                {
                    start = 0;
                    end = length - 1;
                }
                response.Clear();
                response.ContentType = MimeMapping.GetMimeMapping(fileName);
                response.AddHeader("Content-Disposition", $"attachment;filename=\"{fileName}\"");
                response.AddHeader("Accept-Ranges", "bytes");
                response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + length);
                response.AddHeader("Content-Length", "" + (end - start + 1));
                if (start != 0 || end != length - 1)
                {
                    response.StatusCode = (int)HttpStatusCode.PartialContent;
                }
                response.TransmitFile(filePath + fileName, start, end - start);
            }
            catch { }
            finally
            {
                context.ApplicationInstance.CompleteRequest();
            }
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