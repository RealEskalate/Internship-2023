import projects from '@/data/about/projects.json'
import { Project } from '@/types/about'
import type { NextApiRequest, NextApiResponse } from 'next'

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<Project[] | {message:string}>
) {
  if(req.method === 'GET'){
    res.status(200).json(projects)
  }else{
    res.status(404).json({message:'Not Found'})
  }
}
