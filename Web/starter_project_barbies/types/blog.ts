// Each blog has these properties
export interface Blog extends UpdateBlog {
  userID : string;
  id: string;
  date: string;
  author: {
    name: string;
    email : string;
    image: string;
    profession: string;
    userName: string;
  };
  blogImage: string;
  readTime: number;
  relatedBlogs: string[];
};

export type UpdateBlog = {
  title: string;
  content: string;
  tags: string[];
  shortDescription: string;
}