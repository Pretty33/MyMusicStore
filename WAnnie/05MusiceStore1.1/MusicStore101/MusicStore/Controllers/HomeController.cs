﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicStoreEntity;
using MusicStoreEntity.UserAndRole;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new MusicContext();
            var list= context.Ablums.OrderByDescending(x => x.PublisherDate).Take(20).ToList();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 登录测试
        /// </summary>
        /// <returns></returns>
        public string TestLogin(string username = "zj", string pwd = "123.abc")
        {
            var userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MusicStoreEntity.MusicContext()));
            var user = userManager.Find(username, pwd);
            if (user != null)
            {
                var roleName = "";
                var context = new MusicStoreEntity.MusicContext();
                foreach (var role in user.Roles)
                    roleName += (context.Roles.Find(role.RoleId) as ApplicationRole).DisplayName + "";
                return "登录成功，用户属于：" + roleName;
            }
            else
                return "登录失败";
        }

    }
}