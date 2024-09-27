import axios from "axios";
import { AxiosBase } from "@/common/axios";

export const fetchLinks = async (accessToken: string) => {
    try {
        const response = await AxiosBase.get('/api/v1/links',
            {
                headers: {
                    Authorization: `Bearer ${accessToken}`
                }
            }
        );
        return response.data;
    } catch(error) {
         return axios.isAxiosError(error) && error.response
      ? {
          error: error.response.data.message || "Fetching links failed.",
          status: error.response.status,
        }
      : {
          error: "An unexpected error occurred.",
        };
    }
}
