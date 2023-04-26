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
        secondary: '#E1E7EC',
        accent: '#FF9F43',
        danger: '#b91c1c',
        'primary-text': '#353535',
        'secondary-text': '#717171',
      },
      fontFamily: {
        montserrat: ['Montserrat', 'sans-serif'],
        poppins: ['Poppins', 'sans-serif'],
        imfell: ['IM Fell French Canon', 'serif'],
        DMSans: ['Dm Sans'],
      },
    },
  },
  plugins: [],
}
