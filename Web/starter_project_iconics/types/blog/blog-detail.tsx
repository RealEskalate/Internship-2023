export interface Author {
    name: string
    imageUrl: string
    profession: string
    socialMediaLink: string
  }
  interface BlogDetail {
    blogId: string
    blogTitle: string
    smallBlogTitle: string
    blogImgUrl: string
    author: Author
    heading: string
    paragraphs: string[]
  }
  export default BlogDetail