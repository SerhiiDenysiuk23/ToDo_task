import React, {useEffect} from "react";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {useAction} from "../hooks/useAction";
import {Category} from "../types/category";

const CategorySelect = () => {
    const state = useTypedSelector(state => state.category)
    const {fetchCategories} = useAction()
    useEffect(() => {
        fetchCategories()
    }, [])

    return (
        <div className="categoryBlock">
            <label>Category: </label>
            <select name="categoryList" placeholder="Category">
                <option value=""/>
                {state.categoryList.map((item: Category) =>
                    <option value={item.id}>{item.name}</option>
                )}
            </select>
        </div>
    )
}

export default CategorySelect