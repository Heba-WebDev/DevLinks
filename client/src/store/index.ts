import { configureStore } from '@reduxjs/toolkit'
import userReducer from "./user/user-slice";
import linksReducer from "./links/links-slice";

export const store = configureStore({
    reducer: {
        user: userReducer,
        links: linksReducer,
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
