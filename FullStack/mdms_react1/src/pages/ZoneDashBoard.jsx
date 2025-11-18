// src/pages/ZoneDashboard.jsx
import React, { useContext } from "react";
import DashboardCard from "../components/ZonePage_Components/DashboardCard.jsx";
import AnalyticsChart from "../components/ZonePage_Components/AnalyticsChart.jsx";
import ButtonsPanel from "../components/ZonePage_Components/ButtonsPanel.jsx";
import Button from "../components/Button.jsx";
import { FiActivity, FiTrendingUp, FiAlertCircle } from "react-icons/fi";
import { DarkModeContext } from "../Layout/ZoneDashboardLayout.jsx";

const ZoneDashboard = () => {
  const { darkMode } = useContext(DarkModeContext);

  return (
    <div
      className={`min-h-screen ml-64 ${
        darkMode
          ? "bg-gradient-to-br from-slate-900 via-purple-900 to-slate-900"
          : "bg-gradient-to-br from-indigo-50 via-white to-purple-50"
      }`}
    >
      <div className="relative py-8 px-6 md:px-12 max-w-[1200px] mx-auto">
        {/* Decorative background elements */}
        <div className="absolute inset-0 overflow-hidden pointer-events-none z-0">
          <div
            className={`absolute top-20 right-20 w-96 h-96 rounded-full blur-3xl opacity-20 ${
              darkMode ? "bg-purple-500" : "bg-indigo-400"
            }`}
          ></div>
          <div
            className={`absolute bottom-20 left-20 w-96 h-96 rounded-full blur-3xl opacity-20 ${
              darkMode ? "bg-blue-500" : "bg-purple-400"
            }`}
          ></div>
        </div>

        {/* Header Section */}
        <div className="mb-8 relative z-10">
          <h1
            className={`text-3xl font-bold mb-2 bg-gradient-to-r ${
              darkMode ? "from-purple-400 to-pink-400" : "from-indigo-600 to-purple-600"
            } bg-clip-text text-transparent`}
          >
            Zone Dashboard
          </h1>
          <p className={`text-sm ${darkMode ? "text-gray-300" : "text-gray-600"}`}>
            Monitor and manage your zone metrics in real-time
          </p>
        </div>

        {/* Dashboard Cards */}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-5 mb-8 relative z-10">
          <div className="transform transition-all duration-300 hover:scale-105 hover:shadow-2xl hover:-translate-y-1">
            <DashboardCard icon={<FiActivity />} number="256" label="Active Meters" />
          </div>
          <div className="transform transition-all duration-300 hover:scale-105 hover:shadow-2xl hover:-translate-y-1">
            <DashboardCard icon={<FiTrendingUp />} number="55%" label="Avg Usage" />
          </div>
          <div className="transform transition-all duration-300 hover:scale-105 hover:shadow-2xl hover:-translate-y-1">
            <DashboardCard icon={<FiAlertCircle />} number="26" label="Pending Alerts" />
          </div>
        </div>

        {/* Analytics Chart */}
        <div
          className={`p-5 rounded-2xl shadow-2xl mb-8 backdrop-blur-xl transition-all duration-300 max-w-[700px] relative z-10 ${
            darkMode
              ? "bg-slate-800/80 border border-purple-500/20"
              : "bg-white/90 border border-indigo-100 shadow-indigo-100/50"
          }`}
        >
          <div className="flex flex-col sm:flex-row sm:justify-between sm:items-center mb-4 gap-3">
            <div>
              <h2
                className={`text-lg font-bold mb-1 ${
                  darkMode
                    ? "text-transparent bg-gradient-to-r from-purple-400 to-pink-400 bg-clip-text"
                    : "text-gray-800"
                }`}
              >
                Analytics Chart
              </h2>
              <p className={`text-xs ${darkMode ? "text-gray-400" : "text-gray-500"}`}>
                Track your performance over time
              </p>
            </div>
            <div className="flex gap-2">
              <Button
                label="Week"
                className={`w-[75px] h-[32px] text-xs font-medium rounded-lg shadow-lg hover:shadow-xl transition-all duration-300 ${
                  darkMode
                    ? "bg-gradient-to-r from-purple-600 to-pink-600 text-white hover:from-purple-700 hover:to-pink-700"
                    : "bg-gradient-to-r from-indigo-600 to-purple-600 text-white hover:from-indigo-700 hover:to-purple-700"
                }`}
              />
              <Button
                label="Month"
                className={`w-[75px] h-[32px] text-xs font-medium rounded-lg transition-all duration-300 ${
                  darkMode
                    ? "bg-slate-700 text-gray-300 hover:bg-slate-600 border border-slate-600"
                    : "bg-gray-100 text-gray-700 hover:bg-gray-200 border border-gray-200"
                }`}
              />
            </div>
          </div>

          <div
            className={`rounded-xl p-3 h-[250px] ${
              darkMode ? "bg-slate-900/50 border border-purple-500/10" : "bg-indigo-50/50 border border-indigo-100"
            }`}
          >
            <AnalyticsChart />
          </div>
        </div>

        {/* Buttons Panel */}
        <div
          className={`rounded-2xl shadow-2xl backdrop-blur-xl transition-all duration-300 relative z-10 ${
            darkMode
              ? "bg-slate-800/80 border border-purple-500/20"
              : "bg-white/90 border border-indigo-100 shadow-indigo-100/50"
          }`}
        >
          <ButtonsPanel />
        </div>
      </div>
    </div>
  );
};

export default ZoneDashboard;
