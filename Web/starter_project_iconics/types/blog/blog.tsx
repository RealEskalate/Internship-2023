export interface Blog {
  id: string
  title: string
  description: string
  datePosted: string
  smallBlogTitle: string
  imgUrl: string
  heading: string
  author: {
    name: string
    imageUrl: string
    profession: string
    socialMediaLink: string
  }
  tags: string[]
  paragraphs: string[]
}
