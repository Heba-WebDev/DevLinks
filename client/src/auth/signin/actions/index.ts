"use server"
import axios from "axios";
import { AxiosBase } from "@/common/axios";
import { loginSchemaType } from "../types";

export const loginUser = async (values: loginSchemaType) => {
     try {
    const response = await AxiosBase.post(
      `/api/v1/auth/login`,
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
