import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";

// Auth Pages
import Login from "./pages/Login.jsx";
import ForgotPassword from "./pages/ForgotPassword.jsx";
import ResetPassword from "./pages/ResetPassword.jsx";

// User Layout
import DashboardLayout from "./Layout/DashboardLayout.jsx";
import Dashboard from "./pages/Dashboard.jsx";
import Bills from "./pages/Bills_Payments.jsx";
import BillDetails from "./pages/BillDetails.jsx";
import MeterData from "./pages/MeterData.jsx";
import AlertsNotifications from "./pages/AlertsNotifications.jsx";
import ProfileSettingsPage from "./pages/Profile/ProfileSettingsPage.jsx";

// Zone Layout
import ZoneDashboardLayout from "./Layout/ZoneDashboardLayout.jsx";
import ZoneDashboard from "./pages/ZoneDashboard.jsx";
import MeterManagement from "./pages/MeterManagement.jsx";
import UserManagement from "./pages/UserManagement.jsx";
import ReportsAndAnalytics from "./pages/ReportsAndAnalytics.jsx";
import SettingsNotifications from "./pages/SettingsNotifications.jsx";

// Enterprise Layout
import EnterpriseDashboardLayout from "./Layout/EnterpriseDashboardLayout.jsx";
import EnterpriseDashboard from "./pages/EnterpriseDashboard.jsx";
import EnterpriseZoneManagement from "./pages/EnterpriseZoneManagement.jsx";
import EnterpriseMeterManagement from "./pages/EnterpriseMeterManagement.jsx";
import UserRoleManagement from "./pages/EnterpriseUserRoleManagement.jsx";
import EnterpriseAuditLogs from "./pages/EnterpriseAuditLogs.jsx";
import EnterpriseSettingsConfiguration from "./pages/EnterpriseSettingsConfiguration.jsx";

import "./index.css";

function App() {
  return (
    <Router>
      <div className="min-h-screen flex flex-col bg-[#F4EFE6]">
        <Routes>
          {/* ---------- AUTH PAGES ---------- */}
          <Route path="/" element={<CenteredPage><Login /></CenteredPage>} />
          <Route path="/forgot-password" element={<CenteredPage><ForgotPassword /></CenteredPage>} />
          <Route path="/reset-password" element={<CenteredPage><ResetPassword /></CenteredPage>} />

          {/* ---------- USER DASHBOARD ---------- */}
          <Route path="/dashboard" element={<DashboardLayout><Dashboard /></DashboardLayout>} />
          <Route path="/bills" element={<DashboardLayout><Bills /></DashboardLayout>} />
          <Route path="/bill-details" element={<DashboardLayout><BillDetails /></DashboardLayout>} />
          <Route path="/meter-data" element={<DashboardLayout><MeterData /></DashboardLayout>} />
          <Route path="/alerts" element={<DashboardLayout><AlertsNotifications /></DashboardLayout>} />
          <Route path="/profile" element={<DashboardLayout><ProfileSettingsPage /></DashboardLayout>} />

          {/* ---------- ZONE DASHBOARD ---------- */}
          <Route path="/zone-dashboard" element={<ZoneDashboardLayout><ZoneDashboard /></ZoneDashboardLayout>} />
          <Route path="/meter-management" element={<ZoneDashboardLayout><MeterManagement /></ZoneDashboardLayout>} />
          <Route path="/user-management" element={<ZoneDashboardLayout><UserManagement /></ZoneDashboardLayout>} />
          <Route path="/reports" element={<ZoneDashboardLayout><ReportsAndAnalytics /></ZoneDashboardLayout>} />
          <Route path="/settings" element={<ZoneDashboardLayout><SettingsNotifications /></ZoneDashboardLayout>} />

          {/* ---------- ENTERPRISE DASHBOARD ---------- */}
          <Route path="/enterprise-dashboard" element={<EnterpriseDashboardLayout><EnterpriseDashboard /></EnterpriseDashboardLayout>} />
          <Route path="/enterprise-zone-management" element={<EnterpriseDashboardLayout><EnterpriseZoneManagement /></EnterpriseDashboardLayout>} />
          <Route path="/enterprise-meters" element={<EnterpriseDashboardLayout><EnterpriseMeterManagement /></EnterpriseDashboardLayout>} />
          <Route path="/enterprise-user-role-management" element={<EnterpriseDashboardLayout><UserRoleManagement /></EnterpriseDashboardLayout>} />
          <Route path="/enterprise-audit-logs" element={<EnterpriseDashboardLayout><EnterpriseAuditLogs /></EnterpriseDashboardLayout>} />
          <Route path="/enterprise-settings" element={<EnterpriseDashboardLayout><EnterpriseSettingsConfiguration /></EnterpriseDashboardLayout>} />

          {/* ---------- REDIRECTS / FALLBACKS ---------- */}
          <Route path="/enterprise-users" element={<Navigate to="/enterprise-user-role-management" replace />} />
          <Route path="/enterprise-audit" element={<Navigate to="/enterprise-audit-logs" replace />} />
        </Routes>
      </div>
    </Router>
  );
}

// Reusable centered wrapper for auth pages
const CenteredPage = ({ children }) => (
  <div className="flex justify-center items-center flex-grow bg-gradient-to-br from-[#f9fafb] to-[#f3f4f6]">
    {children}
  </div>
);

export default App;
