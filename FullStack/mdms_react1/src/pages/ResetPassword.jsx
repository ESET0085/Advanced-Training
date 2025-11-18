import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Lock, Mail, ArrowRight, Eye, EyeOff, KeyRound } from "lucide-react";

// Mock components - replace with your actual imports
const InputField = ({ type, placeholder, value, onChange, icon }) => {
  const [showPassword, setShowPassword] = useState(false);
  const inputType = type === "password" && showPassword ? "text" : type;
  
  return (
    <div className="relative">
      {icon && (
        <div className="absolute left-4 top-1/2 -translate-y-1/2 text-gray-400">
          {icon}
        </div>
      )}
      <input
        type={inputType}
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        className={`w-full ${icon ? 'pl-12' : 'pl-4'} ${type === 'password' ? 'pr-12' : 'pr-4'} py-3 bg-gray-50 border border-gray-200 rounded-full focus:outline-none focus:ring-2 focus:ring-emerald-500 focus:border-emerald-500 transition-all duration-200 placeholder:text-gray-400 text-gray-800 text-sm`}
      />
      {type === "password" && (
        <button
          type="button"
          onClick={() => setShowPassword(!showPassword)}
          className="absolute right-4 top-1/2 -translate-y-1/2 text-gray-400 hover:text-gray-600 transition-colors"
        >
          {showPassword ? <EyeOff size={18} /> : <Eye size={18} />}
        </button>
      )}
    </div>
  );
};

const Button = ({ label, onClick }) => (
  <button
    onClick={onClick}
    className="w-full bg-gradient-to-r from-emerald-400 to-green-500 text-gray-900 py-3 rounded-full font-semibold hover:from-emerald-500 hover:to-green-600 transform hover:scale-[1.02] active:scale-[0.98] transition-all duration-200 shadow-lg shadow-emerald-500/30 flex items-center justify-center gap-2 group text-sm"
  >
    {label}
    <ArrowRight size={16} className="group-hover:translate-x-1 transition-transform duration-200" />
  </button>
);

const ResetPassword = () => {
  const [email, setEmail] = useState("");
  const [oldPassword, setOldPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");

  const handleResetPassword = () => {
    const trimmedEmail = email.trim().toLowerCase();
    const trimmedOldPassword = oldPassword.trim();
    const trimmedNewPassword = newPassword.trim();

    // Validation
    if (!trimmedEmail || !trimmedOldPassword || !trimmedNewPassword) {
      alert("Please fill all fields");
      return;
    }

    // Check if old password is correct (same logic as login)
    if (
      (trimmedEmail === "admin@test.com" || 
       trimmedEmail === "user@test.com" || 
       trimmedEmail === "enterprise@test.com") && 
      trimmedOldPassword === "1234"
    ) {
      alert("Password updated successfully! Please login with your new password.");
      // In real app, navigate to login page here
      window.location.href = "/";
    } else {
      alert("Invalid email or old password");
    }
  };

  return (
    <div className="min-h-screen bg-white flex items-center justify-center p-6 relative overflow-hidden">
      {/* Decorative background elements - subtle */}
      <div className="absolute inset-0 overflow-hidden pointer-events-none">
        <div className="absolute top-10 left-10 w-96 h-96 bg-emerald-100 rounded-full filter blur-3xl opacity-40"></div>
        <div className="absolute bottom-10 right-10 w-96 h-96 bg-teal-100 rounded-full filter blur-3xl opacity-40"></div>
        <div className="absolute top-1/2 left-1/3 w-72 h-72 bg-green-100 rounded-full filter blur-3xl opacity-30"></div>
      </div>

      {/* Reset Password Card */}
      <div className="relative bg-white p-10 rounded-3xl shadow-2xl shadow-gray-200/50 w-[440px] border border-gray-100">
        {/* Logo/Icon */}
        <div className="flex justify-center mb-6">
          <div className="w-14 h-14 bg-gradient-to-br from-emerald-400 to-green-500 rounded-2xl flex items-center justify-center shadow-lg shadow-emerald-500/40">
            <KeyRound className="text-gray-900" size={24} />
          </div>
        </div>

        {/* Header */}
        <div className="text-center mb-8">
          <h2 className="text-3xl font-bold text-gray-800 mb-2">
            Reset Password
          </h2>
          <p className="text-gray-500 text-sm">
            Enter your credentials and new password
          </p>
        </div>

        {/* Form */}
        <div className="flex flex-col gap-4">
          <InputField
            type="email"
            placeholder="Email Address"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            icon={<Mail size={18} />}
          />
          <InputField
            type="password"
            placeholder="Old Password"
            value={oldPassword}
            onChange={(e) => setOldPassword(e.target.value)}
            icon={<Lock size={18} />}
          />
          <InputField
            type="password"
            placeholder="New Password"
            value={newPassword}
            onChange={(e) => setNewPassword(e.target.value)}
            icon={<KeyRound size={18} />}
          />
        </div>

        {/* Update Button */}
        <div className="mt-6">
          <Button label="Update Password" onClick={handleResetPassword} />
        </div>

        {/* Back to login link */}
        <div className="mt-6 text-center">
          <a
            href="/"
            className="text-sm text-emerald-600 hover:text-emerald-700 font-medium hover:underline transition-colors"
          >
            Back to Login
          </a>
        </div>
      </div>
    </div>
  );
};

export default ResetPassword;