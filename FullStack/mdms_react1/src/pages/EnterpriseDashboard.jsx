// src/pages/EnterpriseDashboard.jsx
import React from "react";
import { BarChart2, Activity, AlertTriangle } from "lucide-react";
import DashboardCard from "../components/Enterprise_Components/DashboardCard.jsx";
import MapSection from "../components/Enterprise_Components/MapSection.jsx";
import AlertsPanel from "../components/Enterprise_Components/AlertsPanel.jsx";

// Brown Theme Palette
const COLORS = {
  bgGradientFrom: "#F3E9DD",
  bgGradientTo: "#F8F1E7",
  text: "#4A3F35",
  card: "#FFF8F0",
  border: "#D7C3AE",
  shadow: "rgba(74, 63, 53, 0.2)",
  accent1: "#A67C52",
  accent2: "#4A3F35",
};

const EnterpriseDashboard = () => {
  return (
    <div
      className="ml-64 p-6 min-h-screen space-y-10 transition-colors duration-300"
      style={{
        background: `linear-gradient(to bottom right, ${COLORS.bgGradientFrom}, ${COLORS.bgGradientTo})`,
        color: COLORS.text,
      }}
    >
      {/* Page Title */}
      <h1
        className="text-3xl md:text-4xl font-semibold mb-6 tracking-wide"
        style={{ color: COLORS.text }}
      >
        Enterprise Dashboard
      </h1>

      {/* --- Top Stats Cards --- */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
        <DashboardCard
          icon={<BarChart2 size={28} color={COLORS.accent2} />}
          number="256"
          label="Total Zones"
          color={COLORS.accent2}
          style={{
            backgroundColor: COLORS.card,
            border: `1px solid ${COLORS.border}`,
            boxShadow: `0 4px 8px ${COLORS.shadow}`,
          }}
        />

        <DashboardCard
          icon={<Activity size={28} color={COLORS.accent1} />}
          number="55"
          label="Total Meters"
          color={COLORS.accent1}
          style={{
            backgroundColor: COLORS.card,
            border: `1px solid ${COLORS.border}`,
            boxShadow: `0 4px 8px ${COLORS.shadow}`,
          }}
        />

        <DashboardCard
          icon={<AlertTriangle size={28} color="#B33A3A" />}
          number="26"
          label="Critical Alerts"
          color="#B33A3A"
          style={{
            backgroundColor: COLORS.card,
            border: `1px solid ${COLORS.border}`,
            boxShadow: `0 4px 8px ${COLORS.shadow}`,
          }}
        />
      </div>

      {/* --- Map + Alerts Section --- */}
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        {/* Map Section */}
        <div
          className="p-4 rounded-lg shadow-md hover:shadow-lg transition-all duration-300 transform hover:scale-[1.02]"
          style={{
            backgroundColor: COLORS.card,
            border: `1px solid ${COLORS.border}`,
            boxShadow: `0 4px 8px ${COLORS.shadow}`,
          }}
        >
          <MapSection />
        </div>

        {/* Alerts Panel */}
        <div
          className="p-4 rounded-lg shadow-md hover:shadow-lg transition-all duration-300 transform hover:scale-[1.02]"
          style={{
            backgroundColor: COLORS.card,
            border: `1px solid ${COLORS.border}`,
            boxShadow: `0 4px 8px ${COLORS.shadow}`,
          }}
        >
          <AlertsPanel />
        </div>
      </div>
    </div>
  );
};

export default EnterpriseDashboard;
