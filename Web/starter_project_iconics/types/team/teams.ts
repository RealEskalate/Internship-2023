
interface socialMedia{
 type: string
 link: string
}
export interface Team{
    name: string,
    job: string,
    description: string,
    avatar: string,
    socialMedia: socialMedia[]
}