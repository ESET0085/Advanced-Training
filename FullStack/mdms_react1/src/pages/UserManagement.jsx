// src/pages/UserManagement.jsx
import React, { useState, useContext } from "react";
import Modal from "../components/Modal.jsx";
import { FiMoreVertical } from "react-icons/fi";
import { DarkModeContext } from "../Layout/ZoneDashboardLayout.jsx";

const initialUsers = [
  { id: 1, name: "abc", email: "abc@gmail.com", role: "role 1", zone: "Mangalore", status: "Active" },
  { id: 2, name: "xyz", email: "xyz@gmail.com", role: "role 2", zone: "Bajpe", status: "De-Activated" },
  { id: 3, name: "pqr", email: "pqr@gmail.com", role: "role 3", zone: "Bajpe", status: "Active" },
];

const UserManagement = () => {
  const { darkMode } = useContext(DarkModeContext);
  const [users, setUsers] = useState(initialUsers);
  const [search, setSearch] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const [showModal, setShowModal] = useState(false);
  const [newUser, setNewUser] = useState({ name: "", email: "", role: "", zone: "", status: "Active" });

  const usersPerPage = 5;
  const filteredUsers = users.filter(user =>
    user.name.toLowerCase().includes(search.toLowerCase())
  );
  const totalPages = Math.ceil(filteredUsers.length / usersPerPage);
  const currentUsers = filteredUsers.slice((currentPage - 1) * usersPerPage, currentPage * usersPerPage);

  const handleInviteUser = () => {
    setUsers([...users, { ...newUser, id: users.length + 1 }]);
    setShowModal(false);
    setNewUser({ name: "", email: "", role: "", zone: "", status: "Active" });
  };

  return (
    <div className={`ml-64 min-h-screen p-6 md:p-8 ${
      darkMode 
        ? "bg-slate-900" 
        : "bg-gradient-to-br from-indigo-100 via-purple-100 to-indigo-50"
    }`}>
      
      {/* Title and Invite */}
      <div className="flex justify-between items-center mb-6">
        <h1 className={`text-3xl font-extrabold text-transparent bg-clip-text ${
          darkMode ? "bg-gradient-to-r from-purple-400 to-pink-500" : "bg-gradient-to-r from-indigo-600 to-purple-600"
        }`}>User Management</h1>
        <button 
          className="px-4 py-2 rounded-2xl font-medium bg-gradient-to-r from-indigo-600 to-purple-600 text-white shadow hover:from-indigo-700 hover:to-purple-700 transition"
          onClick={() => setShowModal(true)}
        >
          Invite User
        </button>
      </div>

      {/* Search */}
      <div className="mb-4 w-full md:w-[405px] h-[50px] bg-white/80 dark:bg-gray-800/60 rounded-2xl flex items-center px-4 backdrop-blur-md border border-gray-300 dark:border-purple-600 shadow-inner">
        <input 
          type="text" 
          placeholder="Search by name" 
          className="flex-1 bg-transparent focus:outline-none text-gray-800 dark:text-gray-100 placeholder-gray-500 dark:placeholder-gray-400" 
          value={search} 
          onChange={(e) => { setSearch(e.target.value); setCurrentPage(1); }} 
        />
      </div>

      {/* Table */}
      <div className={`overflow-x-auto rounded-2xl shadow-lg p-6 ${
        darkMode ? "backdrop-blur-md bg-slate-800/60 border border-purple-600" : "bg-white border border-indigo-200"
      }`}>
        <table className="min-w-full text-left">
          <thead className={`${darkMode ? "text-purple-300 border-b border-purple-600" : "text-indigo-700 border-b border-indigo-200"}`}>
            <tr>
              {["ID","Name","Email","Role","Zone","Status","More Actions"].map(head => (
                <th key={head} className="py-3 px-4 font-medium">{head}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {currentUsers.map(user => (
              <tr key={user.id} className={`transition-all rounded-lg hover:scale-[1.02] hover:shadow-xl ${
                darkMode ? "text-gray-200 hover:bg-slate-700/50" : "text-gray-800 hover:bg-indigo-50"
              }`}>
                <td className="py-3 px-4">{user.id}</td>
                <td className="py-3 px-4">{user.name}</td>
                <td className="py-3 px-4">{user.email}</td>
                <td className="py-3 px-4">{user.role}</td>
                <td className="py-3 px-4">{user.zone}</td>
                <td className="py-3 px-4">
                  <span className={`px-2 py-1 rounded-full text-sm font-semibold ${
                    user.status === "Active"
                      ? "bg-green-200 text-green-800 dark:bg-green-700 dark:text-green-100"
                      : "bg-red-200 text-red-800 dark:bg-red-700 dark:text-red-100"
                  }`}>
                    {user.status}
                  </span>
                </td>
                <td className="py-3 px-4 cursor-pointer text-purple-500 hover:text-purple-400"><FiMoreVertical /></td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* Pagination */}
      <div className="flex justify-end mt-6 gap-2">
        <button 
          onClick={() => setCurrentPage(currentPage-1)} 
          disabled={currentPage===1} 
          className={`px-3 py-1 rounded-2xl font-medium transition ${
            darkMode ? "bg-purple-700 text-white disabled:bg-purple-900/40 hover:bg-purple-600" : "bg-indigo-200 text-indigo-900 disabled:bg-indigo-100 hover:bg-indigo-300"
          }`}
        >
          Prev
        </button>

        {[...Array(totalPages).keys()].map(i => (
          <button 
            key={i+1} 
            onClick={() => setCurrentPage(i+1)} 
            className={`px-3 py-1 rounded-2xl font-medium transition ${
              currentPage===i+1 
                ? darkMode ? "bg-purple-600 text-white" : "bg-indigo-600 text-white"
                : darkMode ? "bg-slate-700 text-purple-300 hover:bg-purple-600" : "bg-indigo-100 text-indigo-800 hover:bg-indigo-300"
            }`}
          >
            {i+1}
          </button>
        ))}

        <button 
          onClick={() => setCurrentPage(currentPage+1)} 
          disabled={currentPage===totalPages} 
          className={`px-3 py-1 rounded-2xl font-medium transition ${
            darkMode ? "bg-purple-700 text-white disabled:bg-purple-900/40 hover:bg-purple-600" : "bg-indigo-200 text-indigo-900 disabled:bg-indigo-100 hover:bg-indigo-300"
          }`}
        >
          Next
        </button>
      </div>

      {/* Invite Modal */}
      {showModal && (
        <Modal title="Invite User" onClose={() => setShowModal(false)}>
          <div className="flex flex-col gap-3">
            {["Name","Email","Role","Zone"].map(field => (
              <input 
                key={field}
                type={field==="Email"?"email":"text"} 
                placeholder={field} 
                value={newUser[field.toLowerCase()]} 
                onChange={(e)=>setNewUser({...newUser,[field.toLowerCase()]:e.target.value})} 
                className="border p-2 rounded-lg focus:ring-2 focus:ring-purple-400 focus:outline-none dark:bg-gray-700 dark:text-gray-100"
              />
            ))}
            <button 
              onClick={handleInviteUser} 
              className="px-4 py-2 rounded-2xl font-medium bg-gradient-to-r from-indigo-600 to-purple-600 text-white shadow hover:from-indigo-700 hover:to-purple-700 transition mt-2"
            >
              Invite
            </button>
          </div>
        </Modal>
      )}
    </div>
  );
};

export default UserManagement;
