import axios from "axios";
const baseURL = import.meta.env.VITE_APP_API_URL;

export const base = axios.create({
  baseURL,
  withCredentials: true,
});
