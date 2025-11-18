import React, { useState } from "react";
import { Link } from "react-router-dom";
import { Mail, ArrowRight, MailCheck } from "lucide-react";

// Mock components - replace with your actual imports
const InputField = ({ type, placeholder, value, onChange, icon }) => {
  return (
    <div className="relative">
      {icon && (
        <div className="absolute left-4 top-1/2 -translate-y-1/2 text-gray-400">
          {icon}
        </div>
      )}
      <input
        type={type}
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        className={`w-full ${icon ? 'pl-12' : 'pl-4'} pr-4 py-3 bg-gray-50 border border-gray-200 rounded-full focus:outline-none focus:ring-2 focus:ring-emerald-500 focus:border-emerald-500 transition-all duration-200 placeholder:text-gray-400 text-gray-800 text-sm`}
      />
    </div>
  );
};

const Button = ({ label, onClick }) => (
  <button
    onClick={onClick}
    className="bg-gradient-to-r from-emerald-400 to-green-500 text-gray-900 px-6 py-3 rounded-full font-semibold hover:from-emerald-500 hover:to-green-600 transform hover:scale-[1.02] active:scale-[0.98] transition-all duration-200 shadow-lg shadow-emerald-500/30 flex items-center justify-center gap-2 group text-sm whitespace-nowrap"
  >
    {label}
    <ArrowRight size={16} className="group-hover:translate-x-1 transition-transform duration-200" />
  </button>
);

const ForgotPassword = () => {
  const [email, setEmail] = useState("");

  return (
    <div className="min-h-screen bg-white flex items-center justify-center p-6 relative overflow-hidden">
      {/* Decorative background elements - subtle */}
      <div className="absolute inset-0 overflow-hidden pointer-events-none">
        <div className="absolute top-10 left-10 w-96 h-96 bg-emerald-100 rounded-full filter blur-3xl opacity-40"></div>
        <div className="absolute bottom-10 right-10 w-96 h-96 bg-teal-100 rounded-full filter blur-3xl opacity-40"></div>
        <div className="absolute top-1/2 left-1/3 w-72 h-72 bg-green-100 rounded-full filter blur-3xl opacity-30"></div>
      </div>

      {/* Forgot Password Card */}
      <div className="relative bg-white p-10 rounded-3xl shadow-2xl shadow-gray-200/50 w-[440px] border border-gray-100">
        {/* Logo/Icon */}
        <div className="flex justify-center mb-6">
          <div className="w-14 h-14 bg-gradient-to-br from-emerald-400 to-green-500 rounded-2xl flex items-center justify-center shadow-lg shadow-emerald-500/40">
            <MailCheck className="text-gray-900" size={24} />
          </div>
        </div>

        {/* Header */}
        <div className="text-center mb-8">
          <h2 className="text-3xl font-bold text-gray-800 mb-2">
            Forgot Password
          </h2>
          <p className="text-gray-500 text-sm">
            Enter your email to receive a reset link
          </p>
        </div>

        {/* Form */}
        <InputField
          type="email"
          placeholder="Email Address"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          icon={<Mail size={18} />}
        />

        {/* Actions */}
        <div className="flex justify-between items-center mt-6 gap-4">
          <a
            href="/"
            className="text-sm text-emerald-600 hover:text-emerald-700 font-medium hover:underline transition-colors"
          >
            Back to Login
          </a>
          <Button
            label="Send Reset Link"
            onClick={() => alert("Reset link sent!")}
          />
        </div>

        {/* Info box */}
        <div className="mt-6 bg-emerald-50 rounded-2xl p-4 text-xs border border-emerald-100">
          <p className="text-emerald-700 leading-relaxed">
            <span className="font-semibold">Note:</span> You'll receive an email with instructions to reset your password. Please check your spam folder if you don't see it.
          </p>
        </div>
      </div>
    </div>
  );
};

export default ForgotPassword;