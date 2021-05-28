<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <template v-slot:activator="{ on, attrs }">
        <v-icon class="mr-3" v-bind="attrs" v-on="on">
          mdi-clipboard-edit-outline
        </v-icon>
      </template>
      <v-card>
        <form @submit.prevent="onSubmit">
          <v-card-title>
            <span class="headline">Update Tour Package</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12">
                  <v-text-field
                    label="Name"
                    v-model="bodyRequest.name"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-textarea
                    label="What to expect"
                    v-model="bodyRequest.whatToExpect"
                    required
                  ></v-textarea>
                </v-col>
                <v-col cols="12">
                  <v-text-field
                    label="Map Location"
                    v-model="bodyRequest.mapLocation"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="4">
                  <v-text-field
                    label="Price in USD"
                    v-model="bodyRequest.price"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="4">
                  <v-autocomplete
                    :items="durations"
                    v-model="bodyRequest.duration"
                    label="Duration in hours"
                  ></v-autocomplete>
                </v-col>
                <v-col cols="12" sm="4">
                  <v-switch
                    label="Instant confirmation"
                    v-model="bodyRequest.instantConfirmation"
                  ></v-switch>
                </v-col>
              </v-row>
            </v-container>
            <small>*indicates required field</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" text @click="dialog = false">
              Close
            </v-btn>
            <v-btn
              color="blue darken-1"
              text
              @click="dialog = false"
              type="submit"
            >
              Update
            </v-btn>
          </v-card-actions>
        </form>
      </v-card>
    </v-dialog>
  </v-row>
</template>


<script>
import { mapActions } from "vuex";

export default {
  name: "UpdateTourPackageForm",

  props: {
    bodyRequest: {
      type: Object,
      required: true,
      default: {
        listId: 0,
        name: "missing name",
        whatToExpect: "missing what to expect",
        mapLocation: "missing map location",
        price: 0,
        duration: 0,
        instantConfirmation: true,
      },
    },
  },

  methods: {
    ...mapActions("tourModule", ["updateTourPackageAction"]),

    onSubmit() {
      this.updateTourPackageAction(this.bodyRequest); // fyi, you might not see the results right away because of the cache.
    },
  },

  data: () => ({
    dialog: false,
    currencies: ["USD", "NOK"],
    currencyValues: [0, 1],
    durations: [1, 2, 3, 4, 5, 6, 7, 8],
    durationValue: 1,
  }),
};
</script>