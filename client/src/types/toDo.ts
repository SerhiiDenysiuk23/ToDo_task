export interface ToDo{
    id?: number | string,
    text: string,
    description?: string,
    deadline?: string,
    isComplete: boolean,
    categoryId?: number | string
}

export enum ActionTypes{
    FETCH_TODOS = "FETCH_TODOS",
    FETCH_TODOS_SUCCESS = "FETCH_TODOS_SUCCESS",
    FETCH_TODOS_ERROR = "FETCH_TODOS_ERROR"
}

interface FetchToDosAction{type: ActionTypes.FETCH_TODOS}
interface FetchToDosSuccessAction{type: ActionTypes.FETCH_TODOS_SUCCESS, payload: ToDo[]}
interface FetchToDosErrorAction{type: ActionTypes.FETCH_TODOS_ERROR, payload: string}

export type ToDoAction = (FetchToDosAction | FetchToDosErrorAction | FetchToDosSuccessAction)

export interface ToDoState{
    toDoList: ToDo[],
    loading: boolean,
    error: null | string
}
