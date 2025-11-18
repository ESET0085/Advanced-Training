import React from "react";
import { useNavigate } from "react-router-dom";

const Bills = () => {
  const navigate = useNavigate();

  const bills = [
    { month: "Sep 2025", amount: "₹1230.00", due: "12 Oct", status: "Pending" },
    { month: "Aug 2025", amount: "₹1180.00", due: "12 Sep", status: "Paid" },
  ];

  return (
    <div className="flex flex-col gap-6">
      <h1 className="text-2xl font-semibold text-green-800 mb-6">
        My Bills
      </h1>

      <div className="overflow-x-auto shadow-md rounded-2xl">
        <table className="min-w-full border border-green-200 bg-green-50 rounded-xl">
          <thead className="bg-green-100">
            <tr>
              {["Month", "Amount", "Due Date", "Status", "Actions"].map((h, i) => (
                <th
                  key={i}
                  className="py-3 px-4 text-left border-b border-green-200 text-green-900 font-medium"
                >
                  {h}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {bills.map((bill, index) => (
              <tr
                key={index}
                className={`transition-colors duration-200 ${
                  bill.status === "Paid"
                    ? "bg-white hover:bg-green-50"
                    : "bg-white hover:bg-green-100"
                }`}
              >
                <td className="py-3 px-4 border-b border-green-200 text-green-900">
                  {bill.month}
                </td>
                <td className="py-3 px-4 border-b border-green-200 text-green-900">
                  {bill.amount}
                </td>
                <td className="py-3 px-4 border-b border-green-200 text-green-900">
                  {bill.due}
                </td>
                <td
                  className={`py-3 px-4 border-b border-green-200 font-medium ${
                    bill.status === "Paid"
                      ? "text-green-700"
                      : "text-red-600"
                  }`}
                >
                  {bill.status}
                </td>
                <td
                  onClick={() => navigate("/bill-details")}
                  className="py-3 px-4 border-b border-green-200 text-green-700 hover:text-green-900 hover:underline cursor-pointer font-medium"
                >
                  View / Pay
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <p className="mt-6 font-medium text-green-900">
        <span className="font-semibold">Note:</span> All bills are generated on the
        1st of each month.
      </p>
    </div>
  );
};

export default Bills;
