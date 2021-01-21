<template>
  <div class="container" v-if="email">
    <div class="text-h4 my-5">Do you like to continue as {{ email }}? 🔒</div>
    <v-btn @click="onSubmit" color="primary" class="mr-4">Yes</v-btn>
    <v-btn @click="handleLogOut()" outlined color="primary"
      >No thanks, I'd like to log out</v-btn
    >
  </div>
  <div v-else class="text-h4 m-10">
    Fancy meeting you here.
    <v-btn @click="handleLogOut()" outlined color="primary"
      >Go to Home Page</v-btn
    >
  </div>
</template>

<script>
import { getUserEmailFromToken, logOut } from "@/auth/auth.service";
export default {
  name: "ContinueAs",

  data: () => ({
    email: getUserEmailFromToken()
  }),

  methods: {
    handleLogOut() {
      logOut();
    },
    onSubmit() {
      this.$router.push({ path: "/admin-dashboard" });
    }
  }
};
</script>
