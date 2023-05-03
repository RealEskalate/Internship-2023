/** @type {import('tailwindcss').Config} */
const colors = require('tailwindcss/colors')
module.exports = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx}',
    './components/**/*.{js,ts,jsx,tsx}',
    './app/**/*.{js,ts,jsx,tsx}',
  ],
  theme: {
    extend: {
      colors: {
        primary: '#264FAD',
        accent: '#FF9F43',
        danger: '#b91c1c',
        primarytext: '#353535',
        secondarytext: '#717171',
      },
      backgroundImage: {
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic':
          'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
      },
      fontFamily: {
        'french-cannon': '"IM FELL French Canon"',
        'montserrat': '"Montserrat"'
      }
    },
  },
  plugins: [],
}
