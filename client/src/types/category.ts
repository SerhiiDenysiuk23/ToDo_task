
export interface Category{
    id?: number | string,
    name: string
}

export enum ActionTypes{
    FETCH_CATEGORIES = "FETCH_CATEGORIES",
    FETCH_CATEGORIES_SUCCESS = "FETCH_CATEGORIES_SUCCESS",
    FETCH_CATEGORIES_ERROR = "FETCH_CATEGORIES_ERROR"
}

interface FetchCategoriesAction{type: ActionTypes.FETCH_CATEGORIES}
interface FetchCategoriesSuccessAction{type: ActionTypes.FETCH_CATEGORIES_SUCCESS, payload: Category[]}
interface FetchCategoriesErrorAction{type: ActionTypes.FETCH_CATEGORIES_ERROR, payload: string}

export type CategoryAction = (FetchCategoriesAction | FetchCategoriesSuccessAction | FetchCategoriesErrorAction)

export interface CategoryState{
    categoryList: Category[],
    loading: boolean,
    error: null | string
}