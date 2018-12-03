using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchJobNet_project.Controllers.HistoryController
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult toHistoryView()
        {
            return View("HistoryView");
        }
    }
}