// src/pages/NotificationSettings.jsx
import React, { useState, useContext } from "react";
import { DarkModeContext } from "../Layout/ZoneDashboardLayout.jsx";

const NotificationSettings = () => {
  const { darkMode } = useContext(DarkModeContext); // ✅ use global dark mode
  const [activeTab, setActiveTab] = useState("notifications");

  return (
    <div
      className={`ml-64 min-h-screen p-6 md:p-8 relative overflow-hidden ${
        darkMode
          ? "bg-slate-900"
          : "bg-gradient-to-br from-indigo-100 via-purple-100 to-indigo-50"
      }`}
    >
      {/* Background blobs */}
      <div className="absolute top-[-100px] left-[-100px] w-80 h-80 bg-purple-400/40 rounded-full filter blur-3xl opacity-70 z-0"></div>
      <div className="absolute top-[200px] right-[-150px] w-96 h-96 bg-pink-400/30 rounded-full filter blur-3xl opacity-60 z-0"></div>
      <div className="absolute bottom-[50px] left-[150px] w-72 h-72 bg-indigo-400/20 rounded-full filter blur-3xl opacity-50 z-0"></div>

      {/* Centered content wrapper */}
      <div className="relative z-10 flex flex-col items-center">
        {/* Page Title */}
        <h1
          className={`text-3xl font-extrabold mb-6 text-transparent bg-clip-text text-center ${
            darkMode
              ? "bg-gradient-to-r from-purple-400 to-pink-500"
              : "bg-gradient-to-r from-indigo-600 to-purple-600"
          }`}
        >
          Notification Settings
        </h1>

        {/* Tabs */}
        <div className="w-full max-w-4xl mb-8">
          <div
            className={`flex justify-center gap-8 border-b pb-2 ${
              darkMode ? "border-gray-600" : "border-gray-300"
            }`}
          >
            <button
              onClick={() => setActiveTab("notifications")}
              className={`pb-3 text-sm font-medium transition-all ${
                activeTab === "notifications"
                  ? darkMode
                    ? "border-b-2 border-purple-400 text-purple-400"
                    : "border-b-2 border-purple-600 text-purple-600"
                  : darkMode
                  ? "text-gray-400 hover:text-gray-200"
                  : "text-gray-500 hover:text-gray-700"
              }`}
            >
              Notifications
            </button>
            <button
              onClick={() => setActiveTab("settings")}
              className={`pb-3 text-sm font-medium transition-all ${
                activeTab === "settings"
                  ? darkMode
                    ? "border-b-2 border-purple-400 text-purple-400"
                    : "border-b-2 border-purple-600 text-purple-600"
                  : darkMode
                  ? "text-gray-400 hover:text-gray-200"
                  : "text-gray-500 hover:text-gray-700"
              }`}
            >
              Settings
            </button>
          </div>
        </div>

        {/* Tab Content */}
        <div className="w-full flex justify-center">
          <div
            className={`${
              darkMode
                ? "bg-gray-800/60 border-purple-600"
                : "bg-white/80 border-indigo-200"
            } 
              backdrop-blur-md rounded-2xl shadow-lg border p-6 
              w-full max-w-2xl
              transition-all duration-500 ease-out`}
          >
            {activeTab === "notifications" ? (
              <NotificationTab darkMode={darkMode} />
            ) : (
              <SettingsTab darkMode={darkMode} />
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

/* NotificationTab Component */
const NotificationTab = ({ darkMode }) => {
  const [emailEnabled, setEmailEnabled] = useState(true);
  const [smsEnabled, setSmsEnabled] = useState(false);
  const [pushEnabled, setPushEnabled] = useState(true);

  const handleSave = () => alert("Notification settings saved!");

  return (
    <div className="w-full">
      <h2
        className={`text-lg font-semibold mb-4 ${
          darkMode ? "text-gray-100" : "text-gray-800"
        }`}
      >
        Notification Preferences
      </h2>

      <div className="space-y-3">
        <ToggleRow
          label="Email Notifications"
          enabled={emailEnabled}
          setEnabled={setEmailEnabled}
          darkMode={darkMode}
        />
        <ToggleRow
          label="SMS Notifications"
          enabled={smsEnabled}
          setEnabled={setSmsEnabled}
          darkMode={darkMode}
        />
        <ToggleRow
          label="Push Notifications"
          enabled={pushEnabled}
          setEnabled={setPushEnabled}
          darkMode={darkMode}
        />
      </div>

      <div className="flex justify-center mt-6">
        <button
          onClick={handleSave}
          className={`px-8 py-2 text-sm rounded-lg font-medium transition-all ${
            darkMode
              ? "bg-purple-600 hover:bg-purple-700 text-white"
              : "bg-gradient-to-r from-indigo-600 to-purple-600 hover:from-indigo-700 hover:to-purple-700 text-white"
          }`}
        >
          Save Changes
        </button>
      </div>
    </div>
  );
};

/* SettingsTab Component */
const SettingsTab = ({ darkMode }) => {
  const [dataRetention, setDataRetention] = useState("30");
  const [auditLogged, setAuditLogged] = useState("30");
  const [auditRetention, setAuditRetention] = useState("30");

  const handleSave = () => alert("Settings saved!");

  return (
    <div className="w-full">
      <h2
        className={`text-lg font-semibold mb-2 ${
          darkMode ? "text-gray-100" : "text-gray-800"
        }`}
      >
        Policies & Rules
      </h2>

      <p
        className={`text-xs mb-6 ${
          darkMode ? "text-gray-400" : "text-gray-600"
        }`}
      >
        Define operational constraints and retention policies.
      </p>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        <div>
          <label
            className={`block text-xs font-medium mb-1.5 ${
              darkMode ? "text-gray-300" : "text-gray-700"
            }`}
          >
            Data Retention Period (days)
          </label>
          <input
            type="number"
            value={dataRetention}
            onChange={(e) => setDataRetention(e.target.value)}
            className={`w-full px-3 py-2 text-sm rounded-lg focus:outline-none focus:ring-2 ${
              darkMode
                ? "bg-gray-700 border-gray-600 text-gray-100 focus:ring-purple-500"
                : "bg-white border-gray-300 text-gray-800 focus:ring-indigo-500"
            } border`}
          />
        </div>

        <div>
          <label
            className={`block text-xs font-medium mb-1.5 ${
              darkMode ? "text-gray-300" : "text-gray-700"
            }`}
          >
            Audit Logged Time (minutes)
          </label>
          <input
            type="number"
            value={auditLogged}
            onChange={(e) => setAuditLogged(e.target.value)}
            className={`w-full px-3 py-2 text-sm rounded-lg focus:outline-none focus:ring-2 ${
              darkMode
                ? "bg-gray-700 border-gray-600 text-gray-100 focus:ring-purple-500"
                : "bg-white border-gray-300 text-gray-800 focus:ring-indigo-500"
            } border`}
          />
        </div>

        <div>
          <label
            className={`block text-xs font-medium mb-1.5 ${
              darkMode ? "text-gray-300" : "text-gray-700"
            }`}
          >
            Audit Log Retention (days)
          </label>
          <input
            type="number"
            value={auditRetention}
            onChange={(e) => setAuditRetention(e.target.value)}
            className={`w-full px-3 py-2 text-sm rounded-lg focus:outline-none focus:ring-2 ${
              darkMode
                ? "bg-gray-700 border-gray-600 text-gray-100 focus:ring-purple-500"
                : "bg-white border-gray-300 text-gray-800 focus:ring-indigo-500"
            } border`}
          />
        </div>
      </div>

      <div className="flex justify-center mt-6">
        <button
          onClick={handleSave}
          className={`px-8 py-2 text-sm rounded-lg font-medium transition-all ${
            darkMode
              ? "bg-purple-600 hover:bg-purple-700 text-white"
              : "bg-gradient-to-r from-indigo-600 to-purple-600 hover:from-indigo-700 hover:to-purple-700 text-white"
          }`}
        >
          Save Changes
        </button>
      </div>
    </div>
  );
};

/* Toggle Row Component */
const ToggleRow = ({ label, enabled, setEnabled, darkMode }) => (
  <div
    className={`flex items-center justify-between p-4 rounded-lg transition hover:shadow-md ${
      darkMode
        ? "bg-gray-700/50 border-gray-600"
        : "bg-white border-gray-200"
    } border`}
  >
    <span
      className={`font-medium text-sm ${
        darkMode ? "text-gray-200" : "text-gray-800"
      }`}
    >
      {label}
    </span>
    <button
      onClick={() => setEnabled(!enabled)}
      className={`relative inline-flex h-6 w-11 rounded-full transition-all ${
        enabled ? "bg-purple-600" : "bg-gray-400"
      }`}
    >
      <span
        className={`inline-block h-4 w-4 bg-white rounded-full transform transition-transform mt-1 ${
          enabled ? "translate-x-6" : "translate-x-1"
        }`}
      />
    </button>
  </div>
);

export default NotificationSettings;
