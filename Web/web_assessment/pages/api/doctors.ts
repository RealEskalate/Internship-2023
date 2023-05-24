import { NextApiRequest, NextApiResponse } from "next";

type CardData = {
  id: number;
  photo: string,
  name: string;
  field: string,
  description: string;
};

const cards: CardData[] = [
  {
    id: 1,
    photo: "/profile/ellipse-5",
    name: "Dr. Zekarias G.",
    field: "Nephrologist",
    description: "This is the first card"
  },
  {
    id: 2,
    photo:"/profile/ellipse-5",
    name: "Dr. Fassil Teffera",
    field: "Internal Medicine",
    description: "MCM korean Hospital",

  },
  {
    id: 3,
    photo: "/profile/ellipse-5",
    name: "Dr. Zekarias G.",
    field: "Nephrologist",
    description: "MCM korean Hospital"
  },
];

export default function handler(
  req: NextApiRequest,
  res: NextApiResponse<CardData[]>
) {
  res.status(200).json(cards);
}