import React, { useState } from "react";

/**
 * EnterpriseSettingsConfiguration (centered content)
 * - Content is centered in the available space (excluding sidebar)
 */

const COLORS = {
  bg: "#F3E9DD",
  border: "#D7C3AE",
  text: "#4A3F35",
  card: "#F8F1E7",
  headerText: "#4A3F35",
  buttonBg: "#4A3F35",
  buttonText: "#F3E9DD",
  tabActive: "#4A3F35",
  tabInactive: "#8B7A65",
  inputBg: "#FFF8F0",
  toggleBg: "#FFF",
};

const EnterpriseSettingsConfiguration = () => {
  const [activeTab, setActiveTab] = useState("settings");

  return (
    <div style={{ backgroundColor: COLORS.bg, minHeight: "100vh" }}>
      {/* Main content container */}
      <div className="ml-0 md:ml-64 p-6 md:p-8">
        {/* Page header - left aligned */}
        <div className="mb-5">
          <h1 className="text-2xl font-semibold" style={{ color: COLORS.headerText }}>
            Settings & Configuration
          </h1>
        </div>

        {/* Tabs - centered */}
        <div className="mb-5">
          <div className="flex justify-center gap-8 border-b pb-2" style={{ borderColor: COLORS.border }}>
            <button
              onClick={() => setActiveTab("settings")}
              className="pb-3 text-sm font-medium transition"
              style={{
                color: activeTab === "settings" ? COLORS.tabActive : COLORS.tabInactive,
                borderBottom: activeTab === "settings" ? `3px solid ${COLORS.tabActive}` : "3px solid transparent",
              }}
            >
              Settings
            </button>

            <button
              onClick={() => setActiveTab("notification")}
              className="pb-3 text-sm font-medium transition"
              style={{
                color: activeTab === "notification" ? COLORS.tabActive : COLORS.tabInactive,
                borderBottom: activeTab === "notification" ? `3px solid ${COLORS.tabActive}` : "3px solid transparent",
              }}
            >
              Notification
            </button>
          </div>
        </div>

        {/* Tab content - centered */}
        <div className="w-full flex justify-center mt-4">
          {activeTab === "settings" ? <SettingsTab /> : <NotificationTab />}
        </div>
      </div>
    </div>
  );
};

/* SettingsTab component */
const SettingsTab = () => {
  const [dataRetention, setDataRetention] = useState("30");
  const [auditLogged, setAuditLogged] = useState("30");
  const [auditRetention, setAuditRetention] = useState("30");

  const handleSaveChanges = () => alert("Changes saved!");

  return (
    <div
      className="rounded-2xl shadow-lg p-6 w-full max-w-3xl"
      style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
    >
      <h2 className="text-lg font-semibold mb-2" style={{ color: COLORS.headerText }}>
        Policies & Rules
      </h2>

      <p className="text-xs mb-5" style={{ color: COLORS.tabInactive }}>
        Define enterprise-wide operational constraints and retention policies.
      </p>

      <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
        <div>
          <label className="block text-xs font-medium mb-1.5" style={{ color: COLORS.text }}>
            Data Retention Period (days)
          </label>
          <input
            type="number"
            value={dataRetention}
            onChange={(e) => setDataRetention(e.target.value)}
            className="w-full px-3 py-2 text-sm rounded-lg focus:outline-none focus:ring-1"
            style={{ 
              backgroundColor: COLORS.inputBg, 
              border: `1px solid ${COLORS.border}`,
              color: COLORS.text
            }}
          />
        </div>

        <div>
          <label className="block text-xs font-medium mb-1.5" style={{ color: COLORS.text }}>
            Audit Logged Time (minutes)
          </label>
          <input
            type="number"
            value={auditLogged}
            onChange={(e) => setAuditLogged(e.target.value)}
            className="w-full px-3 py-2 text-sm rounded-lg focus:outline-none focus:ring-1"
            style={{ 
              backgroundColor: COLORS.inputBg, 
              border: `1px solid ${COLORS.border}`,
              color: COLORS.text
            }}
          />
        </div>
      </div>

      <div className="mt-4 w-full md:w-1/2">
        <label className="block text-xs font-medium mb-1.5" style={{ color: COLORS.text }}>
          Audit Log Retention (days)
        </label>
        <input
          type="number"
          value={auditRetention}
          onChange={(e) => setAuditRetention(e.target.value)}
          className="w-full px-3 py-2 text-sm rounded-lg focus:outline-none focus:ring-1"
          style={{ 
            backgroundColor: COLORS.inputBg, 
            border: `1px solid ${COLORS.border}`,
            color: COLORS.text
          }}
        />
      </div>

      <div className="flex justify-center mt-6">
        <button
          onClick={handleSaveChanges}
          className="px-8 py-2 text-sm rounded-lg font-medium hover:opacity-90 transition"
          style={{ backgroundColor: COLORS.buttonBg, color: COLORS.buttonText }}
        >
          Save Changes
        </button>
      </div>
    </div>
  );
};

/* NotificationTab component */
const NotificationTab = () => {
  const [emailEnabled, setEmailEnabled] = useState(true);
  const [smsEnabled, setSmsEnabled] = useState(false);
  const [pushEnabled, setPushEnabled] = useState(true);

  const handleSave = () => alert("Notification settings saved!");

  return (
    <div
      className="rounded-2xl shadow-lg p-6 w-full max-w-2xl"
      style={{ backgroundColor: COLORS.card, border: `1px solid ${COLORS.border}` }}
    >
      <h2 className="text-lg font-semibold mb-4" style={{ color: COLORS.headerText }}>
        Notification Settings
      </h2>

      <div className="space-y-3">
        <ToggleRow label="Email Notifications" enabled={emailEnabled} setEnabled={setEmailEnabled} />
        <ToggleRow label="SMS Notifications" enabled={smsEnabled} setEnabled={setSmsEnabled} />
        <ToggleRow label="Push Notifications" enabled={pushEnabled} setEnabled={setPushEnabled} />
      </div>

      <div className="flex justify-center mt-6">
        <button
          onClick={handleSave}
          className="px-8 py-2 text-sm rounded-lg font-medium hover:opacity-90 transition"
          style={{ backgroundColor: COLORS.buttonBg, color: COLORS.buttonText }}
        >
          Save and Continue
        </button>
      </div>
    </div>
  );
};

/* Toggle row */
const ToggleRow = ({ label, enabled, setEnabled }) => (
  <div
    className="flex items-center justify-between p-4 rounded-lg transition hover:shadow-md"
    style={{ backgroundColor: COLORS.toggleBg, border: `1px solid ${COLORS.border}` }}
  >
    <span className="font-medium text-sm" style={{ color: COLORS.text }}>{label}</span>
    <button
      onClick={() => setEnabled(!enabled)}
      className={`relative inline-flex h-6 w-11 rounded-full transition-all ${enabled ? "bg-green-600" : "bg-gray-400"}`}
    >
      <span 
        className={`inline-block h-4 w-4 bg-white rounded-full transform transition-transform mt-1 ${enabled ? "translate-x-6" : "translate-x-1"}`} 
      />
    </button>
  </div>
);

export default EnterpriseSettingsConfiguration;