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
        hostname: 'picsum.photos',
        port: '',
        pathname: '/id/**/400/300',

      },
      {
        protocol: 'https',
        hostname: 'picsum.photos',
        port: '',
        pathname: '/id/**/200',

      }
    ],
  },

}

module.exports = nextConfig
