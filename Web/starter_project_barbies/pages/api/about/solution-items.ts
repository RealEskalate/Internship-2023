import { SolutionItem } from '@/types/about'
import type { NextApiRequest, NextApiResponse } from 'next'

export default async function handler(
  req: NextApiRequest,
  res: NextApiResponse<SolutionItem[] | { message: string }>
) {
  if (req.method === 'GET') {
    await fetchSolutionItems(res)
  } else {
    res.status(404).json({ message: 'Page Not Found' })
  }
}

async function fetchSolutionItems(res: NextApiResponse) {
  try {
    const response = await fetch('http://localhost:5000/solution-items')
    const solutionItems = await response.json()
    res.status(200).json(solutionItems)
  } catch (error) {
    res.status(500).json({ message: 'Internal Server Error' })
  }
}
