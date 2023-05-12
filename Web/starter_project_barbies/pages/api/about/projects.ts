import { Project } from '@/types/about'
import type { NextApiRequest, NextApiResponse } from 'next'

export default async function handler(
  req: NextApiRequest,
  res: NextApiResponse<Project[] | { message: string }>
) {
  if (req.method === 'GET') {
    await fetchProjects(res)
  } else {
    res.status(404).json({ message: 'Page Not Found' })
  }
}

async function fetchProjects(res: NextApiResponse) {
  try {
    const response = await fetch('http://localhost:5000/projects')
    const projects = await response.json()
    res.status(200).json(projects)
  } catch (error) {
    res.status(500).json({ message: 'Internal Server Error' })
  }
}
