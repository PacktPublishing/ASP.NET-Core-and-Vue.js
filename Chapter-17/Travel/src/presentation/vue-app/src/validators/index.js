import { required, email, minLength } from "vuelidate/lib/validators";

export default {
  login: {
    email: { required, email },
    password: { required, minLength: minLength(8) },
  },
};
