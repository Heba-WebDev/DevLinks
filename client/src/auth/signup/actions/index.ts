"use server"

import axios from "axios";
import { registerSchemaType } from "../types";
const baseUrl = import.meta.env.API_URL;

export const registerUser = async (values: registerSchemaType) => {
     try {
    const response = await axios.post(
      `${baseUrl}/api/v1/auth/register`,
      values,
    );
    return response.data;
  } catch (error) {
    return axios.isAxiosError(error) && error.response
      ? {
          error: error.response.data.message || "Registration failed.",
          status: error.response.status,
        }
      : {
          error: "An unexpected error occurred.",
        };
  }
}
