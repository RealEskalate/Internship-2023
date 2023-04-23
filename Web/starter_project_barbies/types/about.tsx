import { ReactNode } from 'react'

export type Project = {
  image: string
  project: string
  description: string
}

export type Session = {
  session: string
  description: string
  icon: ReactNode
}

export type ProblemItem = {
  icon: ReactNode
  description: string
}

export type SolutionItem = ProblemItem
