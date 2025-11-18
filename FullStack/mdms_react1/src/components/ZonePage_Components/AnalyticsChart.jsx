import React, { useContext } from "react";
import { Line } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";
import { DarkModeContext } from "../../Layout/ZoneDashboardLayout.jsx";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

const AnalyticsChart = () => {
  const { darkMode } = useContext(DarkModeContext);

  const data = {
    labels: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
    datasets: [
      {
        label: "Usage",
        data: [320, 340, 180, 220, 360, 380, 300],
        borderColor: darkMode ? "#a78bfa" : "#7c3aed",
        backgroundColor: darkMode ? "rgba(167, 139, 250, 0.2)" : "rgba(199, 210, 254, 0.2)",
        tension: 0.4,
      },
    ],
  };

  const options = {
    responsive: true,
    plugins: {
      legend: {
        display: false,
        labels: {
          color: darkMode ? "#e5e7eb" : "#111827", // legend text color
        },
      },
      tooltip: {
        titleColor: darkMode ? "#f9fafb" : "#111827",
        bodyColor: darkMode ? "#f9fafb" : "#111827",
      },
    },
    scales: {
      x: {
        ticks: {
          color: darkMode ? "#d1d5db" : "#111827",
        },
        grid: {
          color: darkMode ? "#374151" : "#e5e7eb",
        },
      },
      y: {
        ticks: {
          color: darkMode ? "#d1d5db" : "#111827",
        },
        grid: {
          color: darkMode ? "#374151" : "#e5e7eb",
        },
      },
    },
  };

  return <Line data={data} options={options} />;
};

export default AnalyticsChart;
