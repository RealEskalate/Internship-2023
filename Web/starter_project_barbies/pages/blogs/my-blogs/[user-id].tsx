import { NextPage } from "next";
import { useRouter } from "next/router";
import { useState, useEffect } from "react";
import { Blog } from "@/types/blog";
import BlogCard from "@/components/blog/BlogCard";

const MyBlogs: NextPage = () => {
  const [blogs, setBlogs] = useState<Blog[]>([]);

  // Get userID from router
  const router = useRouter();
  const userID = router.query["user-id"];

  // Fetch data
  const fetchData = async () => {
    const res = await fetch("/api/blogs");
    const allBlogs = await res.json();
    const userBlogs = allBlogs.filter((blog : Blog) => blog.userID === userID);
    setBlogs(userBlogs);
  };

  useEffect(() => {
    if (userID) {
      fetchData();
    }

  }, [userID]);

  // Check if the user has any blogs
  if (blogs.length === 0) {
    return <p>You do not have any blogs to manage.</p>;
  }

  return (
    <div className="mt-3 mb-5 mx-2">
      <div className="ml-2 mb-3">
        <h1 className="font-medium text-2xl">Manage Blogs</h1>
        <p>Edit, Delete and View the status of your blog</p>
      </div>
      <div className="flex flex-wrap justify-start gap-2">
        {blogs.map((blog,index) => (
          <div key={index} className="flex flex-wrap">
            <BlogCard  blog={blog} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default MyBlogs;
