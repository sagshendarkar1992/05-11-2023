
using ModelPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace Vzah.Models
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var GetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (GetUserId != null)
            {
                LoginSessionDetails objSessLog = new LoginSessionDetails();
                USERMAST daccess = new USERMAST();
                USERMAST obj = new USERMAST();
                obj = daccess.GETLOGINDETAILS(1, 0, GetUserId, "", 0, "OnActionExecuting").FirstOrDefault();
                objSessLog.UserName = obj.USERNAME; objSessLog.EMAIL_ADDRESS = obj.EMAIL_ADDRESS;
                objSessLog.UserId = obj.REGISTRATION_ID;
                objSessLog.Roles = obj.USER_TYPE; objSessLog.USERTYPEStr = obj.USER_TYPE;
                objSessLog.RoleId = 0;
                HttpContext.Current.Session["SessionInformation"] = objSessLog;
            }

        }
    }
    public class SkipMyGlobalActionFilterAttribute : Attribute
    {
    }
}