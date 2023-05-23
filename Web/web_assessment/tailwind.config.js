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
        background: '#F5F5F5',
        greyMedium: '#424242',
        primary: '#424242',
        subPrimary: '7879F1',
        secondary: '#FF7272',
        accent: '#6C63FF',
        danger: '#b91c1c',
        'primary-text': '#text-black',
        'secondary-text': '#686868',
        'teritary-text' : '#DCD0D0',
        'navbar-text' : '#5A5555',
      },
      fontFamily: {
        poppins: ['Poppins', 'sans-serif'],
      },
      backgroundImage: {
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic':
          'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
      },
    },
  },
  plugins: [],
}
