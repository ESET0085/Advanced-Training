
using AMI_Project_Backend.DTOs;
using AMI_Project_Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AMI_Project_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;
        private readonly IDataRepository _repository;

        public BillingController(IBillingService billingService, IDataRepository repository)
        {
            _billingService = billingService;
            _repository = repository;
        }

        // -----------------------------
        // Generate bill for a single meter
        // -----------------------------
        [HttpGet("GenerateMonthlyForMeter")]
        public IActionResult GenerateMonthlyForMeter([FromQuery] string meterSerialNo, [FromQuery] string month)
        {
            // Validation: Check if meterSerialNo is provided
            if (string.IsNullOrWhiteSpace(meterSerialNo))
                return BadRequest("meterSerialNo is required.");

            // Validation: Check if month is provided
            if (string.IsNullOrWhiteSpace(month))
                return BadRequest("month is required.");

            // Validation: Parse and validate month format
            if (!DateTime.TryParseExact(month + "-01", "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var billingDate))
                return BadRequest("Invalid month format. Use yyyy-MM.");

            // Validation: Check if month is not in the future
            if (billingDate > DateTime.Now)
                return BadRequest("Cannot generate bills for future months.");

            try
            {
                var bill = _billingService.GenerateMonthlyBillForMeter(meterSerialNo, billingDate);
                if (bill == null)
                    return NotFound($"No active meter or consumer found for meter: {meterSerialNo}");

                return Ok(bill);
            }
            catch (InvalidOperationException ex)
            {
                // Handle duplicate bill scenario
                return Conflict(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating bill: {ex.Message}");
            }
        }

        // -----------------------------
        // Generate bills for all meters under a consumer
        // -----------------------------
        [HttpGet("GenerateMonthlyForConsumer")]
        public IActionResult GenerateMonthlyForConsumer([FromQuery] long consumerId, [FromQuery] string month)
        {
            // Validation: Check if consumerId is valid
            if (consumerId <= 0)
                return BadRequest("Valid consumerId is required.");

            // Validation: Check if month is provided
            if (string.IsNullOrWhiteSpace(month))
                return BadRequest("month is required.");

            // Validation: Parse and validate month format
            if (!DateTime.TryParseExact(month + "-01", "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var billingDate))
                return BadRequest("Invalid month format. Use yyyy-MM.");

            // Validation: Check if month is not in the future
            if (billingDate > DateTime.Now)
                return BadRequest("Cannot generate bills for future months.");

            try
            {
                // Get all meters for this consumer
                var meters = _repository.GetAllMeters()
                                        .Where(m => long.TryParse(m.ConsumerId, out var cId) && cId == consumerId)
                                        .ToList();

                if (!meters.Any())
                    return NotFound($"No meters found for consumerId {consumerId}");

                var bills = new List<BillingDto>();
                var errors = new List<string>();

                foreach (var meter in meters)
                {
                    try
                    {
                        var bill = _billingService.GenerateMonthlyBillForMeter(meter.SerialNo, billingDate);
                        if (bill != null)
                            bills.Add(bill);
                    }
                    catch (InvalidOperationException ex)
                    {
                        // Collect duplicate bill errors but continue processing other meters
                        errors.Add($"Meter {meter.SerialNo}: {ex.Message}");
                    }
                }

                if (!bills.Any() && !errors.Any())
                    return NotFound($"No bills could be generated for consumerId {consumerId} in month {month}");

                // Optional: aggregated totals
                var summary = new
                {
                    ConsumerId = consumerId,
                    Month = month,
                    TotalUnitsConsumed = bills.Sum(b => b.UnitsConsumed),
                    TotalAmount = bills.Sum(b => b.Amount),
                    TotalTax = bills.Sum(b => b.TaxAmount),
                    TotalPayable = bills.Sum(b => b.TotalAmount),
                    BillsGenerated = bills.Count,
                    Errors = errors.Any() ? errors : null
                };

                return Ok(new { Bills = bills, Summary = summary });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error generating bills: {ex.Message}");
            }
        }

        // -----------------------------
        // Get all persisted bills
        // -----------------------------
        [HttpGet]
        public IActionResult GetAllBills()
        {
            try
            {
                var bills = _billingService.GetAllBills();

                // Validation: Check if bills exist
                if (bills == null || !bills.Any())
                    return NotFound("No bills found in the system.");

                return Ok(bills);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving bills: {ex.Message}");
            }
        }

        [HttpGet("ByConsumer/{consumerId}")]
        public IActionResult GetBillsByConsumer(long consumerId)
        {
            var bills = _billingService.GetAllBills()
                        .Where(b => b.ConsumerId == consumerId)
                        .ToList();

            if (!bills.Any())
                return NotFound("No bills for this consumer.");

            return Ok(bills);
        }

    }
}