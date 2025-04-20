using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoChart.Models;

namespace DemoChart.Controllers;

public class HomeController : Controller
{
    private static List<SavedChartModel> _saveCharts = new List<SavedChartModel>();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new ChartViewModel
        {
            ChartTitle = "Biểu đồ mới",
            ChartType = "bar",
            Labels = "Tháng 1, Tháng 2, Tháng 3, Tháng 4, Tháng 5, Tháng 6",
            DataValues = "65, 59, 80, 81, 56, 55"
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult GenerateChart(ChartViewModel model)
    {
        // Trả về view Index với model đã được cập nhật
        return View("Index", model);
    }

    [HttpPost]
    public IActionResult SaveChart(ChartViewModel model)
    {
        if (string.IsNullOrEmpty(model.ChartTitle))
        {
            model.ChartTitle = "Biểu đồ không tên";
        }

        var saveChart = new SavedChartModel
        {
            Id = _saveCharts.Count > 0 ? _saveCharts.Max(c => c.Id) + 1 : 1,
            Name = model.ChartTitle,
            ChartType = model.ChartType,
            Labels = model.Labels,
            DataValues = model.DataValues,
            ChartTitle = model.ChartTitle,
            ShowLegend = model.ShowLegend,
            CreateAt = DateTime.Now
        };

        _saveCharts.Add(saveChart);
        TempData["SuccessMessage"] = "Lưu biểu đồ thành công!";
        return RedirectToAction("Index");
    }

    public IActionResult SavedCharts()
    {
        return View(_saveCharts);
    }

    public IActionResult LoadChart(int id)
    {
        var savedChart = _saveCharts.FirstOrDefault(c => c.Id == id);
        if (savedChart == null)
        {
            return NotFound();
        }

        var model = new ChartViewModel
        {
            ChartType = savedChart.ChartType,
            Labels = savedChart.Labels,
            DataValues = savedChart.DataValues,
            ChartTitle = savedChart.ChartTitle,
            ShowLegend = savedChart.ShowLegend
        };
        return View("Index", model);
    }

    public IActionResult DeleteChart(int id)
    {
        var chartToRemove = _saveCharts.FirstOrDefault(c => c.Id == id);
        if (chartToRemove != null)
        {
            _saveCharts.Remove(chartToRemove);
            TempData["SuccessMessage"] = "Xóa biểu đồ thành công!";
        }
        return RedirectToAction("SavedCharts");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}