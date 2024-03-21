import React from 'react';

interface ErrorProps {
  message: string | undefined;
  causedBy: string | undefined;
}

const ErrorCard: React.FC<ErrorProps> = ({ message, causedBy }) => {
  return (
    <div className="flex justify-center items-center h-screen">
      <div className="max-w-md w-full bg-white shadow-md rounded-lg overflow-hidden">
        <div className="px-6 py-4">
          <h2 className="text-xl font-semibold text-red-600 mb-2">Error</h2>
          <p className="text-gray-700 mb-4">{message}</p>
          <p className="text-gray-600">Caused by: {causedBy}</p>
        </div>
      </div>
    </div>
  );
};

export default ErrorCard;
