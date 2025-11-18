import React from "react";

const Button = ({
  label,
  text,
  onClick,
  variant = "primary", // choose button style type
  size = "medium", // optional sizes: small | medium | large
  className = "",
  ...props
}) => {
  // Pick whichever prop is passed
  const buttonText = label || text || "Button";

  // Styling variants
  const variantClasses = {
    primary:
      "bg-black text-white border border-black hover:bg-gray-900 hover:shadow-lg",
    secondary:
      "bg-white text-gray-800 border border-gray-400 hover:bg-gray-100 hover:shadow-md",
    danger:
      "bg-red-600 text-white border border-red-600 hover:bg-red-700 hover:shadow-lg",
  };

  // Size presets
  const sizeClasses = {
    small: "w-[140px] h-[28px] text-xs",
    medium: "w-[190px] h-[36px] text-sm",
    large: "w-[220px] h-[44px] text-base",
  };

  return (
    <button
      onClick={onClick}
      {...props}
      className={`rounded-[20px] flex justify-center items-center font-medium transition-all duration-300 active:scale-95 ${variantClasses[variant]} ${sizeClasses[size]} ${className}`}
    >
      {buttonText}
    </button>
  );
};

export default Button;
