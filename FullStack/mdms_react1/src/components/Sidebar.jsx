import React from "react";
import { Link, useLocation } from "react-router-dom";
import { Home, FileText, Database, Bell, UserCog, ClipboardList } from "lucide-react";

export default function Sidebar() {
  const location = useLocation();

  const linkClasses = (path) =>
    `px-4 py-2 rounded-lg flex items-center gap-2 font-medium transition-all duration-300 ${
      location.pathname === path
        ? "bg-green-700 text-white shadow-md"
        : "text-gray-800 hover:bg-green-100 hover:text-green-800 dark:text-gray-200 dark:hover:bg-green-900"
    }`;

  return (
    <aside className="w-64 bg-green-50 dark:bg-gray-900 border-r border-green-200 h-screen flex-shrink-0">
      <nav className="flex flex-col p-4 space-y-3">
        <Link to="/dashboard" className={linkClasses("/dashboard")}>
          <Home size={18} /> <span className="font-semibold">Dashboard</span>
        </Link>
        <Link to="/bills" className={linkClasses("/bills")}>
          <FileText size={18} /> Bills & Payments
        </Link>
        <Link to="/meter-data" className={linkClasses("/meter-data")}>
          <Database size={18} /> Meter Data
        </Link>
        <Link to="/alerts" className={linkClasses("/alerts")}>
          <Bell size={18} /> Alerts & Notifications
        </Link>
        <Link to="/profile" className={linkClasses("/profile")}>
          <UserCog size={18} /> Profile & Settings
        </Link>
        <Link to="#" className={linkClasses("#")}>
          <ClipboardList size={18} /> Logs
        </Link>
      </nav>
    </aside>
  );
}
