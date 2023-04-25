import { NextPage } from "next";
import { useRouter } from "next/router";
import { useState, useEffect } from "react";
import { Blog } from "@/types/blog";
import BlogCard from "@/components/blog/BlogCard";


// Fetch blogs from dummyData.json file 
const fetchBlogs = async (): Promise<Blog[]> => {
  const res = await fetch("/data/dummyData.json");
  const data = await res.json();
  
  return data;
};

const MyBlogs: NextPage = () => {
  const [blogs, setBlogs] = useState<Blog[]>([]);

  // Get userID from router
  const router = useRouter();
  const userID = router.query["my-blogs"];
  
  useEffect(() => {
    const fetchData = async () => {
      const allBlogs = await fetchBlogs();
      const userBlogs = allBlogs.filter((blog) => blog.userID === userID);
      setBlogs(userBlogs);
    };

    if (userID) {
      fetchData();
    }

  }, [userID]);

  // Check if userID is valid
  if (!userID) {
    return (
      <p>
        Oops! It looks like you don't have any blogs to manage yet. Why not create a new blog post and start sharing your thoughts with the world?
      </p>
    );
  }
  

  // Check if the user has any blogs
  if (blogs.length === 0) {
    return <p>
        Oops! It looks like you don't have any blogs to manage yet. Why not create a new blog post and start sharing your thoughts with the world?
  </p>
  }

  return (
    <div className="mt-3 mb-5 mx-2">
      <div className="ml-2 mb-3">
        <h1 className="font-medium text-2xl">Manage Blogs</h1>
        <p>Edit, Delete and View the status of your blog</p>
      </div>
      <div className="flex flex-wrap justify-start gap-2">
        {blogs.map((blog) => (
          <div className="flex flex-wrap">
            <BlogCard key={blog.blogID} blog={blog} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default MyBlogs;
