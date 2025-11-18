import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Header from "../Layout/Header.jsx";
import Sidebar from "../components/Sidebar.jsx";

const DashboardLayout = ({ children }) => {
  const navigate = useNavigate();
  const [darkMode, setDarkMode] = useState(false);

  useEffect(() => {
    const savedMode = localStorage.getItem("darkMode") === "true";
    setDarkMode(savedMode);
  }, []);

  useEffect(() => {
    const root = window.document.documentElement;
    if (darkMode) root.classList.add("dark");
    else root.classList.remove("dark");
    localStorage.setItem("darkMode", darkMode);
  }, [darkMode]);

  const handleLogout = () => navigate("/");

  return (
    <div className="min-h-screen bg-[#F4EFE6] dark:bg-gray-900 flex flex-col">
      {/* Header in normal flow */}
      <Header
        darkMode={darkMode}
        toggleDarkMode={() => setDarkMode(!darkMode)}
        onLogout={handleLogout}
      />

      {/* Sidebar + main content */}
      <div className="flex flex-1 w-full">
        {/* Sidebar naturally takes width */}
        <Sidebar darkMode={darkMode} />

        {/* Main content takes remaining space */}
        <main className="flex-1 p-6 overflow-y-auto text-gray-900 dark:text-gray-100">
          {children}
        </main>
      </div>
    </div>
  );
};

export default DashboardLayout;
