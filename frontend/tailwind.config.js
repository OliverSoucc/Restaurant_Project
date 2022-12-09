/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      backgroundImage: {
        'hero-pattern': "linear-gradient(rgba(0,0,0,0.6), rgba(0,0,0,0.6)), url(assets/images/hero.jpg);",
        'form-patter': "linear-gradient(to right bottom, #f3bf91, #e67e22);"
      },
    },
  },
  plugins: [],
}
