import React, { useState } from "react";
import { Plus, MoreVertical, Edit2, Trash2, X } from "lucide-react";

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
};

const EnterpriseZoneManagement = () => {
  const [zones, setZones] = useState([
    { id: 123, name: "Mangalore", admin: "abc", meters: 5, status: "Active" },
    { id: 124, name: "Baijpe", admin: "xyz", meters: 12, status: "De-Activated" },
    { id: 125, name: "Hubli", admin: "pqr", meters: 8, status: "Active" },
    { id: 126, name: "Belgaum", admin: "def", meters: 34, status: "De-Activated" },
  ]);

  const [showDialog, setShowDialog] = useState(false);
  const [editingZone, setEditingZone] = useState(null);
  const [currentPage, setCurrentPage] = useState(1);
  const [openMenuId, setOpenMenuId] = useState(null);
  const zonesPerPage = 2;

  const [formData, setFormData] = useState({ name: "", admin: "", meters: "", status: "Active" });

  const indexOfLast = currentPage * zonesPerPage;
  const indexOfFirst = indexOfLast - zonesPerPage;
  const currentZones = zones.slice(indexOfFirst, indexOfLast);
  const totalPages = Math.ceil(zones.length / zonesPerPage);

  const handlePageChange = (page) => {
    if (page >= 1 && page <= totalPages) setCurrentPage(page);
  };

  const handleAddZone = () => {
    if (!formData.name || !formData.admin || !formData.meters) {
      alert("Please fill all fields");
      return;
    }
    const newZone = {
      id: Math.max(...zones.map((z) => z.id)) + 1,
      ...formData,
      meters: parseInt(formData.meters) || 0,
    };
    setZones([...zones, newZone]);
    resetForm();
  };

  const handleEditClick = (zone) => {
    setEditingZone(zone);
    setFormData({
      name: zone.name,
      admin: zone.admin,
      meters: zone.meters.toString(),
      status: zone.status,
    });
    setShowDialog(true);
    setOpenMenuId(null);
  };

  const handleUpdateZone = () => {
    if (!formData.name || !formData.admin || !formData.meters) {
      alert("Please fill all fields");
      return;
    }
    setZones(
      zones.map((z) =>
        z.id === editingZone.id
          ? { ...z, ...formData, meters: parseInt(formData.meters) || 0 }
          : z
      )
    );
    resetForm();
  };

  const handleDeleteZone = (id) => {
    if (window.confirm("Are you sure you want to delete this zone?")) {
      setZones(zones.filter((z) => z.id !== id));
      setOpenMenuId(null);
      if (currentZones.length === 1 && currentPage > 1) setCurrentPage(currentPage - 1);
    }
  };

  const resetForm = () => {
    setFormData({ name: "", admin: "", meters: "", status: "Active" });
    setShowDialog(false);
    setEditingZone(null);
  };

  const handleSubmit = () => {
    editingZone ? handleUpdateZone() : handleAddZone();
  };

  return (
    <div className="ml-64 p-6 min-h-screen" style={{ color: COLORS.text }}>
      {/* Page Header */}
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-2xl font-semibold" style={{ color: COLORS.headerText }}>
          Zone Management
        </h1>
        <button
          onClick={() => setShowDialog(true)}
          className="flex items-center gap-2 px-4 py-2 rounded-lg hover:opacity-80 transition"
          style={{ backgroundColor: COLORS.buttonBg, color: COLORS.buttonText }}
        >
          <Plus size={18} /> Add Zone
        </button>
      </div>

      {/* Table Container */}
      <div
        className="overflow-hidden shadow-lg rounded-2xl mb-6"
        style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
      >
        <table className="w-full text-sm text-left">
          <thead>
            <tr style={{ backgroundColor: COLORS.bg, color: COLORS.buttonText }}>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Zone ID</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Zone Name</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Admin Assigned</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Total Meters</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Status</th>
              <th className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>Actions</th>
            </tr>
          </thead>
          <tbody>
            {currentZones.map((zone) => (
              <tr
                key={zone.id}
                style={{ borderBottom: `1px solid ${COLORS.border}` }}
                className="hover:opacity-80 transition"
              >
                <td className="px-6 py-3">{zone.id}</td>
                <td className="px-6 py-3 font-medium">{zone.name}</td>
                <td className="px-6 py-3">{zone.admin}</td>
                <td className="px-6 py-3">{zone.meters}</td>
                <td className="px-6 py-3">
                  <span
                    className={`font-medium ${
                      zone.status === "Active" ? "text-green-600" : "text-red-600"
                    }`}
                  >
                    {zone.status}
                  </span>
                </td>
                <td className="px-6 py-3 relative">
                  <div 
                    className="relative inline-block"
                    onMouseEnter={() => setOpenMenuId(zone.id)}
                    onMouseLeave={() => setOpenMenuId(null)}
                  >
                    <button className="p-2 rounded hover:opacity-70">
                      <MoreVertical size={18} />
                    </button>
                    {openMenuId === zone.id && (
                      <div
                        className="absolute right-0 mt-1 w-36 rounded-lg shadow-lg z-50"
                        style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
                      >
                        <button
                          onClick={() => handleEditClick(zone)}
                          className="flex items-center gap-2 w-full px-4 py-2 text-sm hover:opacity-70 text-left"
                        >
                          <Edit2 size={14} /> Edit
                        </button>
                        <button
                          onClick={() => handleDeleteZone(zone.id)}
                          className="flex items-center gap-2 w-full px-4 py-2 text-sm hover:opacity-70 text-left text-red-600"
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

        {/* Pagination */}
        <div className="flex justify-center items-center py-4 gap-2" style={{ backgroundColor: COLORS.card }}>
          <button
            onClick={() => handlePageChange(currentPage - 1)}
            disabled={currentPage === 1}
            className="px-3 py-1 rounded-md text-sm hover:opacity-70"
            style={{
              border: `1px solid ${COLORS.border}`,
              color: COLORS.text,
              opacity: currentPage === 1 ? 0.5 : 1,
            }}
          >
            ← Previous
          </button>
          {[...Array(totalPages)].map((_, idx) => (
            <button
              key={idx + 1}
              className="px-3 py-1 rounded-md text-sm hover:opacity-70"
              style={{
                border: `1px solid ${COLORS.border}`,
                backgroundColor: currentPage === idx + 1 ? COLORS.border : "transparent",
                color: COLORS.text,
              }}
              onClick={() => handlePageChange(idx + 1)}
            >
              {idx + 1}
            </button>
          ))}
          <button
            onClick={() => handlePageChange(currentPage + 1)}
            disabled={currentPage === totalPages}
            className="px-3 py-1 rounded-md text-sm hover:opacity-70"
            style={{
              border: `1px solid ${COLORS.border}`,
              color: COLORS.text,
              opacity: currentPage === totalPages ? 0.5 : 1,
            }}
          >
            Next →
          </button>
        </div>
      </div>

      {/* Add/Edit Dialog */}
      {showDialog && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
          <div className="rounded-xl shadow-xl p-6 w-[450px]" style={{ backgroundColor: COLORS.card }}>
            <div className="flex justify-between items-center mb-4">
              <h2 className="text-xl font-semibold" style={{ color: COLORS.text }}>
                {editingZone ? "Edit Zone" : "Add New Zone"}
              </h2>
              <button onClick={resetForm} className="hover:opacity-70">
                <X size={20} style={{ color: COLORS.text }} />
              </button>
            </div>
            <div className="space-y-4">
              <div>
                <label className="block text-sm font-medium mb-1" style={{ color: COLORS.text }}>
                  Zone Name
                </label>
                <input
                  type="text"
                  placeholder="Enter zone name"
                  value={formData.name}
                  onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                  className="w-full px-3 py-2 rounded-lg focus:outline-none focus:ring-1"
                  style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }}
                />
              </div>
              <div>
                <label className="block text-sm font-medium mb-1" style={{ color: COLORS.text }}>
                  Admin Assigned
                </label>
                <input
                  type="text"
                  placeholder="Enter admin name"
                  value={formData.admin}
                  onChange={(e) => setFormData({ ...formData, admin: e.target.value })}
                  className="w-full px-3 py-2 rounded-lg focus:outline-none focus:ring-1"
                  style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }}
                />
              </div>
              <div>
                <label className="block text-sm font-medium mb-1" style={{ color: COLORS.text }}>
                  Total Meters
                </label>
                <input
                  type="number"
                  placeholder="Enter number of meters"
                  value={formData.meters}
                  onChange={(e) => setFormData({ ...formData, meters: e.target.value })}
                  className="w-full px-3 py-2 rounded-lg focus:outline-none focus:ring-1"
                  style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }}
                />
              </div>
              <div>
                <label className="block text-sm font-medium mb-1" style={{ color: COLORS.text }}>
                  Status
                </label>
                <select
                  value={formData.status}
                  onChange={(e) => setFormData({ ...formData, status: e.target.value })}
                  className="w-full px-3 py-2 rounded-lg focus:outline-none focus:ring-1"
                  style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }}
                >
                  <option value="Active">Active</option>
                  <option value="De-Activated">De-Activated</option>
                </select>
              </div>
              <div className="flex gap-3 mt-6">
                <button
                  type="button"
                  onClick={resetForm}
                  className="flex-1 px-4 py-2 rounded-lg hover:opacity-70"
                  style={{ border: `1px solid ${COLORS.border}`, color: COLORS.text }}
                >
                  Cancel
                </button>
                <button
                  type="button"
                  onClick={handleSubmit}
                  className="flex-1 px-4 py-2 rounded-lg hover:opacity-80 transition"
                  style={{ backgroundColor: COLORS.buttonBg, color: COLORS.buttonText }}
                >
                  {editingZone ? "Update Zone" : "Add Zone"}
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default EnterpriseZoneManagement;