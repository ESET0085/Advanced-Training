import React from "react";

const DashboardCard = ({ icon, number, label, color }) => {
  return (
    <div className="flex flex-col justify-center items-center w-64 h-32 bg-[#F4EFE6] dark:bg-gray-800 border border-gray-200 dark:border-gray-700 rounded-xl shadow-md transition-all duration-300 hover:shadow-lg hover:scale-[1.03] cursor-pointer">
      {/* Icon with soft background circle */}
      <div
        className={`flex items-center justify-center w-12 h-12 rounded-full mb-2 transition-colors duration-300 ${color} bg-opacity-20`}
      >
        {icon}
      </div>

      {/* Number */}
      <div className="text-2xl md:text-3xl font-bold text-gray-800 dark:text-gray-100">
        {number}
      </div>

      {/* Label */}
      <div className="text-gray-600 dark:text-gray-400 text-sm md:text-base">
        {label}
      </div>
    </div>
  );
};

export default DashboardCard;
