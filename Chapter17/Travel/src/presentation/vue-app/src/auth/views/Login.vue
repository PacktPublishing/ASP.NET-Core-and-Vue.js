<template>
  <!--  https://vuetifyjs.com/en/styles/colors/#material-colors-->
  <v-app>
    <v-dialog
      v-model="dialog"
      persistent
      max-width="600px"
      min-width="360px"
      @click:outside="navigateHome"
    >
      <div>
        <v-tabs
          show-arrows
          background-color="pink accent-4"
          icons-and-text
          dark
          grow
        >
          <v-tabs-slider color="pink darken-4"></v-tabs-slider>
          <v-tab>
            <v-icon large>mdi-login</v-icon>
            <div>Login</div>
          </v-tab>
          <v-tab>
            <v-icon large>mdi-account-box-outline</v-icon>
            <div>Register</div>
          </v-tab>
          <v-tab-item>
            <v-card class="px-4">
              <v-card-text>
                <form @submit.prevent="onSubmit">
                  <v-row>
                    <v-col cols="12">
                      <v-text-field
                        label="E-mail"
                        v-model="login.email"
                        @input="$v.login.email.$touch()"
                        @blur="$v.login.email.$touch()"
                        :error-messages="emailErrors"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        type="password"
                        label="Password"
                        hint="At least 8 characters"
                        counter
                        v-model="login.password"
                        @input="$v.login.password.$touch()"
                        @blur="$v.login.password.$touch()"
                        :error-messages="passwordErrors"
                      ></v-text-field>
                    </v-col>
                    <v-col class="d-flex" cols="12" sm="6" xsm="12"> </v-col>
                    <v-spacer></v-spacer>
                    <v-col class="d-flex" cols="12" sm="3" xsm="12" align-end>
                      <v-btn :disabled="false" color="primary" type="submit"
                        >Login</v-btn
                      >
                    </v-col>
                  </v-row>
                </form>
              </v-card-text>
            </v-card>
          </v-tab-item>
          <v-tab-item>
            <v-card class="px-4">
              <v-card-text>
                <div>
                  <v-row>
                    <v-col cols="12" sm="6" md="6">
                      <v-text-field
                        label="First Name"
                        maxlength="20"
                        required
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="6" md="6">
                      <v-text-field
                        label="Last Name"
                        maxlength="20"
                        required
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field label="E-mail" required></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        label="Password"
                        hint="At least 8 characters"
                        counter
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field
                        block
                        label="Confirm Password"
                        counter
                      ></v-text-field>
                    </v-col>
                    <v-spacer></v-spacer>
                    <v-col class="d-flex ml-auto" cols="12" sm="3" xsm="12">
                      <v-btn :disabled="false" color="primary">Register</v-btn>
                    </v-col>
                  </v-row>
                </div>
              </v-card-text>
            </v-card>
          </v-tab-item>
        </v-tabs>
      </div>
    </v-dialog>
  </v-app>
</template>

<script>
import { mapActions } from "vuex";
import router from "@/router";
import validators from "@/validators";

export default {
  name: "Login",

  data: () => ({
    dialog: true,
    tab: null,
    login: {
      email: "",
      password: ""
    }
  }),

  methods: {
    ...mapActions("authModule", ["loginUserAction"]),

    onSubmit() {
      this.loginUserAction(this.login).then(() => {
        this.$router.push({ path: "/admin-dashboard" });
      });
    },

    navigateHome() {
      router.push("/");
    }
  },

  computed: {
    emailErrors() {
      const errors = [];
      if (!this.$v.login.email.$dirty) return errors;

      !this.$v.login.email.email && errors.push("Must be valid e-mail");
      !this.$v.login.email.required && errors.push("E-mail is required");

      return errors;
    },

    passwordErrors() {
      const errors = [];
      if (!this.$v.login.password.$dirty) return errors;

      !this.$v.login.password.required && errors.push("Password is required");
      !this.$v.login.password.minLength &&
        errors.push("Minimum characters is 8");

      return errors;
    }
  },

  validations: {
    login: validators.login
  }
};
</script>
