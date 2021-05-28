<template>
  <v-skeleton-loader
    v-if="loading"
    width="300"
    max-width="450"
    height="100%"
    type="card"
  ></v-skeleton-loader>
  <v-card v-else width="300" max-width="450" height="100%">
    <v-toolbar color="light-blue" dark>
      <v-toolbar-title>Tour Lists</v-toolbar-title>
      <v-spacer></v-spacer>
    </v-toolbar>
    <v-list-item-group color="primary">
      <v-list-item v-for="tourList in lists" :key="tourList.id">
        <v-list-item-content
          @click="addToPackages(tourList.tourPackages, tourList.id)"
        >
          <v-list-item-title v-text="tourList.city"></v-list-item-title>
          <v-list-item-subtitle v-text="tourList.about"></v-list-item-subtitle>
        </v-list-item-content>
        <v-list-item-action>
          <div class="mr-2">
            {{ tourList.tourPackages && tourList.tourPackages.length }}
          </div>
          <v-icon @click="removeTourList(tourList.id)">
            mdi-delete-outline
          </v-icon>
        </v-list-item-action>
      </v-list-item>
    </v-list-item-group>
  </v-card>
</template>


<script>
import { mapActions, mapGetters } from "vuex";

export default {
  name: "TourListsCard",

  computed: {
    ...mapGetters("tourModule", {
      lists: "lists",
      loading: "loading",
    }),
  },

  methods: {
    ...mapActions("tourModule", [
      "removeTourListAction",
      "getPackagesOfSelectedCityAction",
    ]),

    removeTourList(listId) {
      const confirmed = confirm(
        "You sure you want to delete this tour list? This will also delete the packages permanently"
      );

      if (!confirmed) return;

      this.removeTourListAction(listId);
    },

    addToPackages(packages, listId) {
      this.getPackagesOfSelectedCityAction(packages);
      this.$emit("handleShowPackages", true, listId);
    },
  },
};
</script>