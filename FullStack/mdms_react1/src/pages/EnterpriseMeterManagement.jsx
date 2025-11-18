import React, { useState } from "react";
import { MoreVertical, Edit2, Trash2, Search } from "lucide-react";
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from "recharts";

const COLORS = {
  bg: "#4A3F35",
  border: "#D7C3AE",
  text: "#4A3F35",
  card: "#F8F1E7",
  headerText: "#4A3F35",
  buttonBg: "#4A3F35",
  buttonText: "#F3E9DD",
  activeStatus: "#4A3F35",
  inactiveStatus: "#A67C52",
  inputBg: "white",
  tooltipBg: "rgba(248, 241, 231, 0.98)"
};

const MeterManagement = () => {
  const [meters, setMeters] = useState([
    { id: 123, zone: "Mangalore", owner: "abc", status: "Active", lastReading: "2025-10-07T07:15:13Z" },
    { id: 124, zone: "Mangalore", owner: "xyz", status: "De-Activated", lastReading: "2025-10-07T07:15:13Z" },
    { id: 125, zone: "Baijpe", owner: "pqr", status: "Active", lastReading: "2025-10-07T07:15:13Z" },
    { id: 126, zone: "Hubli", owner: "def", status: "Active", lastReading: "2025-10-07T07:15:13Z" },
    { id: 127, zone: "Belgaum", owner: "ghi", status: "De-Activated", lastReading: "2025-10-07T07:15:13Z" },
  ]);

  const [openMenuId, setOpenMenuId] = useState(null);
  const [searchQuery, setSearchQuery] = useState("");

  const chartData = [
    { month: "Jan", Mangalore: 45, Baijpe: 55, Hubli: 62, Belgaum: 48 },
    { month: "Feb", Mangalore: 52, Baijpe: 48, Hubli: 58, Belgaum: 52 },
    { month: "Mar", Mangalore: 68, Baijpe: 62, Hubli: 65, Belgaum: 58 },
    { month: "Apr", Mangalore: 58, Baijpe: 55, Hubli: 72, Belgaum: 62 },
    { month: "May", Mangalore: 72, Baijpe: 68, Hubli: 78, Belgaum: 68 },
    { month: "Jun", Mangalore: 65, Baijpe: 72, Hubli: 85, Belgaum: 75 },
    { month: "Jul", Mangalore: 78, Baijpe: 65, Hubli: 72, Belgaum: 68 },
    { month: "Aug", Mangalore: 85, Baijpe: 78, Hubli: 88, Belgaum: 82 },
    { month: "Sep", Mangalore: 72, Baijpe: 68, Hubli: 75, Belgaum: 72 },
    { month: "Oct", Mangalore: 82, Baijpe: 75, Hubli: 82, Belgaum: 78 },
  ];

  const filteredMeters = meters.filter((m) =>
    m.owner.toLowerCase().includes(searchQuery.toLowerCase()) ||
    m.zone.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <div className="ml-64 p-8 min-h-screen" style={{ backgroundColor: COLORS.card, color: COLORS.text }}>
      {/* Page Header */}
      <h1 className="text-2xl font-semibold mb-6" style={{ color: COLORS.headerText }}>
        Global Meter Management
      </h1>

      {/* Filters Row */}
      <div className="flex items-center gap-4 mb-6">
        {/* Search */}
        <div className="relative flex-1">
          <input
            type="text"
            placeholder="Search by owner or zone…"
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            className="w-full px-10 py-2 rounded-lg focus:outline-none focus:ring-1 text-sm"
            style={{ backgroundColor: COLORS.inputBg, border: `1px solid ${COLORS.border}`, color: COLORS.text }}
          />
          <Search className="absolute top-2.5 left-3" size={20} style={{ color: COLORS.text }} />
        </div>
      </div>

      {/* Table Container */}
      <div
        className="overflow-hidden shadow-lg rounded-2xl mb-6"
        style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
      >
        <table className="w-full text-sm text-left">
          <thead>
            <tr style={{ backgroundColor: COLORS.bg, color: COLORS.buttonText }}>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Meter ID</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Zone</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Owner</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Status</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Last Reading</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Actions</th>
            </tr>
          </thead>

          <tbody>
            {filteredMeters.map((meter) => (
              <tr
                key={meter.id}
                style={{ borderBottom: `1px solid ${COLORS.border}` }}
                className="hover:opacity-80 transition"
              >
                <td className="px-6 py-3">{meter.id}</td>
                <td className="px-6 py-3 font-medium">{meter.zone}</td>
                <td className="px-6 py-3">{meter.owner}</td>

                <td className="px-6 py-3">
                  <span
                    className={`font-medium ${meter.status === "Active" ? "text-green-600" : "text-red-600"}`}
                  >
                    {meter.status}
                  </span>
                </td>

                <td className="px-6 py-3">{meter.lastReading}</td>

                <td className="px-6 py-3 relative">
                  <div
                    className="relative inline-block"
                    onMouseEnter={() => setOpenMenuId(meter.id)}
                    onMouseLeave={() => setOpenMenuId(null)}
                  >
                    <button className="p-2 rounded hover:opacity-70">
                      <MoreVertical size={18} />
                    </button>

                    {openMenuId === meter.id && (
                      <div
                        className="absolute right-0 mt-1 w-36 rounded-lg shadow-lg z-50"
                        style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
                      >
                        <button className="flex items-center gap-2 w-full px-4 py-2 text-sm hover:opacity-70">
                          <Edit2 size={14} /> Edit
                        </button>

                        <button
                          className="flex items-center gap-2 w-full px-4 py-2 text-sm hover:opacity-70 text-red-600"
                        >
                          <Trash2 size={14} /> Delete
                        </button>
                      </div>
                    )}
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        {/* Footer Pagination Placeholder */}
        <div className="px-6 py-4 text-center text-sm" style={{ color: COLORS.text, backgroundColor: COLORS.card }}>
          Showing {filteredMeters.length} records
        </div>
      </div>

      {/* Chart Section */}
      <div className="mt-8">
        <h2 className="text-xl font-semibold mb-4" style={{ color: COLORS.headerText }}>
          Energy Usage Trends by Zone
        </h2>
        <div
          className="shadow-lg rounded-xl border p-8"
          style={{ backgroundColor: COLORS.card, borderColor: COLORS.border }}
        >
          {/* Legend */}
          <div className="flex justify-center gap-6 mb-6 flex-wrap">
            {["Mangalore", "Baijpe", "Hubli", "Belgaum"].map((zone, idx) => {
              const colors = ["#9B7653", "#B8956A", "#D4B896", "#E8D5BD"];
              return (
                <div key={zone} className="flex items-center gap-2">
                  <div className="w-4 h-4 rounded" style={{ backgroundColor: colors[idx] }}></div>
                  <span className="text-sm font-medium" style={{ color: COLORS.text }}>{zone}</span>
                </div>
              );
            })}
          </div>

          <ResponsiveContainer width="100%" height={400}>
            <AreaChart
              data={chartData}
              margin={{ top: 10, right: 30, left: 0, bottom: 0 }}
            >
              <defs>
                {["Mangalore", "Baijpe", "Hubli", "Belgaum"].map((zone, idx) => {
                  const colors = ["#9B7653", "#B8956A", "#D4B896", "#E8D5BD"];
                  return (
                    <linearGradient key={zone} id={`color${zone}`} x1="0" y1="0" x2="0" y2="1">
                      <stop offset="5%" stopColor={colors[idx]} stopOpacity={0.8} />
                      <stop offset="95%" stopColor={colors[idx]} stopOpacity={0.1} />
                    </linearGradient>
                  );
                })}
              </defs>
              <CartesianGrid strokeDasharray="3 3" stroke={COLORS.border} opacity={0.3} />
              <XAxis dataKey="month" stroke={COLORS.text} tick={{ fill: COLORS.text }} axisLine={{ stroke: COLORS.border }} />
              <YAxis stroke={COLORS.text} tick={{ fill: COLORS.text }} axisLine={{ stroke: COLORS.border }} label={{ value: 'Energy (kWh)', angle: -90, position: 'insideLeft', style: { fill: COLORS.text, fontSize: '13px' } }} />
              <Tooltip
                contentStyle={{
                  backgroundColor: COLORS.tooltipBg,
                  border: `2px solid ${COLORS.border}`,
                  borderRadius: '12px',
                  boxShadow: '0 4px 12px rgba(0,0,0,0.1)',
                  padding: '12px'
                }}
                labelStyle={{ color: COLORS.text, fontWeight: 600, marginBottom: '8px' }}
                itemStyle={{ color: COLORS.text, padding: '4px 0' }}
              />
              {["Belgaum", "Hubli", "Baijpe", "Mangalore"].map((zone) => (
                <Area key={zone} type="monotone" dataKey={zone} stackId="1" stroke={chartData.find(d => d[zone]) ? COLORS.text : COLORS.border} strokeWidth={2} fill={`url(#color${zone})`} />
              ))}
            </AreaChart>
          </ResponsiveContainer>
          <div className="mt-6 text-center text-sm" style={{ color: COLORS.text, opacity: 0.7 }}>
            Monthly energy consumption trends across all zones (kWh)
          </div>
        </div>
      </div>
    </div>
  );
};

export default MeterManagement;
