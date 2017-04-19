using DlhSoft.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MainFeatures.Controllers
{
    public class GanttChartComponentsController : Controller
    {
        #region GanttChartView

        public ActionResult GanttChartView()
        {
            var model = new[]
            {
                new GanttChartItem { Content = "Task 1" },
                new GanttChartItem { Content = "Task 2", Start = DateTime.Today.AddDays(1), Finish = DateTime.Today.AddDays(5), AssignmentsContent = "Resource 1, Resource 2 [50%]" }
            };
            model[1].Predecessors.Add(new PredecessorItem { Item = model[0] });
            return View(model);
        }

        public ActionResult UpdateGanttChartItem(GanttChartItem item)
        {
            // Placeholder for saving changes to database.
            Debug.WriteLine($"Item {item.Content} at index {item.ItemIndex} has been updated.");
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        #endregion

        #region ScheduleChartView

        public ActionResult ScheduleChartView()
        {
            var model = new[]
            {
                new ScheduleChartItem { Content = "Resource 1" },
                new ScheduleChartItem
                {
                    Content = "Resource 2",
                    GanttChartItems =
                    {
                        new GanttChartItem { Content = "Task 1", Start = DateTime.Today.AddDays(1), Finish = DateTime.Today.AddDays(5) },
                        new GanttChartItem { Content = "Task 2", Start = DateTime.Today.AddDays(7 + 1), Finish = DateTime.Today.AddDays(7 + 5), AssignmentsContent = "50%" }
                    }
                }
            };
            return View(model);
        }

        public ActionResult UpdateScheduleChartItem(ScheduleChartItem item)
        {
            // Placeholder for saving changes to database.
            Debug.WriteLine($"Item {item.Content} at index {item.ItemIndex} has been updated.");
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        #endregion

        #region LoadChartView

        public ActionResult LoadChartView()
        {
            var model = new[]
            {
                new LoadChartItem
                {
                    Content = "Resource 1",
                    GanttChartItems =
                    {
                        new AllocationItem { Content = "Task 1", Start = DateTime.Today.AddDays(1), Finish = DateTime.Today.AddDays(5) }
                    }
                },
                new LoadChartItem
                {
                    Content = "Resource 2",
                    GanttChartItems =
                    {
                        new AllocationItem { Content = "Task 1 [125%]", Start = DateTime.Today.AddDays(1), Finish = DateTime.Today.AddDays(5), Units = 1.25 },
                        new AllocationItem { Content = "Task 2 [50%]", Start = DateTime.Today.AddDays(7 + 1), Finish = DateTime.Today.AddDays(7 + 5), Units = 0.5 }
                    }
                }
            };
            return View(model);
        }

        #endregion
    }
}
