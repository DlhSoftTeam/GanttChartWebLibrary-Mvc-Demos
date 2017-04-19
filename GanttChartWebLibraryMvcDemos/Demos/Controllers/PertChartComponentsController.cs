using DlhSoft.Web.Mvc.Pert;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MainFeatures.Controllers
{
    public class PertChartComponentsController : Controller
    {
        #region PertChartView

        public ActionResult PertChartView()
        {
            var model = new[]
            {
                new PertChartItem { Content = "Event 1", DisplayedText = "1" },
                new PertChartItem { Content = "Event 2", DisplayedText = "2" },
                new PertChartItem { Content = "Event 3", DisplayedText = "3" }
            };
            model[1].Predecessors.Add(new PredecessorItem { Item = model[0] });
            model[2].Predecessors.Add(new PredecessorItem { Item = model[0] });
            return View(model);
        }

        #endregion

        #region NetworkDiagramView

        public ActionResult NetworkDiagramView()
        {
            var model = new[]
            {
                new NetworkDiagramItem { Content = "Task 1", DisplayedText = "Test1" },
                new NetworkDiagramItem { Content = "Task 2", DisplayedText = "Test2" },
                new NetworkDiagramItem { Content = "Task 3", DisplayedText = "Test3" }
            };
            model[1].Predecessors.Add(new NetworkPredecessorItem { Item = model[0] });
            model[2].Predecessors.Add(new NetworkPredecessorItem { Item = model[0] });
            return View(model);
        }

        #endregion
    }
}
