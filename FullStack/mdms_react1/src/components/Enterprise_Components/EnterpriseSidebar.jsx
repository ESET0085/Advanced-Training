import React from "react";
import { useNavigate, useLocation } from "react-router-dom";

const COLORS = {
  bg: "#FFF8F0",          // Sidebar background
  text: "#4A3F35",        // Primary text color
  border: "#D7C3AE",      // Border color
  active: "#F3E9DD",      // Active menu background
  hover: "#F8F1E7",       // Hover background
};

const EnterpriseSidebar = () => {
  const navigate = useNavigate();
  const location = useLocation();

  const menuItems = [
    { label: "Dashboard", path: "/enterprise-dashboard" },
    { label: "Zone Management", path: "/enterprise-zone-management" },
    { label: "Meter Management", path: "/enterprise-meters" },
    { label: "User & Role Management", path: "/enterprise-user-role-management" },
    { label: "Audit Logs", path: "/enterprise-audit-logs" },
    { label: "Settings & Configuration", path: "/enterprise-settings" },
  ];

  return (
    <aside
      className="w-64 p-5 flex flex-col border-r transition-colors duration-300 fixed top-0 left-0 h-screen overflow-y-auto z-20"
      style={{
        backgroundColor: COLORS.bg,
        borderColor: COLORS.border,
        color: COLORS.text,
      }}
    >
      <h2 className="text-xl font-bold mb-6" style={{ color: COLORS.text }}>
        MDMS
      </h2>

      <nav className="flex flex-col gap-3">
        {menuItems.map((item) => {
          const isActive = location.pathname === item.path;

          return (
            <button
              key={item.path}
              onClick={() => navigate(item.path)}
              className="text-left px-3 py-2 rounded-lg font-medium transition-all duration-200"
              style={{
                backgroundColor: isActive ? COLORS.active : "transparent",
                color: COLORS.text,
                boxShadow: isActive ? "0 2px 6px rgba(74, 63, 53, 0.15)" : "none",
              }}
              onMouseOver={(e) => {
                if (!isActive) e.currentTarget.style.backgroundColor = COLORS.hover;
              }}
              onMouseOut={(e) => {
                if (!isActive) e.currentTarget.style.backgroundColor = "transparent";
              }}
            >
              {item.label}
            </button>
          );
        })}
      </nav>
    </aside>
  );
};

export default EnterpriseSidebar;
