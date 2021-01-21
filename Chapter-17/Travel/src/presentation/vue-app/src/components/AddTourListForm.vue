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
                    @input="$v.bodyRequest.city.$touch()"
                    @blur="$v.bodyRequest.city.$touch()"
                    :error-messages="cityErrors"
                    required
                  ></v-text-field>
                </v-col>
                <v-col cols="12" sm="6">
                  <v-autocomplete
                    :items="countryList"
                    label="Country"
                    v-model="bodyRequest.country"
                    @input="$v.bodyRequest.country.$touch()"
                    @blur="$v.bodyRequest.country.$touch()"
                    :error-messages="countryErrors"
                    required
                  ></v-autocomplete>
                </v-col>
                <v-col cols="12">
                  <v-textarea
                    label="About"
                    v-model="bodyRequest.about"
                    @input="$v.bodyRequest.about.$touch()"
                    @blur="$v.bodyRequest.about.$touch()"
                    :error-messages="aboutErrors"
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
import validators from "@/validators";

export default {
  name: "AddTourListForm",

  data: () => ({
    bodyRequest: {
      city: "",
      country: "",
      about: ""
    },

    dialog: false,
    countryList: getCountryList()
  }),

  methods: {
    ...mapActions("tourModule", ["addTourListAction"])
  },

  computed: {
    cityErrors() {
      const errors = [];
      if (!this.$v.bodyRequest.city.$dirty) return errors;

      !this.$v.bodyRequest.city.required && errors.push("City is required");
      !this.$v.bodyRequest.city.maxLength && errors.push("Max length is 90");

      return errors;
    },

    countryErrors() {
      const errors = [];
      if (!this.$v.bodyRequest.country.$dirty) return errors;

      !this.$v.bodyRequest.country.required &&
        errors.push("Country is required");
      // no need for max length because this is a dropdown with options
      return errors;
    },

    aboutErrors() {
      const errors = [];
      if (!this.$v.bodyRequest.about.$dirty) return errors;

      !this.$v.bodyRequest.about.required && errors.push("About is required");

      return errors;
    }
  },

  validations: {
    bodyRequest: {
      city: validators.city,
      country: validators.country,
      about: validators.about
    }
  }
};
</script>
