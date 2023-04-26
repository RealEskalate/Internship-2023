// Each blog has these properties
export type Blog = {
    userID : string;
    blogID: string;
    title: string;
    content: string;
    tags: string[];
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
    shortDescription: string;
    // we can add other properties here as needed
  };