import React, { useState } from "react";
import { Bell } from "lucide-react";

const notificationsData = [
  {
    id: 1,
    title: "Scheduled Power Maintenance",
    description: "Power maintenance in your area on 26 Oct 2025",
    date: "05 May 2025",
    time: "06:15 PM",
    details:
      "Please note that power maintenance is scheduled in your area on 26 Oct 2025, from 10:00 AM to 2:00 PM. During this time, your electricity supply may be interrupted. We recommend planning your usage accordingly. We apologize for any inconvenience caused and thank you for your understanding.",
  },
  {
    id: 2,
    title: "Billing Reminder",
    description: "Your bill for this month is pending",
    date: "03 May 2025",
    time: "11:00 AM",
    details:
      "Please pay your electricity bill by 12 Oct 2025 to avoid late fees. You can pay online or via our mobile app. Thank you for your prompt attention.",
  },
];

export default function AlertsNotifications() {
  const [selected, setSelected] = useState(notificationsData[0]);

  return (
    <div className="flex flex-col md:flex-row gap-6 p-6 bg-beige-50 min-h-screen">
      {/* Left Column: Notification List */}
      <div className="md:w-[420px] w-full h-[900px] bg-beige-100 p-5 overflow-y-auto rounded-2xl shadow-lg">
        <h2 className="text-2xl font-bold text-green-900 mb-6">Notifications</h2>
        {notificationsData.map((note) => (
          <div
            key={note.id}
            onClick={() => setSelected(note)}
            className={`flex items-start gap-4 p-4 mb-4 rounded-xl cursor-pointer border transition-all duration-200 shadow-sm ${
              selected.id === note.id
                ? "border-green-600 bg-green-50 shadow-md"
                : "border-green-200 hover:bg-green-50 hover:shadow-sm"
            }`}
          >
            <div className="flex-shrink-0 p-3 bg-green-100 rounded-lg flex items-center justify-center">
              <Bell className="w-5 h-5 text-green-700" />
            </div>
            <div className="flex flex-col flex-1">
              <p className="font-semibold text-green-900 text-sm md:text-base">
                {note.title}
              </p>
              <p className="text-green-700 text-xs md:text-sm mt-1 line-clamp-2">
                {note.description}
              </p>
              <p className="text-green-500 text-[10px] md:text-xs mt-1">
                {note.date} | {note.time}
              </p>
            </div>
          </div>
        ))}
      </div>

      {/* Right Column: Notification Details */}
      <div className="md:w-[650px] w-full h-[900px] bg-beige-100 p-6 rounded-2xl shadow-lg overflow-y-auto">
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-2xl font-bold text-green-900">{selected.title}</h2>
          <span className="text-green-500 text-sm">{selected.date} | {selected.time}</span>
        </div>
        <div className="border-b border-green-200 mb-4"></div>
        <p className="text-green-800 text-sm md:text-base whitespace-pre-line leading-relaxed">
          {selected.details}
        </p>
      </div>
    </div>
  );
}
