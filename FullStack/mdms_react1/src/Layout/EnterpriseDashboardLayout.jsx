import React, { useState, useEffect, createContext } from "react";
import { useNavigate } from "react-router-dom";
import Header from "./Header.jsx";
import EnterpriseSidebar from "../components/Enterprise_Components/EnterpriseSidebar.jsx";

export const EnterpriseDarkModeContext = createContext();

const EnterpriseDashboardLayout = ({ children }) => {
  const navigate = useNavigate();
  const [darkMode, setDarkMode] = useState(false);

  // Load from localStorage
  useEffect(() => {
    const savedMode = localStorage.getItem("enterpriseDarkMode") === "true";
    setDarkMode(savedMode);
  }, []);

  // Apply + save mode
  useEffect(() => {
    const root = document.documentElement;
    if (darkMode) root.classList.add("dark");
    else root.classList.remove("dark");
    localStorage.setItem("enterpriseDarkMode", darkMode);
  }, [darkMode]);

  const handleLogout = () => navigate("/");
  const toggleDarkMode = () => setDarkMode((prev) => !prev);

  return (
    <EnterpriseDarkModeContext.Provider value={{ darkMode, toggleDarkMode }}>
      <div className="min-h-screen flex flex-col bg-[#F4EFE6] dark:bg-gray-900 transition-colors duration-300">
        {/* Header */}
        <Header
          darkMode={darkMode}
          toggleDarkMode={toggleDarkMode}
          onLogout={handleLogout}
        />

        {/* Sidebar + Content */}
        <div className="flex flex-1">
          <EnterpriseSidebar darkMode={darkMode} />
          <main className="flex-1 p-8 text-gray-900 dark:text-gray-100 overflow-y-auto transition-all duration-300 scroll-smooth">
            {children}
          </main>
        </div>
      </div>
    </EnterpriseDarkModeContext.Provider>
  );
};

export default EnterpriseDashboardLayout;
