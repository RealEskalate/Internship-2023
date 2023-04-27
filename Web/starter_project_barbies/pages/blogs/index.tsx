import { BlogsList } from "@/components/blog/BlogsList";
import { Pagination } from "@/components/common/Pagination";
import { SearchForm } from "@/components/common/SearchForm";
import React, { useEffect, useState } from "react";
import { Blog } from "@/types/blog";

const fetchBlogs = async (): Promise<Blog[]> => {
  const result = await fetch("/data/blogs.json");
  const data = await result.json();
  return data;
}

const Blogs = () => {
  const [blogs, setBlogs] = useState<Blog[]>([])

  useEffect(() => {
    const fetchData = async () => {
      const blogs = await fetchBlogs();
      setBlogs(blogs)
    };

    fetchData()

  }, []);

  console.log(blogs)

  return (
    <div className='bg-white text-primary-text font-montserrat'>

      {/* Title and search bar */}
      <div className="flex justify-center pt-20">
        <div className='grid grid-cols-3 mt-2 w-full'>
          <div className="flex items-center">
            <div className='ps-28 text-xl font-semibold'>
              Blogs
            </div>
          </div>
          <div className='flex justify-center'>
            <SearchForm />
          </div>
          <div />
        </div>
      </div>

      {/* Blog list */}
      <div className="mt-10 px-56">
        <BlogsList blogs={blogs} />
      </div>

      {/* Pagination */}
      <Pagination numberOfPages={5} />

    </div>
  )
}

export default Blogs;