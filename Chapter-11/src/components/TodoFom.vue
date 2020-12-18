<template>
  <div class="mb-4">
    <h1>{{ about.title }}</h1>
    <h2>{{ about.subTitle }}</h2>
  </div>
  <div class="mb-3">
    <form @submit.prevent="addNewTodo">
      <label for="newTodo" class="form-label">New Todo</label>
      <input
        class="form-control"
        id="newTodo"
        placeholder="code"
        v-model="newTodo"
        name="newTodo"
      />
    </form>
  </div>

  <div v-if="todos.length === 0">
    <h3>Empty list 🥺</h3>
  </div>

  <div class="mb-5 d-flex flex-row justify-content-start">
    <div class="m-2">
      <button type="button" class="btn btn-primary">Add New Todo</button>
    </div>
    <div class="m-2">
      <button type="button" class="btn btn-danger" @click="removeAllTodos">
        Remove All
      </button>
    </div>
    <div class="m-2">
      <button type="button" class="btn btn-success" @click="markAllDone">
        Mark All Done
      </button>
    </div>
  </div>
  <div>
    <ul class="list-group">
      <li
        class="list-group-item d-flex flex-row justify-content-between align-items-center"
        v-for="(todo, index) in todos"
        :key="todo.id"
      >
        <h3
          :class="{ done: todo.done }"
          style="cursor: pointer"
          @click="toggleDone(todo)"
        >
          {{ todo.content }}
        </h3>
        <button
          type="button"
          class="btn btn-warning"
          @click="removeTodo(index)"
        >
          ✔️ Done & Remove
        </button>
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, PropType, onMounted } from "vue";
import { TodoModel } from "@/models/todoModel";
import { v4 as uuidv4 } from "uuid";

type Props = {
  title: string;
  subTitle: string;
};

export default defineComponent({
  name: "TodoForm",

  props: {
    about: {
      type: Object as PropType<Props>,
      required: true
    }
  },

  setup(props) {
    const newTodo = ref<string>("");
    const todos = ref<TodoModel[]>([]);

    function addNewTodo(): void {
      todos.value.push({
        id: uuidv4(),
        done: false,
        content: newTodo.value
      });

      newTodo.value = "";
    }

    function toggleDone(todo: TodoModel): void {
      todo.done = !todo.done;
    }

    function removeTodo(index: number): void {
      todos.value.splice(index, 1);
    }

    function markAllDone(): void {
      todos.value.forEach(todo => (todo.done = true));
    }

    function removeAllTodos(): void {
      todos.value = [];
    }

    onMounted(() => console.log(props?.about?.title));

    return {
      todos,
      newTodo,
      addNewTodo,
      toggleDone,
      removeTodo,
      markAllDone,
      removeAllTodos
    };
  }
});
</script>

<style>
.done {
  text-decoration: line-through;
}
</style>
