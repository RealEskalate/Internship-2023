import problemItems from '@/data/about/problem-items.json'
import { ProblemItem } from '@/types/about'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<ProblemItem[] | {message:string}>
) {
  if(req.method === 'GET'){
    res.status(200).json(problemItems)
  }else{
    res.status(404).json({message:'Not Found'})
  }
}
