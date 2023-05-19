import { Blog } from '@/types/blog/blog'
import type { NextApiRequest, NextApiResponse } from 'next'
import blogsJsonData from '@/data/blogs.json'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<Blog[]>
) {
  if (req.method == 'GET') {
    res.status(200).json(blogsJsonData.blogs)
  }
  if (req.method === 'POST') {
    blogsJsonData.blogs.push(req.body)

    res.status(201).json(blogsJsonData.blogs)
  }
}
