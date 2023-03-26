const path = require('path');
module.exports = {
  webpack: {
    alias: {
      '@src': path.resolve(__dirname, 'src'),
      "@assets": path.resolve(__dirname, "src/assets"),
      "@components": path.resolve(__dirname, "src/components"),
      "@pages": path.resolve(__dirname, "src/pages"),
      "@routes": path.resolve(__dirname, "src/routes"),
      "@services": path.resolve(__dirname, "src/services")
    },
  },
};