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
            var items = new[]
            {
                new PertChartItem { Content = "Event 1", DisplayedText = "1" },
                new PertChartItem { Content = "Event 2", DisplayedText = "2" },
                new PertChartItem { Content = "Event 3", DisplayedText = "3" }
            };
            items[1].Predecessors.Add(new PredecessorItem { Item = items[0] });
            items[2].Predecessors.Add(new PredecessorItem { Item = items[0] });
            return View(model: items);
        }

        #endregion

        #region NetworkDiagramView

        public ActionResult NetworkDiagramView()
        {
            var items = new[]
            {
                new NetworkDiagramItem { Content = "Task 1", DisplayedText = "Test1" },
                new NetworkDiagramItem { Content = "Task 2", DisplayedText = "Test2" },
                new NetworkDiagramItem { Content = "Task 3", DisplayedText = "Test3" }
            };
            items[1].Predecessors.Add(new NetworkPredecessorItem { Item = items[0] });
            items[2].Predecessors.Add(new NetworkPredecessorItem { Item = items[0] });
            return View(model: items);
        }

        #endregion
    }
}
