import React, { useState, useEffect, createContext } from "react";
import { useNavigate } from "react-router-dom";
import Header from "./Header.jsx";
import Sidebar from "../components/ZonePage_Components/Sidebar.jsx";

export const DarkModeContext = createContext();

const ZoneDashboardLayout = ({ children }) => {
  const navigate = useNavigate();
  const [darkMode, setDarkMode] = useState(false);

  // Load saved dark mode from localStorage
  useEffect(() => {
    const savedMode = localStorage.getItem("zoneDarkMode") === "true";
    setDarkMode(savedMode);
  }, []);

  // Apply dark mode class to <html>
  useEffect(() => {
    const root = document.documentElement;
    if (darkMode) root.classList.add("dark");
    else root.classList.remove("dark");
    localStorage.setItem("zoneDarkMode", darkMode);
  }, [darkMode]);

  const handleLogout = () => navigate("/");

  const toggleDarkMode = () => setDarkMode(prev => !prev);

  return (
    <DarkModeContext.Provider value={{ darkMode, toggleDarkMode }}>
      <div className="min-h-screen flex flex-col bg-gray-100 dark:bg-gray-900">
        <Header darkMode={darkMode} toggleDarkMode={toggleDarkMode} onLogout={handleLogout} />
        <div className="flex flex-1 w-full">
          <Sidebar darkMode={darkMode} />
          <main className="flex-1 p-6 overflow-auto">
            {children}
          </main>
        </div>
      </div>
    </DarkModeContext.Provider>
  );
};

export default ZoneDashboardLayout;
