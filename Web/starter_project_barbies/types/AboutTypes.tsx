export type Project = {
  image: string
  project: string
  description: string
}

export interface ProjectCardProps {
  project: Project
  isEven: boolean
}

export type Session = {
  session: string
  description: string
  image: string
}

export type SessionProps = {
  session: { session: string; description: string; image: string }
}

export type ProblemItem = {
  icon: string
  description: string
}

export interface ProblemItemProps {
  Item: ProblemItem
}
