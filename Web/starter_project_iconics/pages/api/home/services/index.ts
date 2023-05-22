import services from '@/data/home/service.json'
import { Service } from '@/types/home/service'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<Service[]>
) {
  res.status(200).json(services)
}
