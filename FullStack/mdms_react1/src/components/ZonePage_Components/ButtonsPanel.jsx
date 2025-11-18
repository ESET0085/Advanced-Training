import React, { useContext } from "react";
import Button from "../Button.jsx"; // fixed path
import { DarkModeContext } from "../../Layout/ZoneDashboardLayout.jsx";

const ButtonsPanel = () => {
  const { darkMode } = useContext(DarkModeContext);

  return (
    <div className="flex gap-4 mt-6">
      <Button
        label="+ Add Meter"
        className={`flex-1 py-2 px-4 rounded hover:brightness-90
          ${darkMode ? "bg-purple-600 text-white" : "bg-purple-500 text-white"}`}
      />
      <Button
        label="Generate Report"
        className={`flex-1 py-2 px-4 rounded hover:brightness-90
          ${darkMode ? "bg-gray-700 text-gray-100" : "bg-gray-200 text-gray-800"}`}
      />
    </div>
  );
};

export default ButtonsPanel;
