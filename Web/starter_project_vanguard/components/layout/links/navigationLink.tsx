interface LinkItem {
    title: string
    links: {
      name: string
      path: string
    }[]
  }
  
  export const linkItems: LinkItem[] = [
    {
      title: 'Links',
      links: [
        { name: 'Home', path: '/' },
        { name: 'Success Stories', path: '/story' },
        { name: 'About Us', path: '/about' },
        { name: 'Get Involved', path: '/get-involved' },
      ],
    },
    {
      title: 'Teams',
      links: [
        { name: 'Board Members', path: '/board' },
        { name: 'Advisors/Mentors', path: '/advisors' },
        { name: 'Executives', path: '/executives' },
        { name: 'Staffs', path: '/staffs' },
      ],
    },
    {
      title: 'Blogs',
      links: [
        { name: 'Recent Blogs', path: '/recent-blogs' },
        { name: 'New Blog', path: '/new-blog' },
      ],
    },
  ]
  