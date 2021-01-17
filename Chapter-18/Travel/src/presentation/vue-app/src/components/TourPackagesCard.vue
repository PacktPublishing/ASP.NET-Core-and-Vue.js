<template>
  <v-container>
    <v-card width="500" max-width="600">
      <v-toolbar color="pink" dark>
        <v-toolbar-title>Packages</v-toolbar-title>
        <v-spacer></v-spacer>
      </v-toolbar>
      <v-list two-line>
        <v-list-item-group active-class="pink--text">
          <div v-if="packages && packages.length > 0">
            <template v-for="tourPackage in packages">
              <v-list-item :key="tourPackage.id">
                <template>
                  <v-list-item-content>
                    <v-list-item-title
                      v-text="tourPackage.name"
                    ></v-list-item-title>
                    <v-list-item-subtitle
                      class="text--primary"
                      v-text="tourPackage.whatToExpect"
                    ></v-list-item-subtitle>
                    <div
                      style="
                        margin-top: 0.5rem;
                        display: flex;
                        flex-direction: row;
                      "
                    >
                      <v-list-item-subtitle
                        class="text--secondary"
                        v-text="`Duration: ${tourPackage.duration}hrs`"
                      ></v-list-item-subtitle>
                      <v-list-item-subtitle
                        class="text--secondary"
                        v-text="
                          `${
                            tourPackage.instantConfirmation
                              ? 'Instant Confirmation'
                              : ''
                          }`
                        "
                      ></v-list-item-subtitle>
                    </div>
                  </v-list-item-content>
                  <v-list-item-action>
                    <UpdateTourPackageForm :bodyRequest="tourPackage" />
                    <v-icon @click="removeTourPackage(tourPackage.id)">
                      mdi-delete-outline
                    </v-icon>
                  </v-list-item-action>
                </template>
              </v-list-item>
            </template>
            <v-divider />
          </div>
          <div v-else>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title
                  v-text="'No package added yet 😢'"
                ></v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </div>
        </v-list-item-group>
      </v-list>
    </v-card>
  </v-container>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import UpdateTourPackageForm from "@/components/UpdateTourPackageForm";

export default {
  name: "TourPackagesCard",

  components: { UpdateTourPackageForm },

  computed: {
    ...mapGetters("tourModule", {
      packages: "packagesOfSelectedCity",
    }),
  },

  methods: {
    ...mapActions("tourModule", ["removeTourPackageAction"]),

    removeTourPackage(packageId) {
      const confirmed = confirm(
        "You sure you want to permanently delete this tour package?"
      );
      if (!confirmed) return;
      // might need to wait for 1 min because of the cache
      this.removeTourPackageAction(packageId);
    },
  },
};
</script>

