import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";
import { userState } from "./interfaces";

const userSavedState = localStorage.getItem("user");
const initialState: userState = userSavedState ? JSON.parse(userSavedState) : {
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
            localStorage.setItem("user", JSON.stringify(action.payload));
            return action.payload;
        },
        logout: () => {
            localStorage.removeItem("user");
            return initialState;
        }
    }
});

export const { login, logout } = userSlice.actions;
export default userSlice.reducer;
