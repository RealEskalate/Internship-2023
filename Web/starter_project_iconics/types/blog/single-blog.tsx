export interface Author {
  name: string
  imageUrl: string
  profession: string
  socialMediaLink: string
}
interface SingleBlog {
  blogId: string
  blogTitle: string
  smallBlogTitle: string
  blogImgUrl: string
  author: Author
  heading: string
  paragraphs: string[]
}
export default SingleBlog
