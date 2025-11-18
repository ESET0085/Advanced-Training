// src/pages/ReportsAndAnalytics.jsx
import React, { useState, useMemo, useContext } from "react";
import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  Legend,
  BarChart,
  Bar,
} from "recharts";
import { DarkModeContext } from "../Layout/ZoneDashboardLayout.jsx";

// Sample data
const lineData = [
  { date: "Jan", consumption: 300 },
  { date: "Feb", consumption: 400 },
  { date: "Mar", consumption: 200 },
  { date: "Apr", consumption: 350 },
  { date: "May", consumption: 380 },
  { date: "Jun", consumption: 250 },
  { date: "Jul", consumption: 400 },
  { date: "Aug", consumption: 300 },
];

const barDataOriginal = [
  { zone: "Mangalore", consumption: 60 },
  { zone: "Bajpe", consumption: 25 },
  { zone: "Pumpwell", consumption: 90 },
  { zone: "PVS", consumption: 45 },
  { zone: "Kotekar", consumption: 70 },
];

const reportDataOriginal = [
  { id: 123, date: "2025-10-07", user: "abc", consumption: "24kWh", status: "Active", zone: "Mangalore" },
  { id: 124, date: "2025-10-07", user: "xyz", consumption: "16kWh", status: "De-Activated", zone: "Bajpe" },
  { id: 125, date: "2025-10-07", user: "pqr", consumption: "30kWh", status: "Active", zone: "Pumpwell" },
  { id: 126, date: "2025-10-08", user: "lmn", consumption: "28kWh", status: "Active", zone: "Mangalore" },
];

const ReportsAndAnalytics = () => {
  const { darkMode } = useContext(DarkModeContext);
  const [searchZone, setSearchZone] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const reportsPerPage = 5;

  const filteredBarData = useMemo(
    () => barDataOriginal.filter(d => d.zone.toLowerCase().includes(searchZone.toLowerCase())),
    [searchZone]
  );

  const filteredReports = useMemo(
    () => reportDataOriginal.filter(r => r.zone.toLowerCase().includes(searchZone.toLowerCase())),
    [searchZone]
  );

  const totalPages = Math.ceil(filteredReports.length / reportsPerPage);
  const currentReports = filteredReports.slice((currentPage - 1) * reportsPerPage, currentPage * reportsPerPage);

  const handlePageChange = (page) => {
    if (page >= 1 && page <= totalPages) setCurrentPage(page);
  };

  const exportCSV = () => {
    const header = ["Meter ID", "Date", "User", "Consumption", "Status", "Zone"];
    const rows = filteredReports.map(r => [r.id, r.date, r.user, r.consumption, r.status, r.zone]);
    let csvContent = "data:text/csv;charset=utf-8," + [header, ...rows].map(e => e.join(",")).join("\n");
    const link = document.createElement("a");
    link.setAttribute("href", encodeURI(csvContent));
    link.setAttribute("download", "reports.csv");
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  };

  const exportPDF = () => alert("PDF export can be added using jsPDF");

  return (
    <div className={`ml-64 min-h-screen p-6 md:p-8 relative overflow-hidden ${
      darkMode ? "bg-slate-900" : "bg-gradient-to-br from-indigo-100 via-purple-100 to-indigo-50"
    }`}>

      {/* Floating Gradient Blobs */}
      <div className="absolute top-[-100px] left-[-100px] w-80 h-80 bg-purple-400/40 rounded-full filter blur-3xl animate-blob opacity-70 z-0"></div>
      <div className="absolute top-[200px] right-[-150px] w-96 h-96 bg-pink-400/30 rounded-full filter blur-3xl animate-blob animation-delay-2000 opacity-60 z-0"></div>
      <div className="absolute bottom-[50px] left-[150px] w-72 h-72 bg-indigo-400/20 rounded-full filter blur-3xl animate-blob animation-delay-4000 opacity-50 z-0"></div>

      <div className="max-w-6xl mx-auto relative z-10">
        <h1 className={`text-3xl font-extrabold mb-6 text-transparent bg-clip-text ${
          darkMode ? "bg-gradient-to-r from-purple-400 to-pink-500" : "bg-gradient-to-r from-indigo-600 to-purple-600"
        }`}>
          Reports & Analytics
        </h1>

        {/* Charts side by side */}
        <div className="flex flex-col lg:flex-row gap-6 mb-6">
          {/* Line Chart */}
          <div className={`flex-1 bg-white/80 dark:bg-gray-800/60 backdrop-blur-md p-6 rounded-2xl shadow-lg border ${
            darkMode ? "border-purple-600" : "border-indigo-200"
          }`}>
            <LineChart width={350} height={300} data={lineData}>
              <CartesianGrid strokeDasharray="3 3" stroke={darkMode ? "#555" : "#ccc"} />
              <XAxis dataKey="date" stroke={darkMode ? "#fff" : "#000"} />
              <YAxis stroke={darkMode ? "#fff" : "#000"} />
              <Tooltip />
              <Legend />
              <Line type="monotone" dataKey="consumption" stroke="#8884d8" />
            </LineChart>
          </div>

          {/* Bar Chart */}
          <div className={`flex-1 bg-white/80 dark:bg-gray-800/60 backdrop-blur-md p-6 rounded-2xl shadow-lg border ${
            darkMode ? "border-purple-600" : "border-indigo-200"
          }`}>
            <div className="flex justify-between mb-4 items-center">
              <input
                type="text"
                placeholder="Search zone"
                className="border px-3 py-2 rounded-lg w-1/2 focus:ring-2 focus:ring-purple-400 focus:outline-none dark:bg-gray-700 dark:text-gray-100"
                value={searchZone}
                onChange={(e) => { setSearchZone(e.target.value); setCurrentPage(1); }}
              />
              <div className="flex gap-3">
                <button
                  onClick={exportCSV}
                  className="px-4 py-2 rounded-xl font-semibold text-white bg-gradient-to-r from-purple-500 to-pink-500 hover:from-purple-600 hover:to-pink-600 transition shadow-md hover:shadow-lg"
                >
                  Export CSV
                </button>
                <button
                  onClick={exportPDF}
                  className="px-4 py-2 rounded-xl font-semibold text-white bg-gradient-to-r from-purple-400 to-indigo-500 hover:from-purple-500 hover:to-indigo-600 transition shadow-md hover:shadow-lg"
                >
                  Export PDF
                </button>
              </div>
            </div>

            <BarChart width={350} height={300} data={filteredBarData}>
              <CartesianGrid strokeDasharray="3 3" stroke={darkMode ? "#555" : "#ccc"} />
              <XAxis dataKey="zone" stroke={darkMode ? "#fff" : "#000"} />
              <YAxis stroke={darkMode ? "#fff" : "#000"} />
              <Tooltip />
              <Bar dataKey="consumption" fill="#8884d8" />
            </BarChart>
          </div>
        </div>

        {/* Reports Table */}
        <div className={`bg-white/80 dark:bg-gray-800/60 backdrop-blur-md p-6 rounded-2xl shadow-lg border ${
          darkMode ? "border-purple-600" : "border-indigo-200"
        }`}>
          <table className="min-w-full text-sm">
            <thead className={`${darkMode ? "bg-gray-700 text-gray-100" : "bg-gray-100 text-gray-900"}`}>
              <tr>
                {["Meter ID","Date","User","Consumption","Status","Zone"].map(head => (
                  <th key={head} className="py-2 px-4 text-left">{head}</th>
                ))}
              </tr>
            </thead>
            <tbody>
              {currentReports.map(r => (
                <tr key={r.id} className="border-b rounded-lg transition-all hover:scale-[1.02] hover:shadow-lg hover:bg-indigo-50 dark:hover:bg-slate-700/50">
                  <td className="py-2 px-4">{r.id}</td>
                  <td className="py-2 px-4">{r.date}</td>
                  <td className="py-2 px-4">{r.user}</td>
                  <td className="py-2 px-4">{r.consumption}</td>
                  <td className={`py-2 px-4 font-medium ${r.status === "Active" ? "text-green-600 dark:text-green-300" : "text-red-600 dark:text-red-300"}`}>{r.status}</td>
                  <td className="py-2 px-4">{r.zone}</td>
                </tr>
              ))}
            </tbody>
          </table>

          {/* Pagination */}
          <div className="flex justify-end mt-4 gap-2">
            <button 
              onClick={() => handlePageChange(currentPage - 1)} 
              disabled={currentPage === 1} 
              className="px-3 py-1 rounded-2xl font-medium transition bg-gray-200 dark:bg-purple-700 text-gray-800 dark:text-white disabled:opacity-50 hover:bg-gray-300 dark:hover:bg-purple-600"
            >
              Prev
            </button>
            {[...Array(totalPages).keys()].map(i => (
              <button 
                key={i+1} 
                onClick={() => handlePageChange(i+1)} 
                className={`px-3 py-1 rounded-2xl font-medium transition ${
                  currentPage === i+1 
                    ? "bg-purple-600 text-white" 
                    : "bg-gray-200 dark:bg-purple-800 text-gray-800 dark:text-purple-300 hover:bg-gray-300 dark:hover:bg-purple-600"
                }`}
              >
                {i+1}
              </button>
            ))}
            <button 
              onClick={() => handlePageChange(currentPage + 1)} 
              disabled={currentPage === totalPages} 
              className="px-3 py-1 rounded-2xl font-medium transition bg-gray-200 dark:bg-purple-700 text-gray-800 dark:text-white disabled:opacity-50 hover:bg-gray-300 dark:hover:bg-purple-600"
            >
              Next
            </button>
          </div>
        </div>

      </div> {/* End max-w-6xl */}
    </div>
  );
};

export default ReportsAndAnalytics;
