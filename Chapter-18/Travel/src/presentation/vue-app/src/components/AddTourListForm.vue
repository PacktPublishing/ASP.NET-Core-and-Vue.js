<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          style="margin-top: 1rem"
          rounded
          color="light-blue"
          dark
          v-bind="attrs"
          v-on="on"
        >
          <v-icon left>mdi-plus</v-icon>
          add new tour list
        </v-btn>
      </template>
      <v-card>
        <form
          @submit.prevent="
            addTourListAction(bodyRequest);
            bodyRequest = {};
          "
        >
          <v-card-title>
            <span class="headline">Create New Tour List</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6">
                  <v-text-field
                    label="City"
                    v-model="bodyRequest.city"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="6">
                  <v-autocomplete
                    :items="countryList"
                    label="Country"
                    v-model="bodyRequest.country"
                    required
                  ></v-autocomplete>
                </v-col>
                <v-col cols="12">
                  <v-textarea
                    label="About"
                    v-model="bodyRequest.about"
                    required
                  ></v-textarea>
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
import { getCountryList } from "@/helpers/collections";
import { mapActions } from "vuex";

export default {
  name: "AddTourListForm",

  data: () => ({
    bodyRequest: {
      city: "",
      country: "",
      about: "",
    },

    dialog: false,
    countryList: getCountryList(),
  }),

  methods: {
    ...mapActions("tourModule", ["addTourListAction"]),
  },
};
</script>