interface BlogDetail {
  blogId: string
  blogTitle: string
  smallBlogTitle: string
  blogImgUrl: string
  heading: string
  authors: {
    name: string
    imageUrl: string
    profession: string
    socialMediaLink: string
  }
  paragraphs: string[]
}
export default BlogDetail
