import React from "react";
import { Moon } from "lucide-react";

export default function Header({ darkMode, toggleDarkMode, onLogout }) {
  return (
    <header className="w-full bg-gray-100 dark:bg-gray-800 shadow-sm flex justify-between items-center px-6 py-3 border-b border-gray-300 dark:border-gray-700">
      {/* Left section */}
      <div className="flex items-center">
        <h1 className="text-2xl font-semibold text-gray-800 dark:text-gray-100 tracking-wide">
          MDMS
        </h1>
      </div>

      {/* Right section */}
      <div className="flex items-center space-x-4">
        {/* Dark mode toggle */}
        <Moon
          className="w-5 h-5 text-gray-600 hover:text-gray-800 dark:text-gray-300 dark:hover:text-white cursor-pointer"
          onClick={toggleDarkMode}
        />

        {/* Logout button */}
        <button
          className="bg-red-500 text-white px-4 py-1 rounded-lg hover:bg-red-600 transition"
          onClick={onLogout}
        >
          Logout
        </button>
      </div>
    </header>
  );
}
