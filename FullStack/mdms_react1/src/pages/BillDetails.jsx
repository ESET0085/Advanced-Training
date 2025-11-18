import React from "react";
import { useNavigate } from "react-router-dom";
import Button from "../components/Button";

const BillDetails = () => {
  const navigate = useNavigate();

  const bill = {
    month: "September 2025",
    totalAmount: "₹1230",
    dueDate: "12 Oct 2025",
    status: "Pending",
    readings: [
      { date: "01 Sep 2025", reading: "25 kWh", consumption: "25 kWh", cost: "₹120" },
      { date: "", reading: "", consumption: "", cost: "" },
      { date: "", reading: "", consumption: "", cost: "" },
      { date: "", reading: "", consumption: "", cost: "" },
    ],
  };

  const handleDownloadPDF = () => alert("Downloading PDF...");
  const handlePrintBill = () => window.print();
  const handlePayNow = () => alert("Redirecting to Payment...");

  return (
    <div className="w-[1150px] bg-amber-50 p-10 rounded-2xl shadow-sm mx-auto mt-10">
      {/* Header */}
      <div className="flex items-center mb-6">
        <button
          onClick={() => navigate(-1)}
          className="text-green-800 hover:text-green-700 text-lg mr-3"
        >
          ←
        </button>
        <h1 className="text-xl font-semibold text-green-900">
          Bill Details – Sep 2025
        </h1>
      </div>

      {/* Bill Summary */}
      <div className="w-[696px] border border-green-200 rounded-lg mb-6 bg-green-50">
        <table className="min-w-full text-left text-sm">
          <thead className="bg-green-100">
            <tr>
              <th className="py-3 px-4 border-b border-green-200">Month</th>
              <th className="py-3 px-4 border-b border-green-200">Total Amount</th>
              <th className="py-3 px-4 border-b border-green-200">Due Date</th>
              <th className="py-3 px-4 border-b border-green-200">Status</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td className="py-3 px-4 border-b border-green-200 text-green-900">{bill.month}</td>
              <td className="py-3 px-4 border-b border-green-200 text-green-900">{bill.totalAmount}</td>
              <td className="py-3 px-4 border-b border-green-200 text-green-900">{bill.dueDate}</td>
              <td className="py-3 px-4 border-b border-green-200 font-medium text-red-600">{bill.status}</td>
            </tr>
          </tbody>
        </table>
      </div>

      {/* Reading Table */}
      <div className="w-[693px] border border-green-200 rounded-lg mb-6 bg-green-50">
        <table className="min-w-full text-left text-sm">
          <thead className="bg-green-100">
            <tr>
              <th className="py-3 px-4 border-b border-green-200">Date</th>
              <th className="py-3 px-4 border-b border-green-200">Reading</th>
              <th className="py-3 px-4 border-b border-green-200">Consumption</th>
              <th className="py-3 px-4 border-b border-green-200">Cost</th>
            </tr>
          </thead>
          <tbody>
            {bill.readings.map((r, i) => (
              <tr key={i}>
                <td className="py-3 px-4 border-b border-green-200 text-green-900">{r.date}</td>
                <td className="py-3 px-4 border-b border-green-200 text-green-900">{r.reading}</td>
                <td className="py-3 px-4 border-b border-green-200 text-green-900">{r.consumption}</td>
                <td className="py-3 px-4 border-b border-green-200 text-green-900">{r.cost}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Buttons Section */}
      <div className="w-[329px] flex justify-between border border-green-200 rounded-lg p-2 bg-amber-50">
        <Button label="Download PDF" onClick={handleDownloadPDF} color="green" />
        <Button label="Print Bill" onClick={handlePrintBill} color="green" />
        <Button label="Pay Now" onClick={handlePayNow} color="green" />
      </div>
    </div>
  );
};

export default BillDetails;
