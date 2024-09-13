"use server";
import axios from "axios";
import { AxiosBase } from "@/common/axios";
import { forgotPasswordSchemaType } from "../types";

export const forgotPassword = async (values: forgotPasswordSchemaType) => {
    try {
        const response = await AxiosBase.post(
            '/api/v1/auth/forgot-password',
            values
        );
        return response.data;
    } catch(error) {
        return axios.isAxiosError(error) && error.response
      ? {
          error: error.response.data.message || "Process failed.",
          status: error.response.status,
        }
      : {
          error: "An unexpected error occurred.",
        };
    }
}
