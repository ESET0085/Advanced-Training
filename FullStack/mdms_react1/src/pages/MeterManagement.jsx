// src/pages/MeterManagement.jsx
import React, { useState, useContext } from "react";
import { DarkModeContext } from "../Layout/ZoneDashboardLayout.jsx";

const MeterManagement = () => {
  const { darkMode } = useContext(DarkModeContext);
  const [currentPage, setCurrentPage] = useState(1);

  const meterData = [
    { id: 123, zone: "Mangalore", owner: "abc", status: "Active", lastReading: "2025-10-07T07:15:13Z" },
    { id: 124, zone: "Bajpe", owner: "xyz", status: "De-Activated", lastReading: "2025-10-07T07:15:13Z" },
    { id: 125, zone: "Mangalore", owner: "abc", status: "Active", lastReading: "2025-10-07T07:15:13Z" },
    { id: 126, zone: "Bajpe", owner: "xyz", status: "De-Activated", lastReading: "2025-10-07T07:15:13Z" },
    { id: 127, zone: "Bajpe", owner: "xyz", status: "De-Activated", lastReading: "2025-10-07T07:15:13Z" },
    { id: 128, zone: "Mangalore", owner: "abc", status: "Active", lastReading: "2025-10-07T07:15:13Z" },
    { id: 129, zone: "Bajpe", owner: "xyz", status: "De-Activated", lastReading: "2025-10-07T07:15:13Z" },
  ];

  const metersPerPage = 5;
  const totalPages = Math.ceil(meterData.length / metersPerPage);
  const currentMeters = meterData.slice((currentPage - 1) * metersPerPage, currentPage * metersPerPage);

  const handlePageChange = (page) => {
    if (page >= 1 && page <= totalPages) setCurrentPage(page);
  };

  return (
    <div
      className={`min-h-screen ml-64 p-6 md:p-8 ${
        darkMode
          ? "bg-slate-900"
          : "bg-gradient-to-br from-indigo-100 via-purple-100 to-indigo-50"
      }`}
    >
      {/* Title */}
      <h1
        className={`text-3xl font-extrabold mb-6 text-transparent bg-clip-text ${
          darkMode
            ? "bg-gradient-to-r from-purple-400 to-pink-500"
            : "bg-gradient-to-r from-indigo-600 to-purple-600"
        }`}
      >
        Meter Management
      </h1>

      {/* Table */}
      <div
        className={`overflow-x-auto rounded-2xl shadow-lg p-6 ${
          darkMode
            ? "backdrop-blur-md bg-slate-800/60 border border-purple-600"
            : "bg-white border border-indigo-200"
        }`}
      >
        <table className="min-w-full text-left">
          <thead>
            <tr
              className={`${darkMode ? "text-purple-300" : "text-indigo-700"} border-b border-gray-300`}
            >
              {["Meter ID", "Zone", "Owner", "Status", "Last Reading", "More Actions"].map((head) => (
                <th key={head} className="py-3 px-4 font-medium">
                  {head}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {currentMeters.map((meter) => (
              <tr
                key={meter.id}
                className={`${darkMode ? "text-gray-200" : "text-gray-800"} hover:shadow-xl hover:scale-[1.02] transition-all rounded-lg`}
              >
                <td className="py-3 px-4">{meter.id}</td>
                <td className="py-3 px-4">{meter.zone}</td>
                <td className="py-3 px-4">{meter.owner}</td>
                <td className="py-3 px-4">
                  <span
                    className={`px-2 py-1 rounded-full font-semibold text-sm ${
                      meter.status === "Active"
                        ? "bg-green-200 text-green-800 dark:bg-green-700 dark:text-green-100"
                        : "bg-red-200 text-red-800 dark:bg-red-700 dark:text-red-100"
                    }`}
                  >
                    {meter.status}
                  </span>
                </td>
                <td className="py-3 px-4">{new Date(meter.lastReading).toLocaleString()}</td>
                <td className="py-3 px-4 cursor-pointer text-purple-500 hover:text-purple-400">
                  ⋮
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Pagination */}
      <div className="flex justify-center items-center mt-6 gap-2">
        <button
          onClick={() => handlePageChange(currentPage - 1)}
          disabled={currentPage === 1}
          className={`px-4 py-2 rounded-lg font-medium transition ${
            darkMode
              ? "bg-purple-700 text-white disabled:bg-purple-900/40 hover:bg-purple-600"
              : "bg-indigo-200 text-indigo-900 disabled:bg-indigo-100 hover:bg-indigo-300"
          }`}
        >
          ← Previous
        </button>

        {[...Array(totalPages).keys()].map((i) => (
          <button
            key={i}
            onClick={() => handlePageChange(i + 1)}
            className={`px-3 py-1 rounded-lg font-medium transition ${
              currentPage === i + 1
                ? darkMode
                  ? "bg-purple-600 text-white"
                  : "bg-indigo-600 text-white"
                : darkMode
                  ? "bg-slate-700 text-purple-300 hover:bg-purple-600"
                  : "bg-indigo-100 text-indigo-800 hover:bg-indigo-300"
            }`}
          >
            {i + 1}
          </button>
        ))}

        <button
          onClick={() => handlePageChange(currentPage + 1)}
          disabled={currentPage === totalPages}
          className={`px-4 py-2 rounded-lg font-medium transition ${
            darkMode
              ? "bg-purple-700 text-white disabled:bg-purple-900/40 hover:bg-purple-600"
              : "bg-indigo-200 text-indigo-900 disabled:bg-indigo-100 hover:bg-indigo-300"
          }`}
        >
          Next →
        </button>
      </div>
    </div>
  );
};

export default MeterManagement;
