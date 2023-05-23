/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: true,
  async redirects() {
    return [
      {
        source: '/',
        destination: '/doctors',
        permanent: true,
      },
    ]
  },
}

module.exports = nextConfig
