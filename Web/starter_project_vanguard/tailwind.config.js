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
        'primary-text': '#353535',
        'secondary-text': '#717171',
        'tertiary-text': '#565656',
        
      },
      backgroundImage: {
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic':
          'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
      },
      fontFamily: {
        poppins: ["Poppins"],
        montserrat: ["Montserrat"],
        DMSans: ["DM Sans"],
      },
      screens:{
        '3xl':'1800px',
        // => @media (min-width: 1800px) { ... }
        '2lg': '1100px',
        // => @media (min-width: 1100px) { ... }
        '2md': '950px',   
        // => @media (min-width: 950px) { ... }

      }
    },

  },
  plugins: [],
}
