﻿using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace SQLiDemoUserAgent.AttributeFilters
{
    public class LogUserAgentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LogConStr"].ConnectionString))
                {
                    con.Open();

                    string sql = $"SELECT 1 FROM dbo.UserAgentLog WHERE Page = 'Blog' AND UserAgent = '{filterContext.HttpContext.Request.Headers["User-Agent"]}' ;";
                    SqlCommand comm = new SqlCommand(sql, con);
                    var res = comm.ExecuteScalar();

                    if (res != null)
                        sql = "UPDATE dbo.UserAgentLog SET Count = Count + 1 WHERE UserAgent = @UserAgent AND Page = 'Blog';";
                    else
                        sql = "INSERT INTO dbo.UserAgentLog (UserAgent, Page) VALUES (@UserAgent, 'Blog');";

                    SqlCommand comm2 = new SqlCommand(sql, con);
                    comm2.Parameters.AddWithValue("@UserAgent", filterContext.HttpContext.Request.Headers["User-Agent"]);
                    comm2.ExecuteNonQuery();
                }
            }
            catch
            {
                //All done, took 10min to program! - We dont care that it failed - UseLess data anyway :)
            }
            base.OnActionExecuting(filterContext);
        }
    }
}