import { defineConfig, UserConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

const options: UserConfig = {
  plugins: [vue()],
  css: {
    preprocessorOptions: {
      scss: {
        additionalData: '@import "@/styles/mock.variables.scss";'
      }
    }
  },
  resolve: {
    alias: {
      "@": "./src"
    }
  }
}

// https://vitejs.dev/config/
export default defineConfig(options)
