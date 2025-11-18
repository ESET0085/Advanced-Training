import React from "react";
import { motion } from "framer-motion";

const AddZoneDialog = ({ onClose }) => {
  return (
    <motion.div
      className="fixed top-0 right-0 w-[463px] h-full bg-white dark:bg-gray-900 shadow-2xl p-8 z-50 border-l border-gray-200 dark:border-gray-700"
      initial={{ x: "100%" }}
      animate={{ x: 0 }}
      exit={{ x: "100%" }}
      transition={{ type: "spring", stiffness: 70 }}
    >
      <div className="flex justify-between items-center mb-6">
        <h2 className="text-xl font-semibold text-gray-800 dark:text-gray-100">
          Add Zone
        </h2>
        <button
          onClick={onClose}
          className="text-gray-400 hover:text-gray-600 dark:hover:text-gray-300"
        >
          ✕
        </button>
      </div>

      <p className="text-gray-500 text-sm mb-6">
        This is a dialogue for adding zone
      </p>

      <form className="space-y-5">
        <div>
          <label className="block text-gray-700 dark:text-gray-300 mb-1">
            Zone name
          </label>
          <input
            type="text"
            placeholder="Mangalore"
            className="w-full border border-gray-300 dark:border-gray-600 rounded-md p-2 bg-transparent"
          />
        </div>

        <div>
          <label className="block text-gray-700 dark:text-gray-300 mb-1">
            Admin
          </label>
          <select className="w-full border border-gray-300 dark:border-gray-600 rounded-md p-2 bg-transparent">
            <option>axys</option>
            <option>abc</option>
            <option>xyz</option>
          </select>
        </div>

        <div>
          <label className="block text-gray-700 dark:text-gray-300 mb-1">
            Location
          </label>
          <input
            type="text"
            placeholder="Address or pincode"
            className="w-full border border-gray-300 dark:border-gray-600 rounded-md p-2 bg-transparent"
          />
        </div>

        <div>
          <label className="block text-gray-700 dark:text-gray-300 mb-1">
            Description
          </label>
          <textarea
            placeholder="Description here"
            className="w-full border border-gray-300 dark:border-gray-600 rounded-md p-2 bg-transparent"
          ></textarea>
        </div>

        <button
          type="button"
          className="w-full py-3 rounded-md bg-black text-white hover:bg-gray-800 transition"
        >
          Add Zone
        </button>
      </form>
    </motion.div>
  );
};

export default AddZoneDialog;
