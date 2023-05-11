import { NextApiRequest, NextApiResponse } from 'next';
import { Blog } from '@/types/blog';

export default async function handler(req: NextApiRequest, res: NextApiResponse) {
  if (req.method === 'GET') {
    await handleGetBlogs(res);
  } else {
    res.status(405).json({ message: 'Method Not Allowed' });
  }
}

async function handleGetBlogs(res: NextApiResponse) {
  try {
    const response = await fetch('http://localhost:5000/blogs');
    const blogs: Blog[] = await response.json();

    res.status(200).json(blogs);
  } catch (error) {
    res.status(500).json({ message: 'Internal Server Error' });
  }
}
