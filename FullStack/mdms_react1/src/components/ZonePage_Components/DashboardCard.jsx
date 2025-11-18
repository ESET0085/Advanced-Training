import React, { useContext } from "react";
import { DarkModeContext } from "../../Layout/ZoneDashboardLayout.jsx";

const DashboardCard = ({ icon, number, label }) => {
  const { darkMode } = useContext(DarkModeContext);

  return (
    <div
      className={`flex flex-col items-center justify-center w-64 h-32 shadow rounded p-4
        ${darkMode ? "bg-gray-800 text-gray-100" : "bg-white text-gray-900"}`}
    >
      <div className="text-2xl mb-2">{icon}</div>
      <div className="text-xl font-bold">{number}</div>
      <div className={`${darkMode ? "text-gray-300" : "text-gray-500"}`}>{label}</div>
    </div>
  );
};

export default DashboardCard;
