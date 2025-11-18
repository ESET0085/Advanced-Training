import React from "react";
import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";

// Sample datasets for different periods
const chartDataSets = {
  Day: [
    { time: "12 AM", value: 5 },
    { time: "4 AM", value: 8 },
    { time: "8 AM", value: 12 },
    { time: "12 PM", value: 9 },
    { time: "4 PM", value: 14 },
    { time: "8 PM", value: 10 },
    { time: "12 AM", value: 7 },
  ],
  Week: [
    { day: "Mon", value: 45 },
    { day: "Tue", value: 38 },
    { day: "Wed", value: 52 },
    { day: "Thu", value: 60 },
    { day: "Fri", value: 48 },
    { day: "Sat", value: 55 },
    { day: "Sun", value: 50 },
  ],
  Month: [
    { date: "1 Oct", value: 200 },
    { date: "5 Oct", value: 180 },
    { date: "10 Oct", value: 220 },
    { date: "15 Oct", value: 250 },
    { date: "20 Oct", value: 210 },
    { date: "25 Oct", value: 230 },
    { date: "30 Oct", value: 240 },
  ],
};

const LineChartComponent = ({ period = "Day" }) => {
  const data = chartDataSets[period];

  // Determine the X-axis key dynamically
  const xKey = period === "Day" ? "time" : period === "Week" ? "day" : "date";

  return (
    <div className="w-full h-64">
      <ResponsiveContainer width="100%" height="100%">
        <LineChart data={data} margin={{ top: 10, right: 30, left: 0, bottom: 0 }}>
          <CartesianGrid strokeDasharray="3 3" />
          <XAxis dataKey={xKey} stroke="#555" />
          <YAxis stroke="#555" />
          <Tooltip />
          <Line
            type="monotone"
            dataKey="value"
            stroke="#3B82F6"
            strokeWidth={2}
            dot={{ r: 4 }}
            activeDot={{ r: 6 }}
          />
        </LineChart>
      </ResponsiveContainer>
    </div>
  );
};

export default LineChartComponent;
