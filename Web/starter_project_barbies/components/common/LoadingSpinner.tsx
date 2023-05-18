import React from 'react';

// This component is used to render a loading spinner that is centered in its parent component.
export const LoadingSpinner = () => {
  return (
    <div className="flex justify-center items-center h-screen">
      <div className="w-16 h-16 border-t-4 border-b-4 border-gray-400 rounded-full animate-spin" />
    </div>
  )
}
