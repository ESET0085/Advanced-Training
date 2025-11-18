import React from "react";
import { NavLink, useLocation } from "react-router-dom";

const Sidebar = () => {
  const location = useLocation();

  const linkClasses = (path) =>
    `py-2 px-3 rounded-lg transition-all duration-200 font-medium ${
      location.pathname === path
        ? "bg-purple-600 text-white"
        : "text-gray-700 hover:bg-gray-100 dark:text-gray-200 dark:hover:bg-gray-700"
    }`;

  return (
    <aside className="w-64 h-screen bg-white dark:bg-gray-800 border-r border-gray-300 flex flex-col p-5 gap-4 fixed top-0 left-0">
      {/* Sidebar Title */}
      <h2 className="text-2xl font-extrabold text-purple-700 dark:text-purple-400 tracking-wide mb-2">
        MDMS
      </h2>

      {/* Navigation Links */}
      <NavLink to="/zone-dashboard" className={linkClasses("/zone-dashboard")}>
        Dashboard
      </NavLink>

      <NavLink to="/meter-management" className={linkClasses("/meter-management")}>
        Meter Management
      </NavLink>

      <NavLink to="/user-management" className={linkClasses("/user-management")}>
        User Management
      </NavLink>

      <NavLink to="/reports" className={linkClasses("/reports")}>
        Reports & Analytics
      </NavLink>

      <NavLink to="/settings" className={linkClasses("/settings")}>
        Settings & Notifications
      </NavLink>
    </aside>
  );
};

export default Sidebar;
