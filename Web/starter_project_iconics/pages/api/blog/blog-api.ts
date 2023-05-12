// Next.js API route support: https://nextjs.org/docs/api-routes/introduction
import { Blog } from '@/types/blog/blog'
import type { NextApiRequest, NextApiResponse } from 'next'
import blogsData from '../../../data/blog/blog.json'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<Blog[]>
) {
  res.status(200).json(blogsData.blogs)
}
