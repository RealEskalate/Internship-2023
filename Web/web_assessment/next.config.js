/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  images: {
    remotePatterns: [
      {
        protocol: "https",
        hostname: "res.cloudinary.com",
        port: '',
        pathname: '/hakimhub/image/upload/v1656314302/POP_DATA_DOC/'
      },
    ],
  },
  
}

module.exports = nextConfig
