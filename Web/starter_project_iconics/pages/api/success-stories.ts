import type { NextApiRequest, NextApiResponse } from 'next'
import { SuccessStory } from '../../types/story/success-stories'
import story from '../../data/story/success-stories.json'


export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<SuccessStory[]>
) {
  res.status(200).json(story)
}
