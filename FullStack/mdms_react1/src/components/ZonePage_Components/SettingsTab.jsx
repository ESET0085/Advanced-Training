import React, { useState } from "react";
import Button from "../Button.jsx";

const SettingsTab = () => {
  const [highThreshold, setHighThreshold] = useState(600);
  const [lowThreshold, setLowThreshold] = useState(200);
  const [frequency, setFrequency] = useState(6);
  const [inactiveDay, setInactiveDay] = useState("Sunday");

  return (
    <div className="flex flex-col gap-10 w-full max-w-3xl mx-auto">
      {/* Thresholds */}
      <div className="grid grid-cols-2 gap-12">
        <div className="bg-gray-50 rounded-2xl shadow-sm p-6">
          <p className="text-sm font-medium mb-2">
            High Consumption Threshold (kWh)
          </p>
          <input
            type="range"
            min="0"
            max="1000"
            value={highThreshold}
            onChange={(e) => setHighThreshold(e.target.value)}
            className="w-full accent-indigo-500"
          />
          <div className="flex justify-between text-xs text-gray-500 mt-1">
            <span>0</span>
            <span>{highThreshold}</span>
            <span>1000</span>
          </div>
        </div>

        <div className="bg-gray-50 rounded-2xl shadow-sm p-6">
          <p className="text-sm font-medium mb-2">
            Low Consumption Threshold (kWh)
          </p>
          <input
            type="range"
            min="0"
            max="1000"
            value={lowThreshold}
            onChange={(e) => setLowThreshold(e.target.value)}
            className="w-full accent-indigo-500"
          />
          <div className="flex justify-between text-xs text-gray-500 mt-1">
            <span>0</span>
            <span>{lowThreshold}</span>
            <span>1000</span>
          </div>
        </div>
      </div>

      {/* Frequency + Inactive Duration */}
      <div className="grid grid-cols-2 gap-12">
        <div className="bg-gray-50 rounded-2xl shadow-sm p-6">
          <p className="text-sm font-medium mb-2">
            Abnormal Reading Frequency (hours)
          </p>
          <input
            type="range"
            min="0"
            max="10"
            value={frequency}
            onChange={(e) => setFrequency(e.target.value)}
            className="w-full accent-indigo-500"
          />
          <div className="flex justify-between text-xs text-gray-500 mt-1">
            <span>0</span>
            <span>{frequency}</span>
            <span>10</span>
          </div>
        </div>

        <div className="bg-gray-50 rounded-2xl shadow-sm p-6 flex flex-col gap-3">
          <p className="text-sm font-medium mb-2">Inactive Meters Duration</p>
          <select
            value={inactiveDay}
            onChange={(e) => setInactiveDay(e.target.value)}
            className="border border-gray-300 rounded-xl p-2 text-sm focus:outline-none"
          >
            <option>Sunday</option>
            <option>Monday</option>
            <option>Tuesday</option>
            <option>Wednesday</option>
            <option>Thursday</option>
            <option>Friday</option>
            <option>Saturday</option>
          </select>
        </div>
      </div>

      {/* Centered Save Button */}
      <div className="flex justify-center w-full mt-8">
        <button
  type="button"
  className="bg-indigo-600 hover:bg-indigo-700 text-white font-medium py-2 px-6 rounded-lg shadow-md transition-all duration-200 hover:scale-105 focus:outline-none focus:ring-2 focus:ring-indigo-400 focus:ring-opacity-50"
>
  Save & Continue
</button>

      </div>
    </div>
  );
};

export default SettingsTab;
