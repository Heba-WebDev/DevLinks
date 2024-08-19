"use server"

import axios from "axios";
import { loginSchemaType } from "../types";
const baseUrl = import.meta.env.API_URL;

export const loginUser = async (values: loginSchemaType) => {
     try {
    const response = await axios.post(
      `${baseUrl}/api/v1/auth/login`,
      values,
    );
    return response.data;
  } catch (error) {
    return axios.isAxiosError(error) && error.response
      ? {
          error: error.response.data.message || "Login failed.",
          status: error.response.status,
        }
      : {
          error: "An unexpected error occurred.",
        };
  }
}
