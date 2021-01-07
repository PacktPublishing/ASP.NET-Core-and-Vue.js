<template>
  <div class="container">
    <img alt="Vue logo" src="./assets/logo.png" />
    <TodoForm :about="about" />
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import TodoForm from "./components/TodoFom.vue";

export default defineComponent({
  name: "App",

  components: {
    TodoForm,
  },

  // Vue 3

  setup() {
    const about = ref({
      title: "Vue 3",
      subTitle: "TypeScript demo",
    });

    return {
      about,
    };
  },

  // Vue 2

  /*

   data:() => ({
     about: {
        title: "Vue 3",
        subTitle: "TypeScript demo"
      }
   })

 */
});
</script>

<style>
@import "../node_modules/bootstrap/dist/css/bootstrap.css";
</style>
