import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Lock, Mail, ArrowRight, Eye, EyeOff } from "lucide-react";

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

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = () => {
    const trimmedEmail = email.trim().toLowerCase();
    const trimmedPassword = password.trim();

    if (trimmedEmail === "admin@test.com" && trimmedPassword === "1234") {
      navigate("/zone-dashboard");
    } else if (trimmedEmail === "user@test.com" && trimmedPassword === "1234") {
      navigate("/dashboard");
    } else if (trimmedEmail === "enterprise@test.com" && trimmedPassword === "1234") {
      navigate("/enterprise-dashboard");
    } else {
      alert("Invalid credentials");
    }
  };

  return (
    <div className="min-h-screen w-full bg-gradient-to-br from-emerald-50 via-teal-50 to-green-50 flex items-center justify-center p-6 relative overflow-hidden">
      {/* Enhanced decorative background elements */}
      <div className="absolute inset-0 overflow-hidden pointer-events-none">
        <div className="absolute top-10 left-10 w-96 h-96 bg-emerald-200 rounded-full filter blur-3xl opacity-30"></div>
        <div className="absolute bottom-10 right-10 w-96 h-96 bg-teal-200 rounded-full filter blur-3xl opacity-30"></div>
        <div className="absolute top-1/2 left-1/3 w-72 h-72 bg-green-200 rounded-full filter blur-3xl opacity-25"></div>
      </div>

      {/* Login Card - Clean white card */}
      <div className="relative bg-white p-10 rounded-3xl shadow-2xl shadow-gray-300/50 w-[440px] border border-gray-100">
        {/* Logo/Icon */}
        <div className="flex justify-center mb-6">
          <div className="w-14 h-14 bg-gradient-to-br from-emerald-400 to-green-500 rounded-2xl flex items-center justify-center shadow-lg shadow-emerald-500/40">
            <Lock className="text-gray-900" size={24} />
          </div>
        </div>

        {/* Header */}
        <div className="text-center mb-8">
          <h2 className="text-3xl font-bold text-gray-800 mb-2">
            Welcome Back
          </h2>
          <p className="text-gray-500 text-sm">
            Sign in to continue to your dashboard
          </p>
        </div>

        {/* Form */}
        <div className="flex flex-col gap-4 mb-4">
          <InputField
            type="email"
            placeholder="Email Address"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            icon={<Mail size={18} />}
          />
          <InputField
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            icon={<Lock size={18} />}
          />
        </div>

        {/* Remember & Forgot & Reset */}
        <div className="flex justify-between items-center mb-6 text-xs">
          <label className="flex items-center gap-2 cursor-pointer group">
            <input
              type="checkbox"
              id="remember"
              className="w-4 h-4 accent-emerald-500 cursor-pointer rounded"
            />
            <span className="text-gray-600 group-hover:text-gray-800 transition-colors">
              Remember me
            </span>
          </label>
          <div className="flex flex-col items-end gap-1">
            <Link
              to="/forgot-password"
              className="text-emerald-600 hover:text-emerald-700 font-medium hover:underline transition-colors"
            >
              Forgot password?
            </Link>
            <Link
              to="/reset-password"
              className="text-emerald-600 hover:text-emerald-700 font-medium hover:underline transition-colors"
            >
              Reset password
            </Link>
          </div>
        </div>

        {/* Login Button */}
        <Button label="Sign In" onClick={handleLogin} />

        {/* Demo Info - Compact */}
        <div className="mt-6 bg-emerald-50 rounded-2xl p-4 text-xs border border-emerald-100">
          <p className="font-semibold text-emerald-700 mb-2">Test Accounts:</p>
          <div className="space-y-1.5 text-emerald-600">
            <p className="flex items-center gap-2">
              <span className="w-2 h-2 bg-emerald-500 rounded-full"></span>
              admin@test.com
            </p>
            <p className="flex items-center gap-2">
              <span className="w-2 h-2 bg-emerald-500 rounded-full"></span>
              user@test.com
            </p>
            <p className="flex items-center gap-2">
              <span className="w-2 h-2 bg-emerald-500 rounded-full"></span>
              enterprise@test.com
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;