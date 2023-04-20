import React from 'react';
import Image from 'next/image';
import Link from 'next/link';
import { Blog } from '@/types/blog//Blog';
import {formatDate} from "@/utils/dateFormatter";
import LikeButton from './LikeButton';


type BlogProps = {
  blog: Blog;
};

const BlogCard: React.FC<BlogProps> = ({ blog }) => {
  // formate date 
  const date = new Date(blog.date);
  const formattedDate = formatDate(date);

  return (
    <div>
      {/* Card  */}
      <div className="w-full sm:w-72 h-full bg-white hover:bg-gray-200 m-2 rounded-lg shadow-lg overflow-hidden">
        {/* Image part */}
        <div className="relative h-40 w-full">
          <Image src={blog.blogImage} alt={blog.title} layout="fill" objectFit="cover" />
        </div>

        {/* Wrapper div  */}
        <div className="p-4">

          {/* Title part */}
          <h2 className="text-xl font-semibold mb-2">{blog.title}</h2>

          {/* profileImg,Author Name and Date */}
          <div className="flex items-center space-x-1 mb-2">
            <Image src={blog.author.image} alt={blog.author.name} width={32} height={32} className="rounded-full" />
            <p className="text-gray-600 font-medium">By {blog.author.name}</p>
            <p className="text-gray-500 text-sm">| {formattedDate}</p>
          </div>

          {/* Blog Contente here */}
          <p className="text-gray-700 mb-4 line-clamp-2">{blog.content}</p>

          {/* Tags */}
          <div className="flex flex-wrap gap-2">
            {blog.tags.map((tag) => (
              <button
                key={tag}
                className="bg-gray-200 text-gray-700 rounded-xl px-4 py-1 hover:bg-gray-300 focus:outline-none focus:ring-2 focus:ring-gray-400"
              >
                {tag}
              </button>
            ))}
          </div>
          
          {/* Pending/Likes and Read More buttons */}
          <div className="flex justify-between items-center mt-4">
            <LikeButton />
            <Link className="text-indigo-500 hover:text-blue-800" href={`blog/${blog.blogID}`}>
              Read more
            </Link>
          </div>
          
        </div>

      </div>


    </div>
  );
};

export default BlogCard;