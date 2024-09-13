"use server"
import axios from "axios";
import { AxiosBase } from "@/common/axios";
import { resetPasswordSchemaType } from "../types";

export const resetPassword = async (values: resetPasswordSchemaType) => {
     try {
    const response = await AxiosBase.post(
      `/api/v1/auth/reset-password`,
      values,
    );
    return response.data;
  } catch (error) {
    return axios.isAxiosError(error) && error.response
      ? {
          error: error.response.data.message || "Resetting password failed.",
          status: error.response.status,
        }
      : {
          error: "An unexpected error occurred.",
        };
  }
}
