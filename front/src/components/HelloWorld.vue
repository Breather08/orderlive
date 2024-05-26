<script setup lang="ts">
import axios from "axios";
import { ref, watch } from "vue";
import debounce from "../utils/debounce";

const promptModel = ref("");
const promptResponse = ref("");

const fetchCategories = debounce(async () => {
  console.log("debounce");
  const response = await axios.get(
    `https://192.168.0.113:7120/api/Search?question=${promptModel.value}`
  );
  promptResponse.value = response.data.choices[0].message.content;
}, 1000);

watch(
  () => promptModel.value,
  () => {
    fetchCategories();
  }
);
</script>

<template>
  <input v-model="promptModel" type="text" />
  <pre>
    {{ promptResponse }}
  </pre>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
