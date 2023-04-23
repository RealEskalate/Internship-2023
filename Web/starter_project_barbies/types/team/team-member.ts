import { SocialMediaLink } from "@/types/team/social-media-link";

export type TeamMember = {
  id: string,
  name: string
  jobTitle: string
  description: string
  image: string
  links: SocialMediaLink[]
}