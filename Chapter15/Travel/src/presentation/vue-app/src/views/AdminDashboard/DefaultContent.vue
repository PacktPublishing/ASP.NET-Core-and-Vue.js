<template>
  <div>
    <div class="text-h2 my-4">Welcome to Admin Dashboard</div>
    <div class="default-content">
      <div style="margin-right: 4rem; margin-bottom: 4rem">
        <TourListsCard @handleShowPackages="handleShowPackages" />
        <AddTourListForm />
      </div>
      <div v-if="showPackages">
        <TourPackagesCard />
        <AddTourPackageForm :tourListId="tourListId" />
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from "vuex";
import TourListsCard from "@/components/TourListsCard";
import AddTourListForm from "@/components/AddTourListForm";
import TourPackagesCard from "@/components/TourPackagesCard";
import AddTourPackageForm from "@/components/AddTourPackageForm";

export default {
  name: "DefaultContent",

  components: {
    TourListsCard,
    AddTourListForm,
    TourPackagesCard,
    AddTourPackageForm,
  },

  methods: {
    ...mapActions("tourModule", ["getTourListsAction"]),
    handleShowPackages(show, listId) {
      this.showPackages = show;
      this.tourListId = listId;
    },
  },

  data: () => ({
    showPackages: false,
    tourListId: 0,
  }),

  mounted() {
    this.getTourListsAction();
    this.showPackages = false;
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