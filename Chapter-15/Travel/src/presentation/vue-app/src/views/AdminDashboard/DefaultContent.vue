<template>
  <div>
    <div class="text-h2 my-4">Welcome to Admin Dashboard</div>
    <div class="default-content">
      <div style="margin-right: 4rem; margin-bottom: 4rem">
        <TourListsCard @handleShowPackages="handleShowPackages" />
        <AddTourListForm />
      </div>
      <div v-if="showPackages">
        <h2>Tour Packages Card Here</h2>
        <h3>Add Tour Package Form with tour list Id Here</h3>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";
import TourListsCard from "@/components/TourListsCard";
import AddTourListForm from "@/components/AddTourListForm";

export default {
  name: "DefaultContent",

  components: {
    TourListsCard,
    AddTourListForm,
  },

  methods: {
    ...mapActions("tourModule", ["getTourListsAction"]),
    handleShowPackages(show, listId) {
      this.showPackages = show;
      this.tourListId = listId;
    },
  },

  mounted() {
    this.getTourListsAction();
  },

  data: () => ({
    showPackages: false,
    tourListId: 0,
  }),

  mounted() {
    this.getTourListsAction();
    this.showPackages = false;
  },

  handleShowPackages(show, listId) {
    this.showPackages = show;
    this.tourListId = listId;
  },
};
</script>


<style scoped>
.default-content {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: flex-start;
}
</style>