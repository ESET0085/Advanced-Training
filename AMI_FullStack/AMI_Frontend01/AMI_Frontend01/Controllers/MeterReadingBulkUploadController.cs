using Microsoft.AspNetCore.Mvc;

namespace AMI_Frontend01.Controllers
{
    // Local DTO to match your API requirements exactly
    public class MeterReadingUploadDto
    {
        public string MeterSerialNo { get; set; }
        public DateTime ReadingDate { get; set; }
        public decimal Kwh { get; set; }
        // CreatedAt is handled by the backend/default value
    }

    public class MeterReadingBulkUploadController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MeterReadingBulkUploadController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
            {
                ViewBag.Message = "Please select a valid CSV file.";
                ViewBag.IsSuccess = false;
                return View("Index");
            }

            if (!csvFile.FileName.EndsWith(".csv"))
            {
                ViewBag.Message = "Only .csv files are allowed.";
                ViewBag.IsSuccess = false;
                return View("Index");
            }

            try
            {
                var readings = new List<MeterReadingUploadDto>();

                using (var stream = csvFile.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    bool isHeader = true;

                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        // Skip header row
                        if (isHeader)
                        {
                            if (line.ToLower().Contains("serial") || line.ToLower().Contains("kwh"))
                            {
                                isHeader = false;
                                continue;
                            }
                            isHeader = false;
                        }

                        var values = line.Split(',');

                        // We expect at least 3 columns: Serial, Date, Kwh
                        if (values.Length >= 3)
                        {
                            string serial = values[0].Trim();
                            string dateStr = values[1].Trim();
                            string kwhStr = values[2].Trim();

                            if (DateTime.TryParse(dateStr, out DateTime date) &&
                                decimal.TryParse(kwhStr, out decimal kwh))
                            {
                                readings.Add(new MeterReadingUploadDto
                                {
                                    MeterSerialNo = serial,
                                    ReadingDate = date,
                                    Kwh = kwh
                                });
                            }
                        }
                    }
                }

                if (readings.Count == 0)
                {
                    ViewBag.Message = "File is empty or no valid rows found (Check Date/Decimal formats).";
                    ViewBag.IsSuccess = false;
                    return View("Index");
                }

                // Send to API
                var client = _httpClientFactory.CreateClient();

                // ⚠️ Ensure this matches your Backend API Port
                string apiUrl = "https://localhost:7035/api/MeterReading/bulk";

                var response = await client.PostAsJsonAsync(apiUrl, readings);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = $"Success! {apiResponse}";
                    ViewBag.IsSuccess = true;
                }
                else
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = $"API Error ({response.StatusCode}): {errorMsg}";
                    ViewBag.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Application Error: {ex.Message}";
                ViewBag.IsSuccess = false;
            }

            return View("Index");
        }
    }
}
