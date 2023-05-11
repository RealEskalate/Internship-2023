import solutionItems from '@/data/about/solution-items.json'
import { SolutionItem } from '@/types/about'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<SolutionItem[] | {message:string}>
) {
  if(req.method === 'GET'){
    res.status(200).json(solutionItems)
  }else{
    res.status(404).json({message:'Not Found'})
  }
}
