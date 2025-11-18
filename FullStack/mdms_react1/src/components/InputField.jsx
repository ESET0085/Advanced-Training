import React from "react";

const InputField = ({
  type = "text",
  placeholder = "Enter text",
  value,
  onChange,
  className = "",
  ...props
}) => {
  return (
    <input
      type={type}
      placeholder={placeholder}
      value={value}
      onChange={onChange}
      {...props}
      className={`w-[361px] h-[40px] rounded-[16px] 
        bg-[#EAEAEA] opacity-100 px-4 
        text-gray-800 text-sm outline-none 
        focus:ring-2 focus:ring-blue-400 focus:bg-white
        transition-all duration-300 ${className}`}
    />
  );
};

export default InputField;
