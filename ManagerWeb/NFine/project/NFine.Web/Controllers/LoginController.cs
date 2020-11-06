/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using NFine.Domain.Entity.SystemSecurity;
using NFine.Application.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Domain.Entity.SystemManage;
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Application;

namespace NFine.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new LogEntity
            {
                F_ModuleName = "Login",
                F_Type = "Login",
                F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
                F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
                F_Result = true,
                F_Description = "LoginOut",
            });
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_ModuleName = "Login";
            logEntity.F_Type = "Login";
            try
            {
                if (Session["nfine_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["nfine_session_verifycode"].ToString())
                {
                    throw new Exception("Code is Error Plase Agin");
                }

                UserEntity userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.F_Id;
                    operatorModel.UserCode = userEntity.F_Account;
                    operatorModel.UserName = userEntity.F_RealName;
                    operatorModel.CompanyId = userEntity.F_OrganizeId;
                    operatorModel.DepartmentId = userEntity.F_DepartmentId;
                    operatorModel.RoleId = userEntity.F_RoleId;
                    operatorModel.LoginIPAddress = "";
                    operatorModel.LoginIPAddressName = "";
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.F_Account == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.F_Account = userEntity.F_Account;
                    logEntity.F_NickName = userEntity.F_RealName;
                    logEntity.F_Result = true;
                    logEntity.F_Description = "Login is OK";
                    new LogApp().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "Login is OK" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.F_Account = username;
                logEntity.F_NickName = username;
                logEntity.F_Result = false;
                logEntity.F_Description = "Login Error，" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
