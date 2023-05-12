import { Blog } from '@/types/blog/blog'
import type { NextApiRequest, NextApiResponse } from 'next'
import successStoryjsonData from '../../data/blogs.json'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<Blog[]>
) {
  res.status(201).json(successStoryjsonData['blogs'])
}
