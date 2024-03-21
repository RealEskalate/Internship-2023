import React from "react";
interface InputProps {
  value: string;
  onChange: (e: string) => void;
  placeholder?: string;
}
function Input({ value, onChange, placeholder }: InputProps) {
  return (
    <input
      type="text"
      placeholder={placeholder}
      onChange={(e) => onChange(e.target.value)}
      value={value}
      className=" bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5"
    />
  );
}

export default Input;
