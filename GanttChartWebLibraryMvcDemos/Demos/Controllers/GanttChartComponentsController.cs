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
            var items = new List<GanttChartItem>
            {
                new GanttChartItem { Content = "Task 1" },
                new GanttChartItem { Content = "Task 1.1", Indentation = 1, Start = DateTime.Today, Finish = DateTime.Today.AddDays(3), CompletedFinish = DateTime.Today.AddDays(2), AssignmentsContent = "Resource A" },
                new GanttChartItem { Content = "Task 1.2", Indentation = 1, Start = DateTime.Today.AddDays(3), Finish = DateTime.Today.AddDays(7), AssignmentsContent = "Resource A, Resource B [50%]" },
                new GanttChartItem { Content = "Task 2", Start = DateTime.Today.AddDays(3), Finish = DateTime.Today.AddDays(5), AssignmentsContent = "Resource B" },
                new GanttChartItem { Content = "Task 3", Start = DateTime.Today.AddDays(5), IsMilestone = true }
            };
            items[2].Predecessors.Add(new PredecessorItem { Item = items[1] });
            items[3].Predecessors.Add(new PredecessorItem { Item = items[2], DependencyType = DependencyType.StartStart });
            items[4].Predecessors.Add(new PredecessorItem { Item = items[3] });
            for (var i = 4; i < 16; i++)
                items.Add(new GanttChartItem { Content = $"Task {i}", Start = DateTime.Today.AddDays(i), Finish = DateTime.Today.AddDays(i * 2) });
            return View(model: items);
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
            var items = new[]
            {
                new ScheduleChartItem
                {
                    Content = "Resource 1",
                    GanttChartItems =
                    {
                        new GanttChartItem { Content = "Task A", Start = DateTime.Today, Finish = DateTime.Today.AddDays(5) }
                    }
                },
                new ScheduleChartItem
                {
                    Content = "Resource 2",
                    GanttChartItems =
                    {
                        new GanttChartItem { Content = "Task A", Start = DateTime.Today, Finish = DateTime.Today.AddDays(5) },
                        new GanttChartItem { Content = "Task B", Start = DateTime.Today.AddDays(3), Finish = DateTime.Today.AddDays(7), AssignmentsContent = "50%" }
                    }
                },
                new ScheduleChartItem
                {
                    Content = "Resource 3"
                }
            };
            return View(model: items);
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
            var items = new[]
            {
                new LoadChartItem
                {
                    Content = "Resource 1",
                    GanttChartItems =
                    {
                        new AllocationItem { Content = "Task X", Start = DateTime.Today, Finish = DateTime.Today.AddDays(5) }
                    }
                },
                new LoadChartItem
                {
                    Content = "Resource 2",
                    GanttChartItems =
                    {
                        new AllocationItem { Content = "Task X, Task Y", Start = DateTime.Today, Finish = DateTime.Today.AddDays(5), Units = 1.4 },
                        new AllocationItem { Content = "Task Y", Start = DateTime.Today.AddDays(5), Finish = DateTime.Today.AddDays(7), Units = 0.35 }
                    }
                }
            };
            return View(model: items);
        }

        #endregion
    }
}
