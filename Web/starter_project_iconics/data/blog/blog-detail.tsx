import BlogDetail, { Author } from '@/types/blog/blog-detail'

const author1: Author = {
  name: 'chaltu kebede',
  imageUrl: 'dummy-author-img.png',
  profession: 'software engineer',
  socialMediaLink: '@chaltu_kebede',
}

const paragraphs = [
  'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididuntut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
  'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididuntut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
  'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididuntut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
]

const blogs: BlogDetail[] = [
  {
    blogId: '1',
    blogTitle: 'The essential guide to Competitive Programming',
    smallBlogTitle: 'Programming, tech | 6 min Read',
    blogImgUrl: 'dummy-blog-img.png',
    author: author1,
    heading:
      'We know that data structure and algorithm can seem hard at first glance. And you may not be familiar with advanced algorithms, but there are simple steps you can follow to see outstanding results in a short period of time.',
    paragraphs: paragraphs,
  },
  {
    blogId: '2',
    blogTitle: 'The essential guide to Competitive Programming',
    smallBlogTitle: 'Programming, tech | 6 min Read',
    blogImgUrl: 'dummy-blog-img.png',
    author: author1,
    heading:
      'We know that data structure and algorithm can seem hard at first glance. And you may not be familiar with advanced algorithms, but there are simple steps you can follow to see outstanding results in a short period of time.',
    paragraphs: paragraphs,
  },
]

export default blogs
