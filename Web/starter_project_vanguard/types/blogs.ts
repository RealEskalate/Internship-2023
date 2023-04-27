export interface Blog {
    _id: string,
    img: string,
    authorName:string,
    authorUserName:string,
    authorPhoto:string,
    isPending:boolean,
    title: string,
    description: string,
    likes: number,
    date: string,
    skills: string[]
  }