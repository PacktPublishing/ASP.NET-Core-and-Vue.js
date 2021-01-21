<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          style="margin-top: 1rem"
          rounded
          color="pink"
          dark
          v-bind="attrs"
          v-on="on"
        >
          <v-icon left> mdi-plus </v-icon>
          add new tour package
        </v-btn>
      </template>
      <v-card>
        <form @submit.prevent="onSubmit">
          <v-card-title>
            <span class="headline">Create New Tour Package</span>
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
              Save
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
  name: "AddTourPackageForm",

  props: {
    tourListId: {
      type: Number
    }
  },

  data: () => ({
    id: 0,
    bodyRequest: {
      listId: 0,
      name: "",
      whatToExpect: "",
      mapLocation: "https://www.google.com/maps/place/...",
      price: 10,
      duration: 1,
      instantConfirmation: true
    },

    dialog: false,
    currencies: ["USD", "NOK"],
    currencyValues: [0, 1],
    durations: [1, 2, 3, 4, 5, 6, 7, 8],
    durationValue: 1
  }),

  methods: {
    ...mapActions("tourModule", ["addTourPackageAction"]),

    onSubmit() {
      this.bodyRequest.listId = this.tourListId;
      this.addTourPackageAction(this.bodyRequest); // triggers the method of the container holding this
      this.bodyRequest = {};
    }
  }
};
</script>
