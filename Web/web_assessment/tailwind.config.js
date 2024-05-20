/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx}',
    './components/**/*.{js,ts,jsx,tsx}',
    './app/**/*.{js,ts,jsx,tsx}',
  ],
  theme: {
    extend: {
      colors: {
        primary: '#8081F2',
        accent: '#FF9F43',
        lightbluebg: '#FDFEFF',
        danger: '#b91c1c',
        'primary-text': '#353535',
        'secondary-text': '#686868',
        'tertiary-text': '#565656',
      },

    },
  },
  plugins: [],
}
