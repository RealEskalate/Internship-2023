export type SocialMediaLink = {
  type: string,
  url: string
}

export type TeamMember = {
  id: string,
  name: string
  jobTitle: string
  description: string
  image: string
  links: SocialMediaLink[]
}