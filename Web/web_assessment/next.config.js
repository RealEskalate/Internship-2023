/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  images: {
    domains: ["res.cloudinary.com", "demos.creative-tim.com"],
  },
};

module.exports = nextConfig;
