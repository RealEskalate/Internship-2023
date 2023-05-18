import type { NextApiRequest, NextApiResponse } from 'next'
import teamMembers from '../../data/teams/team-members.json'
import { TeamMember } from '@/types/teams'

export default function getTeamMembers(
  req: NextApiRequest,
  res: NextApiResponse<TeamMember[]>
) {
  res.status(200).json(teamMembers)
}

