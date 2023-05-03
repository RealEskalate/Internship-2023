/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  //Configured to use network images, from websites listed below, with "next Image"
  images: {
    domains: ['media.licdn.com','picsum.photos']
  },

}

module.exports = nextConfig
