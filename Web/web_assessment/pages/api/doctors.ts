import { NextApiRequest, NextApiResponse } from 'next';

const doctorsData = require('../../data/doctors/doctors-list.json');

export default function handler(req: NextApiRequest, res: NextApiResponse) {
  if (req.method === 'POST') {
    // Implement the logic to handle POST request and filter doctors based on search criteria
  } else {
    res.status(200).json(doctorsData);
  }
}
