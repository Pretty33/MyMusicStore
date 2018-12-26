﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.ViewsModel;
using MusicStoreEntity;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        public static readonly MusicContext _Context=new MusicContext();
        /// <summary>
        /// 显示专辑的明细
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(Guid id)
        {
           
            var detail = _Context.Ablums.Find(id);
            return View(detail);
            //自己写的
            //if (Session["LoginUserSessionModel"] == null)
            //    return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "Store") });
            //var person = _Context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
            //try
            //{
            //    ViewBag.Reply = _Context.Replys.Where(x => x.Ablum.ID == id && x.Person.ID == person.ID).ToList();
            //}
            //catch
            //{

            //}
            //return View(detail);

        }

        [HttpPost]
        [ValidateInput(false)]
        //关闭验证
        public ActionResult AddCmt(string cmt, string reply,string id)
        {
            if (Session["LoginUserSessionModel"] == null)
                return Json("nologin");

            var person = _Context.Persons.Find((Session["LoginUserSessionModel"] 
                as LoginUserSessionModel).Person.ID);
            var ablum = _Context.Ablums.Find(Guid.Parse(id));

            //创建回复
            var r = new Reply()
            {
                Ablum = ablum,
                Person = person,
                Content = cmt,
                Title = "123123"
            };
            //父级回复
            if (string.IsNullOrEmpty(reply))
            {
                //顶级回复,ParentReply为空
                r.ParentReply = null;
            }

            else
            {
                r.ParentReply = _Context.Replys.Find(Guid.Parse(reply));
            }

            _Context.Replys.Add(r);
            _Context.SaveChanges();
            return View("OK");
        }


        /// <summary>
        /// 按分类显示专辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Browser(Guid id)
        {
            var list = _Context.Ablums.Where(x => x.Genre.ID == id)
                .OrderByDescending(x => x.PublisherDate).ToList();
            return View(list);
        }
        /// <summary>
        /// 显示所有的分类
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var genres = _Context.Genres.OrderBy(x => x.Name).ToList();
            return View(genres);
        }

        //[HttpPost]
        //public ActionResult Reply(Guid id, string pary)
        //{
        //    if (Session["LoginUserSessionModel"] == null)
        //        return RedirectToAction("login", "Account", new { returnUrl = Url.Action("Index", "ShoppingCart") });
        //    var person = (Session["LoginUserSessionModel"] as LoginUserSessionModel).Person;

        //    var rely = new Reply()
        //    {
        //        Content = pary,
        //        Ablum = _Context.Ablums.Find(id),
        //        Person = _Context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID),

        //    };
        //    _Context.Replys.Add(rely);
        //    _Context.SaveChanges();
        //    var list=new List<Reply>();
        //    var p = _Context.Persons.Find((Session["LoginUserSessionModel"] as LoginUserSessionModel).Person.ID);
        //    try
        //    {
        //        list = _Context.Replys.Where(x => x.Ablum.ID == id && x.Person.ID == person.ID).ToList();
        //    }
        //    catch 
        //    {
                
        //    }
        //    var htmlString = "";
        //    foreach (var item in list)
        //    {
        //        htmlString += "<div class=\"pary\">";
        //        htmlString += "<img style=\"width: 80px; border-radius: 50%;\" src="+item.Person.Avarda+">";
        //        htmlString += "<p>"+item.Person.Name+"</p>";
        //        htmlString += "<p>"+item.CreateDateTime+"</p>";
        //        htmlString += "<p>"+item.Content+"</p>";
        //        htmlString += "</div>";

        //    }

        //    return Json(htmlString);
        //}
    }
}