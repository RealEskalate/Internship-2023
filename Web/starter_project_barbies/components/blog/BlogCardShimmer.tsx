import React from 'react';

export const BlogCardLoading = () => {
  return (
    <div className="w-full sm:w-72 h-full bg-white hover:bg-gray-200 m-2 rounded-lg shadow-lg overflow-hidden">
      {/* Image part */}
      <div className="relative h-40 w-full bg-gray-200" />

      {/* Wrapper div */}
      <div className="p-4">

        {/* Title part */}
        <div className="h-6 w-5/6 bg-gray-200 mb-2" />

        {/* profileImg, Author Name, and Date */}
        <div className="flex items-center space-x-1 mb-2">
          <div className="h-6 w-6 bg-gray-200 rounded-full" />
          <div className="h-4 w-32 bg-gray-200" />
          <div className="h-4 w-12 bg-gray-200" />
        </div>

        {/* Blog Content here */}
        <div className="h-14 w-full bg-gray-200 mb-4" />

        {/* Tags */}
        <div className="flex flex-wrap gap-2">
          <div className="h-6 w-14 bg-gray-200 rounded-xl" />
          <div className="h-6 w-14 bg-gray-200 rounded-xl" />
          <div className="h-6 w-14 bg-gray-200 rounded-xl" />
        </div>

        {/* Pending/Likes and Read More buttons */}
        <div className="flex justify-between items-center mt-4">
          <div className="h-6 w-12 bg-gray-200" />
          <div className="h-6 w-16 bg-gray-200" />
        </div>
      </div>
    </div>
  );
};
