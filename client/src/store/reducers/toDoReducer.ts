import * as T from "../../types/toDo";


const initialState : T.ToDoState = {
    toDoList: [],
    loading: false,
    error: null
}

export const toDoReducer = (state = initialState, action: T.ToDoAction) => {
    switch (action.type){
        case T.ActionTypes.FETCH_TODOS:
            return {loading: true, error: null, toDoList: []}
        case T.ActionTypes.FETCH_TODOS_SUCCESS:
            return {loading: false, error: null, toDoList: action.payload}
        case T.ActionTypes.FETCH_TODOS_ERROR:
            return {loading: false, error: action.payload, toDoList: []}
        default: return state
    }
}