import { NextPage } from "next";
import { useRouter } from "next/router";
import { Blog } from "@/types/blog";
import BlogCard from "@/components/blog/BlogCard";
import { useGetBlogsByUserIDQuery } from "@/store/blog/blogs-api";

const MyBlogs: NextPage = () => {
  const router = useRouter();
  const userID = router.query["user-id"];
  
  const { data: blogs,
     isLoading,
     isError,
     error
    } = useGetBlogsByUserIDQuery(userID as string);
  
  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return (
      <div>
        <p>Error occurred while fetching blogs.</p>
        <p>Error message: {JSON.stringify(error)}</p>
      </div>
    );
  }
  
  // Check if the user has any blogs
  if (!blogs || blogs.length === 0) {
    return <p>You do not have any blogs to manage.</p>;
  }

  return (
    <div className="mt-3 mb-5 mx-2">
      <div className="ml-2 mb-3">
        <h1 className="font-medium text-2xl">Manage Blogs</h1>
        <p>Edit, Delete and View the status of your blog</p>
      </div>
      <div className="flex flex-wrap justify-start gap-2">
        {blogs.map((blog: Blog, index: number) => (
          <div key={index} className="flex flex-wrap">
            <BlogCard blog={blog} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default MyBlogs;
