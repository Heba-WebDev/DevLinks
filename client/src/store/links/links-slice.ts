import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";
import { linksState } from "./interfaces";

const initialState: linksState[] = [];

const linksSlice = createSlice({
    name: "links",
    initialState,
    reducers: {
        getLinks: (_state, action: PayloadAction<linksState[]>) => {
            return action.payload;
        }
    }
});

export const { getLinks } = linksSlice.actions;
export default linksSlice.reducer;
