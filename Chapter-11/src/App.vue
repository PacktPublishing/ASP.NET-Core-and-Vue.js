<template>
  <div class="container">
    <img alt="Vue logo" src="./assets/logo.png" />
    <TodoForm :about="about" />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import TodoForm from "./components/TodoFom.vue";

export default defineComponent({
  name: "App",

  components: {
    TodoForm
  },

  // Vue 3

  setup() {
    const about = {
      title: "Vue 3",
      subTitle: "TypeScript demo"
    };

    return {
      about
    };
  }

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
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
