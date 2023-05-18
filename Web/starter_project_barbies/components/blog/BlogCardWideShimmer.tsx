import React from 'react';

export const BlogCardWideShimmer = () => {
  return (
    <div className="mb-6">
      {/* Horizontal divider */}
      <hr className="mx-4 h-2" />

      <div className="grid grid-cols-2" style={{ gridTemplateColumns: '70% 30%' }}>
        <div className="flex mt-6">
          <div className="flex flex-col">
            {/* Author details */}
            <div className="animate-pulse flex items-center mb-4">
              <div className="h-10 w-10 bg-gray-200 rounded-full mr-2" />
              <div className="flex flex-col">
                <div className="h-4 w-20 bg-gray-200 rounded mb-1" />
                <div className="h-3 w-16 bg-gray-200 rounded" />
              </div>
            </div>
            {/* Blog title */}
            <div className="animate-pulse mt-4 font-semibold text-xl">
              <div className="h-7 w-96 bg-gray-200 rounded mb-4" />
            </div>
            {/* Blog description */}
            <div className="animate-pulse mt-6">
              <div className="h-4 w-60 bg-gray-200 rounded mb-2" />
              <div className="h-4 w-40 bg-gray-200 rounded" />
            </div>
            {/* Blog tags */}
            <div className="animate-pulse mt-6">
              <div className="flex space-x-2">
                <div className="h-4 w-16 bg-gray-200 rounded" />
                <div className="h-4 w-16 bg-gray-200 rounded" />
                <div className="h-4 w-16 bg-gray-200 rounded" />
              </div>
            </div>
          </div>
        </div>
        {/* Blog image */}
        <div className="animate-pulse flex items-center justify-center">
          <div className="h-36 w-96 bg-gray-200 rounded" />
        </div>
      </div>
    </div>
  );
};
