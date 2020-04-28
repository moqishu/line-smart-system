using LINE.SMA.Infrastructure;
using LINE.SMA.Model;
using LINE.SMA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LINE.SMA.Web.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        //public MenuInfoService menuInfoService = IocContainer.Resolve<MenuInfoService>();

        public UserManageService manageService = IocContainer.Resolve<UserManageService>();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult ElmentIndex()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect(Request.ApplicationPath);
            return View();
        }

        public ActionResult AlertInfo(string message)
        {
            return View(model: message);
        }

        public ActionResult CheckLogin(string userName, string pwd, string code)
        {
            if (!string.IsNullOrEmpty(Session["VerifyCode"].ToString()) || code != Session["VerifyCode"].ToString())
            {
                throw new AlertException("验证码错误，请重新输入");
            }

            // 登录账号验证


            FormsAuthentication.SetAuthCookie("UserId", true);

            // 网页cookie验证
            var userCookies = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (userCookies != null)
            {
                var lastAuthValue = FormsAuthentication.Decrypt(userCookies.Value);
                if (lastAuthValue != null)
                {
                    //重新创建票据信息将加密后的密码传入新cookies中
                    var authValue = new FormsAuthenticationTicket(
                        lastAuthValue.Version,
                        lastAuthValue.Name,
                        lastAuthValue.IssueDate,
                        lastAuthValue.Expiration,
                        lastAuthValue.IsPersistent,
                        MD5Encrypt.Encrypt(pwd + MD5Encrypt.appKey),
                        lastAuthValue.CookiePath);

                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                        FormsAuthentication.Encrypt(authValue))
                    {
                        HttpOnly = true,
                        Path = userCookies.Path,
                        Secure = userCookies.Secure
                    };
                    if (userCookies.Domain != null)
                        cookie.Domain = userCookies.Domain;
                    if (authValue.IsPersistent)
                        cookie.Expires = authValue.Expiration;
                    HttpContext.Response.Cookies.Add(cookie);
                }
            }

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        /// <summary>
        /// 切换主题
        /// </summary>
        /// <returns></returns>
        public ActionResult Skin()
        {
            return View();
        }

        public ActionResult HomePage()
        {
            return View();
        }

        public object GetMenuInfo()
        {
            var menuInfos = manageService.GetAllFunction();

            return ToMenuJson(menuInfos, 0);
        }

        private string ToMenuJson(List<Function> data, long parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");

            List<Function> entitys = data.FindAll(c => c.parentid == parentId).OrderBy(c => c.OrderId).ToList();

            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.Id) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }
    }
}
