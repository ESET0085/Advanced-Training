import React from "react";
import { ToastContainer, toast, Slide } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

// Brown Theme Palette
const COLORS = {
  activeLight: "#F8F1E7",
  alertLight: "#F3E9DD",
  activeDark: "#4A3F35",
  alertDark: "#B33A3A",
  border: "#D7C3AE",
  card: "#FFF8F0",
  bgGradientFrom: "#F3E9DD",
  bgGradientTo: "#F8F1E7",
};

const zones = [
  { name: "Zone A", status: "active" },
  { name: "Zone B", status: "active" },
  { name: "Zone C", status: "alert" },
  { name: "Zone D", status: "active" },
  { name: "Zone E", status: "alert" },
  { name: "Zone F", status: "active" },
];

const TOAST_CONFIG = {
  alert: {
    type: "error",
    message: (name) => `${name} has a critical alert!`,
    style: {
      background: `linear-gradient(135deg, ${COLORS.alertLight}, #F9E0D9)`,
      color: COLORS.alertDark,
      borderRadius: "16px",
      border: `1px solid ${COLORS.border}`,
      fontSize: "14px",
      fontWeight: "500",
      boxShadow: "0 8px 24px rgba(179, 58, 58, 0.12)",
    },
    progressStyle: { background: `linear-gradient(90deg, #C05030 0%, #B33A3A 100%)` },
  },
  active: {
    type: "info",
    message: (name) => `${name} is operating normally`,
    style: {
      background: `linear-gradient(135deg, ${COLORS.activeLight}, #FDF8F3)`,
      color: COLORS.activeDark,
      borderRadius: "16px",
      border: `1px solid ${COLORS.border}`,
      fontSize: "14px",
      fontWeight: "500",
      boxShadow: "0 8px 24px rgba(74, 63, 53, 0.12)",
    },
    progressStyle: { background: `linear-gradient(90deg, #A67C52 0%, #4A3F35 100%)` },
  },
};

const MapSection = () => {
  const handleZoneClick = (zone) => {
    const config = TOAST_CONFIG[zone.status];
    toast[config.type](config.message(zone.name), {
      position: "top-right",
      autoClose: 2500,
      transition: Slide,
      style: config.style,
      progressStyle: config.progressStyle,
    });
  };

  return (
    <div
      className="relative w-full h-72 md:h-80 lg:h-96 rounded-2xl overflow-hidden transition-all duration-500 shadow-xl hover:shadow-2xl"
      style={{
        background: `linear-gradient(to bottom right, ${COLORS.bgGradientFrom}, ${COLORS.bgGradientTo})`,
        border: `1px solid ${COLORS.border}`,
      }}
    >
      <ToastContainer closeOnClick pauseOnHover draggable={false} limit={3} />

      {/* Subtle Decorative Overlay */}
      <div className="absolute inset-0 opacity-40">
        <div
          className="absolute top-10 left-10 w-32 h-32 rounded-full blur-3xl"
          style={{ background: "#D7C3AE" }}
        ></div>
        <div
          className="absolute bottom-10 right-10 w-40 h-40 rounded-full blur-3xl"
          style={{ background: "#A67C52" }}
        ></div>
      </div>

      {/* Header */}
      <div
        className="relative backdrop-blur-sm p-5 border-b flex justify-between items-center"
        style={{
          backgroundColor: "rgba(255, 248, 240, 0.6)",
          borderColor: COLORS.border,
        }}
      >
        <div className="flex items-center gap-3">
          <div
            className="w-2 h-2 rounded-full animate-pulse"
            style={{ backgroundColor: COLORS.activeDark }}
          ></div>
          <h3
            className="text-lg font-bold tracking-wide"
            style={{
              color: COLORS.activeDark,
              backgroundImage: `linear-gradient(to right, ${COLORS.activeDark}, ${COLORS.accent || "#A67C52"})`,
              WebkitBackgroundClip: "text",
              color: "transparent",
            }}
          >
            Mangalore Zone Map
          </h3>
        </div>
        <span
          className="text-xs font-medium px-3 py-1 rounded-full border"
          style={{
            background: `${COLORS.card}`,
            color: COLORS.activeDark,
            borderColor: COLORS.border,
          }}
        >
          Live Overview
        </span>
      </div>

      {/* Zone Grid */}
      <div className="relative grid grid-cols-3 gap-3 p-5 h-[calc(100%-4rem)]">
        {zones.map((zone, idx) => {
          const isAlert = zone.status === "alert";
          return (
            <div
              key={idx}
              onClick={() => handleZoneClick(zone)}
              className={`group relative flex flex-col justify-center items-center rounded-2xl p-4 cursor-pointer transition-all duration-300 hover:scale-105 hover:-translate-y-1`}
              style={{
                background: isAlert
                  ? `linear-gradient(to bottom right, #F9E0D9, #F4C7B5)`
                  : `linear-gradient(to bottom right, #FDF8F3, #F8F1E7)`,
                border: `1px solid ${COLORS.border}`,
                boxShadow: isAlert
                  ? "0 4px 12px rgba(179, 58, 58, 0.25)"
                  : "0 4px 12px rgba(74, 63, 53, 0.2)",
              }}
            >
              {/* Status indicator */}
              <div className="relative mb-2">
                <span
                  className="block w-5 h-5 rounded-full shadow-lg"
                  style={{
                    background: isAlert
                      ? "linear-gradient(to bottom right, #C05030, #B33A3A)"
                      : "linear-gradient(to bottom right, #A67C52, #4A3F35)",
                    animation: isAlert ? "pulse 1.5s infinite" : "none",
                  }}
                ></span>
              </div>

              {/* Zone name */}
              <p
                className="text-sm font-semibold tracking-wide"
                style={{ color: isAlert ? COLORS.alertDark : COLORS.activeDark }}
              >
                {zone.name}
              </p>

              {/* Status badge */}
              <span
                className="mt-1 text-xs font-medium px-2 py-0.5 rounded-full"
                style={{
                  background: isAlert ? "#FCE6E2" : "#F8F1E7",
                  color: isAlert ? COLORS.alertDark : COLORS.activeDark,
                  border: `1px solid ${COLORS.border}`,
                }}
              >
                {isAlert ? "Alert" : "Active"}
              </span>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default MapSection;
