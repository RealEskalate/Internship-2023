import sessions from '@/data/about/sessions.json'
import { Session } from '@/types/about'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<Session[] | {message:string}>
) {
  if(req.method === 'GET'){
    res.status(200).json(sessions)
  }else{
    res.status(404).json({message:'Not Found'})
  }
}
