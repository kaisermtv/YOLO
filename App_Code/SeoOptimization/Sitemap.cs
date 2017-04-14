﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Sitemap
/// </summary>
public class Sitemap 
{
    public string sitemap = "";
	 public string ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/xml";
            using (XmlTextWriter writer = new XmlTextWriter(context.Response.OutputStream, Encoding.UTF8)) {
                writer.WriteStartDocument();
                writer.WriteStartElement("urlset");
                writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
                writer.WriteStartElement("url");

                string connect = ConfigurationManager.ConnectionStrings["TVSConnect"].ConnectionString;
                string url = "http://www.yolooo.com/";
                using (SqlConnection conn = new SqlConnection(connect)) {
                    using (SqlCommand cmd = new SqlCommand("GetSiteMapContent", conn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader()) {
                            // Get the date of the most recent article
                            rdr.Read();
                            writer.WriteElementString("loc", string.Format("{0}Default.aspx", url));
                            writer.WriteElementString("lastmod", string.Format("{0:yyyy-MM-dd}", rdr[0]));
                            writer.WriteElementString("changefreq", "weekly");
                            writer.WriteElementString("priority", "1.0");
                            writer.WriteEndElement();
                            // Move to the Facebook Article IDs
                            rdr.NextResult();
                            while (rdr.Read())
                            {
                                writer.WriteStartElement("url");
                                writer.WriteElementString("loc", string.Format("{0}Detailts.aspx?id={1}", url, rdr[0]));

                                if (rdr[1] != DBNull.Value)
                                    writer.WriteElementString("lastmod", string.Format("{0:yyyy-MM-dd}", rdr[1]));
                                writer.WriteElementString("changefreq", "monthly");
                                writer.WriteElementString("priority", "0.5");
                                writer.WriteEndElement();
                            }


                            //// Move to the Article Type IDs
                            //rdr.NextResult();
                            //while (rdr.Read()) {
                            //    writer.WriteStartElement("url");
                            //    writer.WriteElementString("loc", string.Format("{0}ArticleTypes.aspx?Type={1}", url, rdr[0]));
                            //    writer.WriteElementString("priority", "0.5");
                            //    writer.WriteEndElement();
                            //}
                            //// Finally move to the Category IDs
                            //rdr.NextResult();
                            //while (rdr.Read()) {
                            //    writer.WriteStartElement("url");
                            //    writer.WriteElementString("loc", string.Format("{0}Category.aspx?Category={1}", url, rdr[0]));
                            //    writer.WriteElementString("priority", "0.5");
                            //    writer.WriteEndElement();
                            //}
                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Flush();
                        }
                      
                       context.Response.End();
                       context.Response.WriteFile("~/sitemap2.xml"); 
                    }
                   
                }
               
               return writer.ToString();
            }

        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
