import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";
import { userState } from "./interfaces";

const initialState: userState = {
    accessToken: null,
    email: "",
    firstName: null,
    lastName: null,
    id: "",
    image: null,
    role: null,
    username: ""
};

const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        login: (_state, action: PayloadAction<userState>) => {
            return action.payload;
        },
        logout: () => {
            return initialState;
        }
    }
});

export const { login, logout } = userSlice.actions;
export default userSlice.reducer;
