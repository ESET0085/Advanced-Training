import React, { useState } from "react";
import { Search, Download, UserPlus, MoreVertical, Edit2, Eye, Trash2, X } from "lucide-react";
import { BarChart, Bar, XAxis, YAxis, Tooltip, ResponsiveContainer, Cell } from "recharts";

const COLORS = {
  bg: "#F3E9DD",
  border: "#D7C3AE",
  text: "#4A3F35",
  accent: "#B89F7A",
};

const EnterpriseUserRoleManagement = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const [showInviteDialog, setShowInviteDialog] = useState(false);
  const [inviteForm, setInviteForm] = useState({ email: "", role: "", zone: "" });
  const [openMenuId, setOpenMenuId] = useState(null);
  const [editingUser, setEditingUser] = useState(null);
  const [viewingUser, setViewingUser] = useState(null);

  const usersPerPage = 10;

  const [users, setUsers] = useState([
    { id: 123, name: "abc", email: "abc@gmail.com", role: "Manager", status: "Active" },
    { id: 124, name: "xyz", email: "xyz@gmail.com", role: "Supervisor", status: "De-Activated" },
    { id: 125, name: "pqr", email: "pqr@gmail.com", role: "Technician", status: "Active" },
    { id: 126, name: "lmn", email: "lmn@gmail.com", role: "Operator", status: "De-Activated" },
    { id: 127, name: "stu", email: "stu@gmail.com", role: "Engineer", status: "Active" },
    { id: 128, name: "john", email: "john@example.com", role: "Manager", status: "Active" },
    { id: 129, name: "emma", email: "emma@example.com", role: "Supervisor", status: "De-Activated" },
    { id: 130, name: "sara", email: "sara@example.com", role: "Operator", status: "Active" },
    { id: 131, name: "david", email: "david@example.com", role: "Technician", status: "Active" },
    { id: 132, name: "michael", email: "michael@example.com", role: "Engineer", status: "De-Activated" },
    { id: 133, name: "anna", email: "anna@example.com", role: "Operator", status: "Active" },
    { id: 134, name: "rohit", email: "rohit@example.com", role: "Technician", status: "Active" },
    { id: 135, name: "kiran", email: "kiran@example.com", role: "Manager", status: "De-Activated" },
    { id: 136, name: "vani", email: "vani@example.com", role: "Supervisor", status: "Active" },
    { id: 137, name: "megha", email: "megha@example.com", role: "Engineer", status: "Active" },
    { id: 138, name: "sam", email: "sam@example.com", role: "Technician", status: "De-Activated" },
    { id: 139, name: "tina", email: "tina@example.com", role: "Operator", status: "Active" },
    { id: 140, name: "arjun", email: "arjun@example.com", role: "Supervisor", status: "Active" },
    { id: 141, name: "priya", email: "priya@example.com", role: "Manager", status: "De-Activated" },
    { id: 142, name: "rahul", email: "rahul@example.com", role: "Engineer", status: "Active" },
  ]);

  const chartData = [
    { name: "Active", value: users.filter(u => u.status === "Active").length, color: "#8B5CF6" },
    { name: "De-Activated", value: users.filter(u => u.status === "De-Activated").length, color: "#EF4444" },
  ];

  const filteredUsers = users.filter(
    u =>
      u.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
      u.email.toLowerCase().includes(searchTerm.toLowerCase()) ||
      u.role.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const indexOfLast = currentPage * usersPerPage;
  const indexOfFirst = indexOfLast - usersPerPage;
  const currentUsers = filteredUsers.slice(indexOfFirst, indexOfLast);
  const totalPages = Math.ceil(filteredUsers.length / usersPerPage);

  const handlePageChange = page => {
    if (page >= 1 && page <= totalPages) setCurrentPage(page);
  };

  const handleInviteSubmit = () => {
    setUsers(prev => [...prev, { ...inviteForm, id: Date.now(), status: "Active" }]);
    setShowInviteDialog(false);
    setInviteForm({ email: "", role: "", zone: "" });
  };

  const handleDelete = id => {
    if (window.confirm("Are you sure you want to delete this user?")) {
      setUsers(prev => prev.filter(u => u.id !== id));
    }
    setOpenMenuId(null);
  };

  const handleEditSave = () => {
    setUsers(prev => prev.map(u => (u.id === editingUser.id ? editingUser : u)));
    setEditingUser(null);
  };

  return (
    <div className="flex min-h-screen">
      

      {/* Main Content */}
      <div className="flex-1 p-6 ml-[250px]" style={{ backgroundColor: COLORS.bg, color: COLORS.text }}>
        {/* Header */}
        <div className="text-2xl font-bold mb-6">Enterprise User & Role Management</div>

        {/* Search & Action */}
        <div className="flex flex-col md:flex-row justify-between items-start md:items-center gap-4 mb-6">
          <div className="flex gap-2 flex-wrap w-full">
            <div className="relative flex-1">
              <input
                type="text"
                placeholder="Search by name, email, or role"
                className="w-full px-10 py-2 rounded-lg focus:outline-none focus:ring-1 text-sm"
                style={{ backgroundColor: COLORS.bg, border: `1px solid ${COLORS.border}`, color: COLORS.text }}
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
              />
              <Search className="absolute top-2.5 left-3" size={20} style={{ color: COLORS.text }} />
            </div>
            <button 
              className="px-4 py-2 rounded-lg hover:opacity-80 transition flex items-center gap-2 text-sm"
              style={{ backgroundColor: COLORS.bg, border: `1px solid ${COLORS.border}`, color: COLORS.text }}
            >
              <Download size={18} /> Export CSV
            </button>
            <button
              onClick={() => setShowInviteDialog(true)}
              className="px-4 py-2 rounded-lg hover:opacity-80 transition flex items-center gap-2 text-sm"
              style={{ backgroundColor: COLORS.bg, border: `1px solid ${COLORS.border}`, color: COLORS.text }}
            >
              <UserPlus size={18} /> Invite User
            </button>
          </div>
        </div>

        {/* Table */}
        <div className="rounded-2xl overflow-hidden mb-6" style={{ backgroundColor: COLORS.bg, border: `1px solid ${COLORS.border}` }}>
          <table className="w-full text-left text-sm">
            <thead>
              <tr style={{ backgroundColor: COLORS.text, color: COLORS.bg }}>
                {["User ID", "Name", "Email", "Role", "Status", "Actions"].map((col, idx) => (
                  <th key={idx} className="px-6 py-3 border-b" style={{ borderColor: COLORS.border }}>
                    {col}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {currentUsers.map(user => (
                <tr key={user.id} className="hover:opacity-80" style={{ borderBottom: `1px solid ${COLORS.border}` }}>
                  <td className="px-6 py-3">{user.id}</td>
                  <td className="px-6 py-3">{user.name}</td>
                  <td className="px-6 py-3">{user.email}</td>
                  <td className="px-6 py-3">{user.role}</td>
                  <td className={`px-6 py-3 font-medium ${user.status === "Active" ? "text-green-600" : "text-red-600"}`}>
                    {user.status}
                  </td>
                  <td className="px-6 py-3 relative">
                    <div className="relative inline-block" onMouseEnter={() => setOpenMenuId(user.id)} onMouseLeave={() => setOpenMenuId(null)}>
                      <button className="p-2 rounded hover:opacity-70"><MoreVertical size={18} /></button>
                      {openMenuId === user.id && (
                        <div className="absolute right-0 mt-1 w-36 shadow-lg rounded-lg z-50"
                          style={{ backgroundColor: COLORS.bg, border: `1px solid ${COLORS.border}` }}
                        >
                          <button onClick={() => setViewingUser(user)} className="flex items-center gap-2 px-4 py-2 w-full hover:opacity-70">
                            <Eye size={14} /> View
                          </button>
                          <button onClick={() => setEditingUser({ ...user })} className="flex items-center gap-2 px-4 py-2 w-full hover:opacity-70">
                            <Edit2 size={14} /> Edit
                          </button>
                          <button onClick={() => handleDelete(user.id)} className="flex items-center gap-2 px-4 py-2 w-full hover:opacity-70 text-red-600">
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
        </div>

        {/* Pagination */}
        <div className="flex justify-center items-center gap-2 mb-6" style={{ color: COLORS.text }}>
          <button className="px-3 py-1 rounded-md hover:opacity-70" style={{ border: `1px solid ${COLORS.border}` }} onClick={() => handlePageChange(currentPage - 1)} disabled={currentPage === 1}>← Previous</button>
          {[...Array(totalPages)].map((_, idx) => (
            <button key={idx + 1} className={`px-3 py-1 rounded-md hover:opacity-70`} style={{ border: `1px solid ${COLORS.border}`, backgroundColor: currentPage === idx + 1 ? COLORS.border : "transparent" }} onClick={() => handlePageChange(idx + 1)}>{idx + 1}</button>
          ))}
          <button className="px-3 py-1 rounded-md hover:opacity-70" style={{ border: `1px solid ${COLORS.border}` }} onClick={() => handlePageChange(currentPage + 1)} disabled={currentPage === totalPages}>Next →</button>
        </div>

        {/* Chart */}
        <div className="flex flex-wrap gap-4">
          <div className="w-[405px] h-[240px] p-4 rounded-xl shadow" style={{ backgroundColor: COLORS.bg, border: `1px solid ${COLORS.border}` }}>
            <h2 className="text-lg font-semibold mb-2" style={{ color: COLORS.text }}>Active vs De-Active Users</h2>
            <ResponsiveContainer width="100%" height="85%">
              <BarChart data={chartData} barSize={50}>
                <XAxis dataKey="name" />
                <YAxis />
                <Tooltip />
                <Bar dataKey="value" radius={[20, 20, 20, 20]}>
                  {chartData.map((entry, index) => <Cell key={index} fill={entry.color} />)}
                </Bar>
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>

        {/* Modals (Invite, View, Edit) */}
        {showInviteDialog && (
          <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
            <div className="rounded-lg shadow-xl p-6 w-[400px]" style={{ backgroundColor: COLORS.bg }}>
              <h2 className="text-xl font-semibold mb-4" style={{ color: COLORS.text }}>Invite user</h2>
              <div className="space-y-4">
                <input type="email" placeholder="Email" value={inviteForm.email} onChange={(e) => setInviteForm({ ...inviteForm, email: e.target.value })} className="w-full px-3 py-2 rounded-lg focus:outline-none focus:ring-1" style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }} />
                <input type="text" placeholder="Role" value={inviteForm.role} onChange={(e) => setInviteForm({ ...inviteForm, role: e.target.value })} className="w-full px-3 py-2 rounded-lg focus:outline-none focus:ring-1" style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }} />
                <input type="text" placeholder="Zone" value={inviteForm.zone} onChange={(e) => setInviteForm({ ...inviteForm, zone: e.target.value })} className="w-full px-3 py-2 rounded-lg focus:outline-none focus:ring-1" style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }} />
                <div className="flex gap-3 mt-2">
                  <button type="button" onClick={() => setShowInviteDialog(false)} className="flex-1 px-4 py-2 rounded-lg hover:opacity-70" style={{ border: `1px solid ${COLORS.border}`, color: COLORS.text }}>Cancel</button>
                  <button type="button" onClick={handleInviteSubmit} className="flex-1 px-4 py-2 rounded-lg hover:opacity-80 transition" style={{ backgroundColor: COLORS.text, color: COLORS.bg }}>Send Invite</button>
                </div>
              </div>
            </div>
          </div>
        )}

        {viewingUser && (
          <div className="fixed inset-0 bg-black/50 flex items-center justify-center z-50">
            <div className="rounded-lg p-6 w-full max-w-md shadow-xl" style={{ backgroundColor: COLORS.bg }}>
              <div className="flex justify-between mb-4">
                <h2 className="text-xl font-semibold" style={{ color: COLORS.text }}>View User</h2>
                <button onClick={() => setViewingUser(null)}><X size={20} /></button>
              </div>
              <div className="space-y-2" style={{ color: COLORS.text }}>
                <p><strong>ID:</strong> {viewingUser.id}</p>
                <p><strong>Name:</strong> {viewingUser.name}</p>
                <p><strong>Email:</strong> {viewingUser.email}</p>
                <p><strong>Role:</strong> {viewingUser.role}</p>
                <p><strong>Status:</strong> {viewingUser.status}</p>
              </div>
              <button className="mt-4 px-4 py-2 rounded-lg hover:opacity-70" style={{ border: `1px solid ${COLORS.border}`, color: COLORS.text }} onClick={() => setViewingUser(null)}>Close</button>
            </div>
          </div>
        )}

        {editingUser && (
          <div className="fixed inset-0 bg-black/50 flex items-center justify-center z-50">
            <div className="rounded-lg p-6 w-full max-w-md shadow-xl" style={{ backgroundColor: COLORS.bg }}>
              <div className="flex justify-between mb-4">
                <h2 className="text-xl font-semibold" style={{ color: COLORS.text }}>Edit User</h2>
                <button onClick={() => setEditingUser(null)}><X size={20} /></button>
              </div>
              <div className="space-y-3">
                <input className="w-full px-3 py-2 rounded-lg" style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }} value={editingUser.name} onChange={(e) => setEditingUser({ ...editingUser, name: e.target.value })} />
                <input className="w-full px-3 py-2 rounded-lg" style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }} value={editingUser.email} onChange={(e) => setEditingUser({ ...editingUser, email: e.target.value })} />
                <input className="w-full px-3 py-2 rounded-lg" style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }} value={editingUser.role} onChange={(e) => setEditingUser({ ...editingUser, role: e.target.value })} />
                <select className="w-full px-3 py-2 rounded-lg" style={{ border: `1px solid ${COLORS.border}`, backgroundColor: "white", color: COLORS.text }} value={editingUser.status} onChange={(e) => setEditingUser({ ...editingUser, status: e.target.value })}>
                  <option>Active</option>
                  <option>De-Activated</option>
                </select>
                <button onClick={handleEditSave} className="w-full mt-3 px-4 py-2 rounded-lg hover:opacity-80" style={{ backgroundColor: COLORS.text, color: COLORS.bg }}>Save Changes</button>
              </div>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default EnterpriseUserRoleManagement;
