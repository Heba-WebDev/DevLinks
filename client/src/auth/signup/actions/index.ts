"use server";
import axios from "axios";
import { AxiosBase } from "@/common/axios";
import { registerSchemaType } from "../types";

export const registerUser = async (values: registerSchemaType) => {
     try {
    const response = await AxiosBase.post(
      `/api/v1/auth/register`,
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
