import React, { useState, useEffect, useRef } from "react";
import { Search, Download, MoreVertical } from "lucide-react";

// COLOR THEME
const COLORS = {
  bg: "#F3E9DD",
  border: "#D7C3AE",
  text: "#4A3F35",
  card: "#F3E9DD",
  accent: "#B89F7A",
  headerText: "#4A3F35",
};

const EnterpriseAuditLogs = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [statusFilter, setStatusFilter] = useState("");
  const [showStatusDropdown, setShowStatusDropdown] = useState(false);
  const dropdownRef = useRef(null);

  const logsData = [
    { id: 1, user: "Admin", action: "Created Meter", status: "Success", date: "2025-02-01" },
    { id: 2, user: "John", action: "Updated Tariff", status: "Failed", date: "2025-02-02" },
    { id: 3, user: "Sarah", action: "Deleted Alert", status: "Success", date: "2025-02-03" },
    { id: 4, user: "Emma", action: "Added User", status: "Pending", date: "2025-02-04" },
  ];

  const filteredLogs = logsData.filter(
    (item) =>
      item.user.toLowerCase().includes(searchTerm.toLowerCase()) &&
      (statusFilter ? item.status === statusFilter : true)
  );

  useEffect(() => {
    function handleClickOutside(event) {
      if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
        setShowStatusDropdown(false);
      }
    }

    document.addEventListener("mousedown", handleClickOutside);
    return () => document.removeEventListener("mousedown", handleClickOutside);
  }, []);

  return (
    <div
      className="min-h-screen p-6 md:p-8"
      style={{
        backgroundColor: COLORS.bg,
        color: COLORS.text,
        marginLeft: "256px",
      }}
    >
      {/* Page Header */}
      <h1 className="text-2xl font-semibold mb-6" style={{ color: COLORS.headerText }}>
        Audit Logs
      </h1>

      {/* Search + Filter Row */}
      <div className="flex flex-wrap items-center gap-4 mb-6">
        {/* Search Bar */}
        <div className="relative flex-1 max-w-md">
          <input
            type="text"
            placeholder="Search by user..."
            className="w-full px-10 py-2 rounded-lg focus:outline-none focus:ring-1 text-sm"
            style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}`, color: COLORS.text }}
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <Search className="absolute top-2.5 left-3" size={20} style={{ color: COLORS.text }} />
        </div>

        {/* Status Dropdown */}
        <div className="relative" ref={dropdownRef}>
          <button
            className="px-4 py-2 rounded-lg flex items-center gap-2 text-sm hover:opacity-80 transition"
            style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
            onClick={() => setShowStatusDropdown(!showStatusDropdown)}
          >
            {statusFilter || "Status"}
            <MoreVertical size={16} color={COLORS.text} />
          </button>

          {showStatusDropdown && (
            <div
              className="absolute mt-2 w-40 rounded-lg p-2 z-10 shadow-lg"
              style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
            >
              {["Success", "Failed", "Pending"].map((status) => (
                <div
                  key={status}
                  className="px-3 py-2 rounded-lg cursor-pointer hover:opacity-75"
                  style={{ color: COLORS.text }}
                  onClick={() => {
                    setStatusFilter(status);
                    setShowStatusDropdown(false);
                  }}
                >
                  {status}
                </div>
              ))}

              {/* Clear Option */}
              <div
                className="px-3 py-2 text-red-500 cursor-pointer hover:opacity-75"
                onClick={() => {
                  setStatusFilter("");
                  setShowStatusDropdown(false);
                }}
              >
                Clear Filter
              </div>
            </div>
          )}
        </div>

        {/* Download Button */}
        <button
          className="px-4 py-2 rounded-lg flex items-center gap-2 text-sm hover:opacity-80 transition"
          style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
        >
          <Download size={16} color={COLORS.text} /> Export
        </button>
      </div>

      {/* Table */}
      <div
        className="rounded-2xl overflow-hidden shadow-lg mb-6"
        style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
      >
        <table className="w-full text-left text-sm">
          <thead>
            <tr style={{ backgroundColor: COLORS.text, color: COLORS.card }}>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>ID</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>User</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Action</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Status</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Date</th>
            </tr>
          </thead>

          <tbody>
            {filteredLogs.map((log) => (
              <tr
                key={log.id}
                className="hover:opacity-80 transition"
                style={{ borderBottom: `1px solid ${COLORS.border}` }}
              >
                <td className="px-6 py-3">{log.id}</td>
                <td className="px-6 py-3">{log.user}</td>
                <td className="px-6 py-3">{log.action}</td>
                <td className="px-6 py-3">
                  <span
                    className={`font-medium ${
                      log.status === "Success"
                        ? "text-green-600"
                        : log.status === "Failed"
                        ? "text-red-600"
                        : "text-yellow-600"
                    }`}
                  >
                    {log.status}
                  </span>
                </td>
                <td className="px-6 py-3">{log.date}</td>
              </tr>
            ))}
          </tbody>
        </table>

        {/* Footer */}
        <div className="px-6 py-4 text-center text-sm" style={{ color: COLORS.text, backgroundColor: COLORS.card }}>
          Showing {filteredLogs.length} records
        </div>
      </div>
    </div>
  );
};

export default EnterpriseAuditLogs;