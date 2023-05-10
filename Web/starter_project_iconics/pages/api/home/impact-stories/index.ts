import impactStories from '@/data/home/impact-story.json'
import { ImpactStory } from '@/types/home/impact-story'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<ImpactStory[]>
) {
  res.status(200).json(impactStories)
}
