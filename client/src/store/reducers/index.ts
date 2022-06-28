import {combineReducers} from "redux";
import {toDoReducer} from "./toDoReducer";
import {categoryReducer} from "./categoryReducer";


export const rootReducer = combineReducers({
    toDo: toDoReducer,
    category: categoryReducer
})

export type RootState = ReturnType<typeof rootReducer>