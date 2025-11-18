"use client";
import { useState } from "react";
import { User, Shield, Bell } from "lucide-react";
import ProfileTab from "./ProfileTab";
import SecurityTab from "./SecurityTab";
import Notifications from "./Notifications";

export default function ProfileSettingsPage() {
  const [activeTab, setActiveTab] = useState("profile");

  const tabs = [
    { key: "profile", label: "Profile", icon: <User className="w-5 h-5 mr-2" /> },
    { key: "security", label: "Security", icon: <Shield className="w-5 h-5 mr-2" /> },
    { key: "notification", label: "Notification", icon: <Bell className="w-5 h-5 mr-2" /> },
  ];

  return (
    <div className="flex flex-col items-center w-full bg-amber-50 min-h-screen transition-colors duration-300">
      {/* Page Title */}
      <h1 className="text-2xl font-semibold text-green-800 mt-10 text-center">
        Profile & Settings
      </h1>

      {/* Tabs */}
      <div className="flex space-x-10 mb-8 mt-10 border-b border-amber-300 w-full max-w-3xl justify-center">
        {tabs.map((tab) => (
          <button
            key={tab.key}
            onClick={() => setActiveTab(tab.key)}
            className={`flex items-center pb-3 text-sm font-medium transition-all duration-200 ${
              activeTab === tab.key
                ? "text-green-700 border-b-2 border-green-700"
                : "text-gray-600 hover:text-green-700"
            }`}
          >
            {tab.icon}
            {tab.label}
          </button>
        ))}
      </div>

      {/* Tab Content */}
      <div className="flex justify-center w-full mb-10">
        <div className="w-full flex justify-center max-w-5xl">
          {activeTab === "profile" && <ProfileTab />}
          {activeTab === "security" && <SecurityTab />}
          {activeTab === "notification" && <Notifications />}
        </div>
      </div>
    </div>
  );
}
