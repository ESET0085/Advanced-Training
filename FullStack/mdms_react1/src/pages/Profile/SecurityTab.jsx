import { useState } from "react";
import InputField from "../../components/InputField.jsx";
import Button from "../../components/Button.jsx";

export default function SecurityTab() {
  const [currentPassword, setCurrentPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  return (
    <div className="flex flex-col items-center w-full max-w-md bg-amber-50 dark:bg-gray-800 rounded-2xl shadow-md p-10 transition-all duration-300">
      {/* Icon */}
      <div className="w-16 h-16 bg-green-700 rounded-full flex items-center justify-center mb-6">
        <i className="ri-lock-line text-white text-2xl"></i>
      </div>

      {/* Form */}
      <form className="flex flex-col gap-4 items-center w-full">
        <InputField
          type="password"
          value={currentPassword}
          onChange={(e) => setCurrentPassword(e.target.value)}
          placeholder="Current password"
        />
        <InputField
          type="password"
          value={newPassword}
          onChange={(e) => setNewPassword(e.target.value)}
          placeholder="New password"
        />
        <InputField
          type="password"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
          placeholder="Confirm password"
        />
        <div className="mt-6 flex justify-center w-full">
          <Button
            label="Save and Continue"
            onClick={() => alert("Password updated!")}
            className="bg-green-700 hover:bg-green-800 text-white"
          />
        </div>
      </form>
    </div>
  );
}
