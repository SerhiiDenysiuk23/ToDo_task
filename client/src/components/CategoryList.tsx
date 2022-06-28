import React, {useEffect} from "react";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {useAction} from "../hooks/useAction";
import {Category} from "../types/category";

const CategoryList = () => {
    const state = useTypedSelector(state => state.category)
    const {fetchCategories} = useAction()
    useEffect(() => {
        fetchCategories()
    }, [])

    console.log(state)
    return <section className="list">
        <table>
            <tbody>
            {state.categoryList.map((item: Category) =>
                <tr>
                    <td>{item.name}</td>
                    <td>
                        <button className="deleteToDo" >×</button>
                    </td>
                </tr>
            )}
            </tbody>
        </table>
    </section>
}

export default CategoryList