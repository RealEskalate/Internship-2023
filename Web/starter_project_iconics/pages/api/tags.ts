// Next.js API route support: https://nextjs.org/docs/api-routes/introduction
import tags from '@/data/blog/tags.json'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<string[]>
) {
  res.status(200).json(tags)
}
