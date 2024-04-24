using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;


namespace ToptalAutomationTask.Utilities
{
    internal class ExtentReportManager
    {

        private static ExtentReports _extentReports;


        public static ExtentReports InitializeExtentReports()
        {
            string extentReportPath = CreateExtentReportPath();

            _extentReports = new ExtentReports();
            var spark = new ExtentSparkReporter(extentReportPath);
            _extentReports.AttachReporter(spark);
            spark.Config.Theme = Theme.Dark;
            spark.Config.ReportName = "Test Execution Summary";

            return _extentReports;
        }
        private static string CreateExtentReportPath()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string reportsFolder = Path.Combine(projectDirectory, "Reports");

            if (!Directory.Exists(reportsFolder))
            {
                Directory.CreateDirectory(reportsFolder);
            }

            string[] existingFiles = Directory.GetFiles(reportsFolder);

            // Delete existing files
            foreach (var filePath in existingFiles)
            {
                File.Delete(filePath);
            }

            string timeStamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string reportPath = Path.Combine(reportsFolder, $"TestReport_{timeStamp}.html");
            return reportPath;
        }


        public static string CaptureScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            byte[] screenshotAsByteArray = Convert.FromBase64String(screenshot.AsBase64EncodedString);
            return Convert.ToBase64String(screenshotAsByteArray);
        }

    }
}

