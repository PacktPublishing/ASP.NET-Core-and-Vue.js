import {
  required,
  email,
  minLength,
  maxLength
} from "vuelidate/lib/validators";

export default {
  login: {
    email: { required, email },
    password: { required, minLength: minLength(8) }
  },
  city: {
    required,
    maxLength: maxLength(90)
  },
  country: {
    required,
    maxLength: maxLength(60)
  },
  about: {
    required
  }
};
