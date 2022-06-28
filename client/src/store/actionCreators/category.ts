import {Dispatch} from "redux";
import {ActionTypes, CategoryAction} from "../../types/category";
import getResource from "../../api/core";
import {getCategoryList} from "../../api/queries";


export const fetchCategories = () => {
    return async (dispatch: Dispatch<CategoryAction>) => {
        try {
            dispatch({type: ActionTypes.FETCH_CATEGORIES})
            const data = await getResource(getCategoryList())
            dispatch({type: ActionTypes.FETCH_CATEGORIES_SUCCESS, payload: data.data.categories})
        }catch (e){
            console.log(e)
            dispatch({type: ActionTypes.FETCH_CATEGORIES_ERROR, payload: "Error"})
        }
    }
}