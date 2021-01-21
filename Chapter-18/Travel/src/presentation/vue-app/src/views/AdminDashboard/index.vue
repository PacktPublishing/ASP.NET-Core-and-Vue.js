<template>
  <v-sheet
    height="100vh"
    class="overflow-hidden"
    style="display: flex; flex-direction: row; justify-content: flex-start"
  >
    <v-navigation-drawer permanent expand-on-hover>
      <v-list class="d-flex flex-column justify-center align-center">
        <v-list-item class="px-2">
          <v-list-item-avatar>
            <v-img
              src="https://randomuser.me/api/portraits/women/85.jpg"
            ></v-img>
          </v-list-item-avatar>
        </v-list-item>

        <v-list-item link>
          <v-list-item-content>
            <v-list-item-subtitle>{{ email }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list>

      <v-divider></v-divider>

      <v-list nav dense>
        <router-link to="/admin-dashboard/" class="menu link">
          <v-list-item link>
            <v-list-item-icon>
              <v-icon>mdi-view-dashboard-variant-outline</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Dashboard</v-list-item-title>
          </v-list-item>
        </router-link>
        <router-link to="/admin-dashboard/tour-lists" class="menu link">
          <v-list-item link>
            <v-list-item-icon>
              <v-icon>mdi-format-list-bulleted</v-icon>
            </v-list-item-icon>
            <v-list-item-title> Tour Lists </v-list-item-title>
          </v-list-item>
        </router-link>
        <router-link to="/admin-dashboard/tour-packages" class="menu link">
          <v-list-item link>
            <v-list-item-icon>
              <v-icon>mdi-walk</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Tour Packages</v-list-item-title>
          </v-list-item>
        </router-link>
        <router-link to="/admin-dashboard/weather-forecast" class="menu link">
          <v-list-item link>
            <v-list-item-icon>
              <v-icon>mdi-weather-cloudy-alert</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Weather Forecast</v-list-item-title>
          </v-list-item>
        </router-link>
        <router-link to="/logout" class="menu link">
          <v-list-item link>
            <v-list-item-icon>
              <v-icon>mdi-logout-variant</v-icon>
            </v-list-item-icon>
            <v-list-item-title> Log out </v-list-item-title>
          </v-list-item>
        </router-link>
      </v-list>
    </v-navigation-drawer>
    <v-container>
      <router-view />
    </v-container>
  </v-sheet>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
export default {
  name: "AdminDashboard",

  methods: {
    ...mapActions("authModule", ["useLocalStorageTokenToSignInAction"]),
    localstorageLogin() {
      this.useLocalStorageTokenToSignInAction().then();
    }
  },

  computed: {
    ...mapGetters("authModule", {
      isAuthenticated: "isAuthenticated",
      email: "email"
    })
  },

  mounted() {
    this.localstorageLogin();
  }
};
</script>

<style scoped>
.link {
  text-decoration: none;
}
</style>
