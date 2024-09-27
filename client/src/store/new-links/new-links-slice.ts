import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";
import { newLinksState } from "./interfaces";

const initialState: newLinksState[] = [];

const linksSlice = createSlice({
    name: "links",
    initialState,
    reducers: {
        addLinks: (_state, action: PayloadAction<newLinksState[]>) => {
            return action.payload;
        }
    }
});

export const { addLinks } = linksSlice.actions;
export default linksSlice.reducer;
