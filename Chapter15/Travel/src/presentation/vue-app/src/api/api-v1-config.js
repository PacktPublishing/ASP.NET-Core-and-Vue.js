import axios from "axios";

const debug = process.env.NODE_ENV !== "production";
const baseURL = debug
  ? "https://localhost:5001/api/v1.0/"
  : "https://traveltour.io/api/v1.0/";

let api = axios.create({ baseURL });


export default api;