import { NextApiRequest, NextApiResponse } from 'next';
import { Blog } from '@/types/blog';

export default async function handler(req: NextApiRequest, res: NextApiResponse) {
  const {
    query: { id },
    method,
  } = req;

  if (method === 'GET') {
    await handleGetBlogByID(id as string, res);
  } else {
    res.status(405).json({ message: 'Method Not Allowed' });
  }
}

async function handleGetBlogByID(id: string, res: NextApiResponse) {
  try {
    const response = await fetch(`http://localhost:5000/blogs/${id}`);

    if (response.status === 404) {
      res.status(404).json({ message: 'Blog not found' });
      return;
    }

    const blog: Blog = await response.json();

    res.status(200).json(blog);
  } catch (error) {
    res.status(500).json({ message: 'Internal Server Error' });
  }
}
