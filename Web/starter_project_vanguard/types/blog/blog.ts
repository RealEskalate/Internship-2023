export interface Blog {
    id: string,
    img: string,
    authorName:string,
    profession:string,
    time:number,
    authorUserName:string,
    authorPhoto:string,
    isPending:boolean,
    company:string,
    title: string,
    descriptionTitle:string,
    description: string,
    tags: string,
    likes: number,
    relatedBlogs: string[],
    date: string,
    skills: string[]
  }