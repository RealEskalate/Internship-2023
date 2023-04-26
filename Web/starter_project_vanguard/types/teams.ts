type SocialMedia = { url: string; social: string }

export type Member = {
  name: string
  role: string
  description: string
  photoUrl: string
  links: SocialMedia[]
}
