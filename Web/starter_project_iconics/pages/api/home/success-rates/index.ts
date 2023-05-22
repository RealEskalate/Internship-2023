import successRates from '@/data/home/success-rate.json'
import { Success } from '@/types/home/success-rate'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<Success[]>
) {
  res.status(200).json(successRates)
}
