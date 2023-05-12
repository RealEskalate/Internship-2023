import { ProblemItem } from '@/types/about'
import type { NextApiRequest, NextApiResponse } from 'next'

export default async function handler(
  req: NextApiRequest,
  res: NextApiResponse<ProblemItem[] | { message: string }>
) {
  if (req.method === 'GET') {
    await fetchProblemItems(res)
  } else {
    res.status(404).json({ message: 'Page Not Found' })
  }
}

async function fetchProblemItems(res: NextApiResponse) {
  try {
    const response = await fetch('http://localhost:5000/problem-items')
    const problemItems = await response.json()
    res.status(200).json(problemItems)
  } catch (error) {
    res.status(500).json({ message: 'Internal Server Error' })
  }
}
