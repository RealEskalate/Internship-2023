import { Session } from '@/types/about'
import type { NextApiRequest, NextApiResponse } from 'next'

export default async function handler(
  req: NextApiRequest,
  res: NextApiResponse<Session[] | { message: string }>
) {
  if (req.method === 'GET') {
    await fetchSessions(res)
  } else {
    res.status(404).json({ message: 'Page Not Found' })
  }
}

async function fetchSessions(res: NextApiResponse) {
  try {
    const response = await fetch('http://localhost:5000/sessions')
    const sessions = await response.json()
    res.status(200).json(sessions)
  } catch (error) {
    res.status(500).json({ message: 'Internal Server Error' })
  }
}
