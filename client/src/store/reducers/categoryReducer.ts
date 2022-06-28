import * as T from "../../types/category";


const initialState : T.CategoryState = {
    categoryList: [],
    loading: false,
    error: null
}

export const categoryReducer = (state = initialState, action: T.CategoryAction) => {
    switch (action.type){
        case T.ActionTypes.FETCH_CATEGORIES:
            return {loading: true, error: null, categoryList: []}
        case T.ActionTypes.FETCH_CATEGORIES_SUCCESS:
            return {loading: false, error: null, categoryList: action.payload}
        case T.ActionTypes.FETCH_CATEGORIES_ERROR:
            return {loading: false, error: action.payload, categoryList: []}
        default: return state
    }
}