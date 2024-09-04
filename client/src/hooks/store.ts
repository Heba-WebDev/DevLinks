import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState} from "../store/index";
import type { TypedUseSelectorHook } from "react-redux";

export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
export const useAppDispatch: () => AppDispatch = useDispatch;
