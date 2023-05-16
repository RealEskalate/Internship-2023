import type { NextApiRequest, NextApiResponse } from 'next'
import teamMembers from '../../data/teams/team-members.json'
import { TeamMember } from '@/types/teams'
type Data = { data: TeamMember[] }

export default function getTeamMembers(
  req: NextApiRequest,
  res: NextApiResponse<Data>
) {
  res.status(200).json({ data: teamMembers})
}

