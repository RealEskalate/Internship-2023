import BlogTile from '@/components/blog/BlogTile'
import { BlogData } from '@/types/blogs'
import { FaPlus } from 'react-icons/fa'

const blogs = () => {
  const blogsData: BlogData[] = [
    {
      name: 'Yididiya Kebede',
      profession: 'SOFTWARE ENGINEER',
      profileImg: '/img/blog/profile-img.jpg',
      title:
        'The essential guide to Competitive Programming Tab System On React : 3 ways to do it.',
      description:
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea ',
      datePosted: new Date('Apr 16, 2022'),
      tags: ['UI/UX', 'Development'],
      blogImg: '/img/blog/blog-img.jpg',
    },
    {
      name: 'Yididiya Kebede',
      profession: 'SOFTWARE ENGINEER',
      profileImg: '/img/blog/profile-img.jpg',
      title:
        'The essential guide to Competitive Programming Tab System On React : 3 ways to do it.',
      description:
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea ',
      datePosted: new Date('Apr 16, 2022'),
      tags: ['UI/UX', 'Development'],
      blogImg: '/img/blog/blog-img.jpg',
    },
    {
      name: 'Yididiya Kebede',
      profession: 'SOFTWARE ENGINEER',
      profileImg: '/img/blog/profile-img.jpg',
      title:
        'The essential guide to Competitive Programming Tab System On React : 3 ways to do it.',
      description:
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea ',
      datePosted: new Date('Apr 16, 2022'),
      tags: ['UI/UX', 'Development'],
      blogImg: '/img/blog/blog-img.jpg',
    },
  ]
  return (
    <div className="bg-white pt-4">
      <div className="flex flex-col items-center gap-y-4 mx-10 md:flex-row">
        <h1 className="text-xl font-bold">Blogs</h1>
        <form className="flex gap-4 m-auto">
          <input
            id="search"
            type="text"
            placeholder="search"
            className="w-48 p-3 text-secondary-text rounded-3xl text-sm border-0 shadow outline-none focus:outline-none focus:ring "
          />
          <button className="bg-blue-700 text-white text-sm p-3 rounded-3xl">
            <FaPlus className="inline text-sm m-2" />
            New Blog
          </button>
        </form>
      </div>

      <section>
        {blogsData.map((blog, index) => (
          <BlogTile key={index} {...blog} />
        ))}
      </section>
    </div>
  )
}

export default blogs
