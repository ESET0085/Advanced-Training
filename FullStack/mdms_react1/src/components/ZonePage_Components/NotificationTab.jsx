import React, { useState } from "react";
import Button from "../Button.jsx";

const NotificationTab = () => {
  const [email, setEmail] = useState(true);
  const [sms, setSms] = useState(false);
  const [push, setPush] = useState(true);

  const toggles = [
    { label: "Email", value: email, setValue: setEmail },
    { label: "SMS", value: sms, setValue: setSms },
    { label: "Push", value: push, setValue: setPush },
  ];

  return (
    <div className="flex flex-col items-center gap-8 w-full max-w-md mx-auto">
      {toggles.map((toggle, i) => (
        <div
          key={i}
          className="flex justify-between items-center w-full border-b pb-2"
        >
          <span className="text-sm font-medium text-gray-700">
            {toggle.label}
          </span>
          <label className="relative inline-flex items-center cursor-pointer">
            <input
              type="checkbox"
              checked={toggle.value}
              onChange={() => toggle.setValue(!toggle.value)}
              className="sr-only peer"
            />
            <div className="w-11 h-6 bg-gray-200 rounded-full peer peer-checked:bg-indigo-500 after:content-[''] after:absolute after:top-[2px] after:left-[2px] after:bg-white after:h-5 after:w-5 after:rounded-full after:transition-all peer-checked:after:translate-x-full"></div>
          </label>
        </div>
      ))}

      <div className="flex justify-center w-full mt-6">
        <button
  type="button"
  className="bg-indigo-600 hover:bg-indigo-700 text-white font-medium py-2 px-6 rounded-lg shadow-md transition-all duration-200 hover:scale-105 focus:outline-none focus:ring-2 focus:ring-indigo-400 focus:ring-opacity-50"
>
  Save & Continue
</button>

      </div>
    </div>
  );
};

export default NotificationTab;
