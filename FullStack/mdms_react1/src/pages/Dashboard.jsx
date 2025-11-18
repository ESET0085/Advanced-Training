import React, { useState } from "react";
import LineChartComponent from "../components/LineCharts";
import Button from "../components/Button";

const Dashboard = () => {
  const [chartPeriod, setChartPeriod] = useState("Day");

  // Dummy quick action functions
  const handlePayBill = () => alert("Pay Bill clicked");
  const handleViewBillHistory = () => alert("View Bill History clicked");
  const handleViewDetailedUsage = () => alert("View Detailed Usage clicked");
  const handleManageNotifications = () => alert("Manage Notifications clicked");

  return (
    <div className="flex flex-col gap-6 bg-emerald-50 min-h-screen px-16 py-4">
      {/* Header info */}
      <div className="flex justify-between items-center mb-6 bg-white rounded-2xl shadow-md border border-emerald-200 px-6 py-3">
        <div>
          <h1 className="text-2xl font-semibold text-emerald-900">
            Dashboard Overview
          </h1>
          <p className="text-sm text-emerald-700 mt-1">
            Hello, <span className="font-semibold text-emerald-800">xyz</span> 👋  
            Here’s your latest energy summary
          </p>
        </div>
        <div className="text-right text-sm text-emerald-700">
          <p>Last synced at 10:45 AM</p>
          <p>Data Source: Smart Meter #1023</p>
        </div>
      </div>

      {/* Cards */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-3 mb-6">
        {[
          { title: "256 kWh", subtitle: "Current Consumption" },
          { title: "₹1,230 Due on 12 Oct", subtitle: "This Month’s Bill" },
          { title: "₹120 Pending", subtitle: "Outstanding Balance" },
          { title: "Paid ₹1,200 on 10 Sep", subtitle: "Last Payment" },
        ].map((card, i) => (
          <div
            key={i}
            className="bg-white shadow-sm rounded-2xl p-3 text-center border border-emerald-100 hover:shadow-md hover:scale-[1.01] transition-all"
          >
            <p className="text-lg font-semibold text-emerald-800">
              {card.title}
            </p>
            <p className="text-emerald-600 mt-1 text-xs">{card.subtitle}</p>
          </div>
        ))}
      </div>

      {/* Chart Section */}
      <div className="bg-white rounded-2xl shadow-md px-6 py-4 mb-6 border border-emerald-100">
        <div className="flex justify-between items-center mb-2">
          <h2 className="text-lg font-semibold text-emerald-900">
            Electricity Consumption Overview
          </h2>
          <div className="space-x-2 flex">
            {["Day", "Week", "Month"].map((label) => (
              <button
                key={label}
                onClick={() => setChartPeriod(label)}
                className={`w-[65px] font-medium rounded-md text-sm py-1 transition-all border ${
                  chartPeriod === label
                    ? "bg-emerald-400 text-white border-emerald-500 shadow-md"
                    : "bg-emerald-200 text-emerald-900 border-emerald-300 hover:bg-emerald-300"
                }`}
              >
                {label}
              </button>
            ))}
          </div>
        </div>
        <LineChartComponent period={chartPeriod} />
      </div>

      {/* Quick Actions */}
      <div className="bg-white rounded-2xl shadow-md px-6 py-3 flex flex-wrap gap-3 justify-center border border-emerald-100">
        <button
          onClick={handlePayBill}
          className="bg-emerald-400 hover:bg-emerald-500 text-white font-semibold px-4 py-1.5 rounded-md shadow-sm transition-all text-sm"
        >
          Pay Bill
        </button>
        <button
          onClick={handleViewBillHistory}
          className="bg-emerald-400 hover:bg-emerald-500 text-white font-semibold px-4 py-1.5 rounded-md shadow-sm transition-all text-sm"
        >
          View Bill History
        </button>
        <button
          onClick={handleViewDetailedUsage}
          className="bg-emerald-400 hover:bg-emerald-500 text-white font-semibold px-4 py-1.5 rounded-md shadow-sm transition-all text-sm"
        >
          View Detailed Usage
        </button>
        <button
          onClick={handleManageNotifications}
          className="bg-emerald-400 hover:bg-emerald-500 text-white font-semibold px-4 py-1.5 rounded-md shadow-sm transition-all text-sm"
        >
          Manage Notifications
        </button>
      </div>
    </div>
  );
};

export default Dashboard;
