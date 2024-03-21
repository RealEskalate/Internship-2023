import { SuccessStory } from '@/types/success-story'
import type { NextApiRequest, NextApiResponse } from 'next'
import successStoryjsonData from '../../data/success-story.json'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<SuccessStory[]>
) {
  res.status(200).json(successStoryjsonData['success-story'])
}
