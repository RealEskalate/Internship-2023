import impactStories from '@/data/home/impact-story.json'
import { ImpactStory } from '@/types/home/impact-story'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<ImpactStory[]>
) {
  const { id } = req.query
  const impactStory = impactStories.filter(
    (story) => story.id.toString() === id
  )
  res.status(impactStory.length ? 200 : 404).json(impactStory)
}
