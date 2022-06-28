import {Dispatch} from "redux";
import {ActionTypes, ToDoAction} from "../../types/toDo";
import getResource from "../../api/core";
import {getToDoList} from "../../api/queries";


export const fetchToDos = () => {
    return async (dispatch: Dispatch<ToDoAction>) => {
        try {
            dispatch({type: ActionTypes.FETCH_TODOS})
            const data = await getResource(getToDoList())
            dispatch({type: ActionTypes.FETCH_TODOS_SUCCESS, payload: data.data.todolist})
        }catch (e){
            console.log(e)
            dispatch({type: ActionTypes.FETCH_TODOS_ERROR, payload: "Error"})
        }
    }
}