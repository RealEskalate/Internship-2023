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
          primary: '#264FAD',
          accent: '#FF9F43',
          lightbluebg: '#FDFEFF',
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
    },
  },
  plugins: [],
}
