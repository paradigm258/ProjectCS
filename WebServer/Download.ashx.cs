﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using WebServer.Interface;
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
                int id = 0;
                try
                {
                    id = int.Parse(request.QueryString["id"]);
                }
                catch
                {
                    id = 0;
                }
                Model.Item item = new Dao.ItemDAO().GetItem(id);
                string filePath = context.Server.MapPath("~/Storage/")+item.id;
                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    long length = file.Length;
                    string range = request.Headers["Range"];
                    long start = 0;
                    long end = 0;
                    if (range != null)
                    {
                        if (!Regex.IsMatch(range, "^bytes=\\d*-\\d*$"))
                        {
                            response.StatusCode = (int)HttpStatusCode.RequestedRangeNotSatisfiable;
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
                                response.StatusCode = (int)HttpStatusCode.RequestedRangeNotSatisfiable;
                            }
                        }
                    }
                    else
                    {
                        start = 0;
                        end = length - 1;
                    }
                    response.Clear();
                    response.ContentType = MimeMapping.GetMimeMapping(item.name);
                    response.AddHeader("Content-Disposition", $"attachment;filename=\"{item.name}\"");
                    response.AddHeader("Accept-Ranges", "bytes");
                    response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + length);
                    response.AddHeader("Content-Length", "" + (end - start + 1));
                    if (start != 0 || end != length - 1)
                    {
                        response.StatusCode = (int)HttpStatusCode.PartialContent;
                    }
                    System.Diagnostics.Debug.WriteLine(file.Name);
                    response.TransmitFile(filePath, start, end - start);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "at" + e.Source + ":" + e.StackTrace);
            }
            finally
            {
                context.ApplicationInstance.CompleteRequest();
            }
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