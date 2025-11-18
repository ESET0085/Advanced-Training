import { useState } from "react";
import { Line } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";

ChartJS.register(CategoryScale, LinearScale, PointElement, LineElement, Title, Tooltip, Legend);

export default function MeterData() {
  const [range, setRange] = useState("Day");

  const labels = ["01 Sep", "02 Sep", "03 Sep", "04 Sep", "05 Sep", "06 Sep", "07 Sep"];
  const datasets = {
    Day: { previous: [300, 200, 250, 400, 370, 380, 310], current: [350, 280, 330, 410, 400, 420, 300] },
    Week: { previous: [2000, 2100, 1900, 2200], current: [2050, 2150, 1950, 2250] },
    Month: { previous: [8000, 8200, 7800, 8300], current: [8100, 8300, 7900, 8400] },
  };

  const data = {
    labels: labels,
    datasets: [
      {
        label: "Previous",
        data: datasets[range].previous,
        borderColor: "#4A7856",
        backgroundColor: "rgba(74,120,86,0.15)",
        tension: 0.4,
        fill: true,
        pointHoverRadius: 8,
        pointHoverBackgroundColor: "#4A7856",
      },
      {
        label: "Current",
        data: datasets[range].current,
        borderColor: "#81B29A",
        backgroundColor: "rgba(129,178,154,0.25)",
        tension: 0.4,
        fill: true,
        pointHoverRadius: 8,
        pointHoverBackgroundColor: "#81B29A",
      },
    ],
  };

  const options = {
    responsive: true,
    plugins: {
      legend: { position: "top", labels: { color: "#2F3E36" } },
      tooltip: {
        enabled: true,
        mode: "nearest",
        intersect: false,
        callbacks: {
          label: function (tooltipItem) {
            return `${tooltipItem.dataset.label}: ${tooltipItem.formattedValue} kWh`;
          },
        },
      },
      title: {
        display: true,
        text: `Meter Data - ${range}`,
        font: { size: 18 },
        color: "#2F3E36",
      },
    },
    interaction: { mode: "nearest", intersect: false },
    scales: {
      y: {
        beginAtZero: true,
        ticks: { stepSize: 100, color: "#2F3E36" },
        title: { display: true, text: "kWh", color: "#2F3E36" },
        grid: { color: "rgba(0,0,0,0.1)" },
      },
      x: {
        title: { display: true, text: "Date", color: "#2F3E36" },
        ticks: { color: "#2F3E36" },
        grid: { color: "rgba(0,0,0,0.05)" },
      },
    },
  };

  const readings = [
    { date: "01 Sep 2025", reading: "25 kWh", difference: "25 kWh", notes: "hello world" },
    { date: "02 Sep 2025", reading: "28 kWh", difference: "3 kWh", notes: "" },
    { date: "03 Sep 2025", reading: "30 kWh", difference: "2 kWh", notes: "" },
  ];

  return (
    <div className="flex flex-col items-center space-y-6">
      {/* Chart Section */}
      <div className="bg-white dark:bg-gray-800 shadow-md rounded-2xl p-5 w-full max-w-4xl">
        <div className="flex justify-between items-center mb-3">
          <h2 className="text-lg font-semibold text-green-800">Select Date Range</h2>
          <div className="flex space-x-2">
            {["Day", "Week", "Month"].map((label) => (
              <button
                key={label}
                onClick={() => setRange(label)}
                className={`px-4 py-1 rounded-full border transition-all duration-200 ${
                  range === label
                    ? "bg-green-200 text-green-900 border-green-400"
                    : "bg-green-50 hover:bg-green-100 text-green-800 border-green-200"
                }`}
              >
                {label}
              </button>
            ))}
          </div>
        </div>
        <Line options={options} data={data} />
      </div>

      {/* Table Section */}
      <div className="bg-white dark:bg-gray-800 shadow-md rounded-2xl w-full max-w-4xl">
        <table className="min-w-full text-sm text-center border-collapse rounded-lg overflow-hidden">
          <thead className="bg-green-100 border-b border-green-300">
            <tr>
              {["Date", "Reading", "Difference", "Notes"].map((h, i) => (
                <th
                  key={i}
                  className="p-3 border border-green-200 text-green-900 font-medium"
                >
                  {h}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {readings.map((row, idx) => (
              <tr
                key={idx}
                className="border-b border-green-200 hover:bg-green-50 transition-all"
              >
                <td className="p-3 text-green-900">{row.date}</td>
                <td className="p-3 text-green-900">{row.reading}</td>
                <td className="p-3 text-green-900">{row.difference}</td>
                <td className="p-3 text-green-900">{row.notes || "—"}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
