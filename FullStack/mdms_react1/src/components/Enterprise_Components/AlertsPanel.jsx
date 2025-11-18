import React from "react";

const COLORS = {
  activeLight: "#F8F1E7",
  alertLight: "#F3E9DD",
  activeDark: "#4A3F35",
  alertDark: "#B33A3A",
  border: "#D7C3AE",
  card: "#FFF8F0",
};

const alerts = [
  {
    title: "Meter Overload",
    desc: "Usage exceeded the safe limit.",
    type: "Critical",
    time: "2 min ago",
  },
  {
    title: "Communication Lost",
    desc: "Meter not responding for 2 hours.",
    type: "Warning",
    time: "10 min ago",
  },
  {
    title: "Routine Check",
    desc: "Scheduled maintenance pending.",
    type: "Info",
    time: "1 hour ago",
  },
];

// Brown theme equivalent colors for severity types
const TYPE_THEME = {
  Critical: {
    bar: "linear-gradient(to bottom, #C05030, #B33A3A)",
    badgeBg: "#FCE6E2",
    badgeText: "#B33A3A",
    shadow: "0 4px 12px rgba(179, 58, 58, 0.25)",
    cardBg: "linear-gradient(to bottom right, #F9E0D9, #F4C7B5)",
  },
  Warning: {
    bar: "linear-gradient(to bottom, #A67C52, #8C6B44)",
    badgeBg: "#F8F1E7",
    badgeText: "#4A3F35",
    shadow: "0 4px 12px rgba(74, 63, 53, 0.2)",
    cardBg: "linear-gradient(to bottom right, #FDF8F3, #F8F1E7)",
  },
  Info: {
    bar: "linear-gradient(to bottom, #D7C3AE, #A67C52)",
    badgeBg: "#FDF8F3",
    badgeText: "#4A3F35",
    shadow: "0 4px 12px rgba(74, 63, 53, 0.2)",
    cardBg: "linear-gradient(to bottom right, #FDF8F3, #F8F1E7)",
  },
};

const AlertsPanel = () => {
  return (
    <div className="flex flex-col gap-4">
      <h2
        className="text-lg md:text-xl font-semibold"
        style={{ color: COLORS.activeDark }}
      >
        Recent Alerts
      </h2>

      <div
        className="rounded-2xl p-4 space-y-3 shadow-xl"
        style={{
          background: `linear-gradient(to bottom right, ${COLORS.alertLight}, ${COLORS.activeLight})`,
          border: `1px solid ${COLORS.border}`,
        }}
      >
        {alerts.map((alert, idx) => {
          const theme = TYPE_THEME[alert.type];

          return (
            <div
              key={idx}
              className="flex items-start gap-4 p-4 rounded-2xl transition-all duration-300 cursor-pointer hover:scale-[1.01]"
              style={{
                background: theme.cardBg,
                border: `1px solid ${COLORS.border}`,
                boxShadow: theme.shadow,
              }}
            >
              {/* Severity bar */}
              <div
                className="w-2 rounded-full"
                style={{
                  background: theme.bar,
                }}
              ></div>

              {/* Content */}
              <div className="flex flex-col w-full">
                <div className="flex justify-between items-center">
                  <h3
                    className="font-bold text-sm md:text-base"
                    style={{ color: COLORS.activeDark }}
                  >
                    {alert.title}
                  </h3>

                  <span
                    className="text-xs"
                    style={{ color: COLORS.activeDark, opacity: 0.7 }}
                  >
                    {alert.time}
                  </span>
                </div>

                <p
                  className="text-sm mt-1"
                  style={{ color: COLORS.activeDark, opacity: 0.8 }}
                >
                  {alert.desc}
                </p>

                <span
                  className="mt-2 inline-block text-xs font-medium px-2 py-1 rounded-full"
                  style={{
                    background: theme.badgeBg,
                    color: theme.badgeText,
                    border: `1px solid ${COLORS.border}`,
                  }}
                >
                  {alert.type}
                </span>
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default AlertsPanel;
