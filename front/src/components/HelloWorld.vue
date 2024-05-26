<script setup lang="ts">
import axios from "axios";
import { ref, watch } from "vue";
import debounce from "../utils/debounce";

const promptModel = ref("");
const promptResponse = ref("");

const fetchCategories = debounce(async () => {
  try {
    const response = await axios.get(
      `http://195.49.212.10/api/Search?question=${promptModel.value}`
    );
    promptResponse.value = response.data.choices[0].message.content;
  } catch (e) {
    promptResponse.value = JSON.stringify(e);
  }
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
  <pre style="width: 100vw;">
    {{ promptResponse }}
  </pre>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
