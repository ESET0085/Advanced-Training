import React, { useState, useRef, useEffect } from "react";
import { MoreVertical } from "lucide-react";

const TableActionMenu = () => {
  const [open, setOpen] = useState(false);
  const ref = useRef();

  useEffect(() => {
    const handleClickOutside = (e) => {
      if (ref.current && !ref.current.contains(e.target)) setOpen(false);
    };
    document.addEventListener("click", handleClickOutside);
    return () => document.removeEventListener("click", handleClickOutside);
  }, []);

  return (
    <div className="relative" ref={ref}>
      <button
        onClick={() => setOpen(!open)}
        className="p-1 rounded hover:bg-gray-200 dark:hover:bg-gray-700"
      >
        <MoreVertical size={18} />
      </button>

      {open && (
        <div className="absolute right-0 mt-2 w-32 bg-white dark:bg-gray-800 shadow-md border border-gray-200 dark:border-gray-700 rounded-md text-sm z-20">
          <ul className="py-1">
            <li className="px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-700 cursor-pointer">
              View
            </li>
            <li className="px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-700 cursor-pointer">
              Edit
            </li>
            <li className="px-4 py-2 text-red-500 hover:bg-gray-100 dark:hover:bg-gray-700 cursor-pointer">
              Delete
            </li>
          </ul>
        </div>
      )}
    </div>
  );
};

export default TableActionMenu;
