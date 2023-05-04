import { NextApiRequest, NextApiResponse } from "next";
import fs from "fs";
import { Blog } from "@/types/blog";

const fetchBlogs = async (): Promise<Blog[]> => {
  const filePath = "./data/blogs.json";
  const data = await fs.promises.readFile(filePath, "utf-8");
  return JSON.parse(data);
};

export default async function handler(
  req: NextApiRequest,
  res: NextApiResponse<Blog[]>
) {
  const data = await fetchBlogs();
  res.status(200).json(data);
}
