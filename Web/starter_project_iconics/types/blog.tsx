export interface paragraph {
    description: string,
}
export interface Author{
    name:string,
    imageUrl:string,
    profession:string,
    socialMediaLink:string
}
interface Blog{
    blogId:string,
    blogTitle:string,
    smallBlogTitle:string,
    blogImgUrl:string,
    author : Author,
    heading:string,
    paragraphs: paragraph[]
}
export default Blog;