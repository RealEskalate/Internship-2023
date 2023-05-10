interface SocialMedia{
 type: string
 link: string
}
export interface TeamMember{
    name: string,
    job: string,
    description: string,
    avatar: string,
    socialMedia: SocialMedia[]
}