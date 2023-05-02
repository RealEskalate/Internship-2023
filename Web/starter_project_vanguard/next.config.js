/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  //Configured to use network images, from websites listed below, with "next Image"
  images: {
    remotePatterns: [
      {
        protocol: 'https',
        hostname: 'media.licdn.com',
        port: '',
        pathname: '/dms/image/**',
      },
      {
        protocol: 'https',
        hostname: 'media.wired.com',
        port: '',
        pathname: '/photos/**',
      },
    ],
  },
}

module.exports = nextConfig
