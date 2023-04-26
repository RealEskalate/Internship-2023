import Blog, { Author } from '@/types/blog'

const author1:Author = {
    name:"chaltu kebede",
    imageUrl:"/blog/dummy-author-img.png",
    profession:"software engineer",
    socialMediaLink:"@chaltu_kebede"
}

const Blog1:Blog = {
    blogTitle:"The essential guide to Competitive Programming",
    smallBlogTitle:"Programming, tech | 6 min Read",
    blogImgUrl:"/blog/dummy-blog-img.png",
    author : author1,
    description:"We know that data structure and algorithm can seem hard at first glance. And you may not be familiar with advanced algorithms, but there are simple steps you can follow to see outstanding results in a short period of time.",
} 