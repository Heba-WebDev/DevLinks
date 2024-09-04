import { configureStore } from '@reduxjs/toolkit'
import userReducser from "./user/user-slice";

export const store = configureStore({
    reducer: {
        user: userReducser,
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
