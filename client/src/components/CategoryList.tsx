import React, {useEffect} from "react";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {useAction} from "../hooks/useAction";
import {Category} from "../types/category";
import getResource from "../api/core";
import {deleteCategory} from "../api/queries";

const CategoryList = () => {
    const state = useTypedSelector(state => state.category)
    const {fetchCategories} = useAction()
    useEffect(() => {
        fetchCategories()
    }, [])

    return(
    <>
        <section className="list">
            <table>
                <tbody>
                {state.categoryList.map((item: Category) => <tr key={item.id}>
                        <td>{item.name}</td>
                        <td>
                            <button className="deleteToDo" onClick={() => {
                                if (item.id)
                                    getResource(deleteCategory(item.id));
                                window.location.reload();
                            }}
                            >×
                            </button>
                        </td>
                    </tr>
                )}
                </tbody>
            </table>
        </section>
    </>)
}

export default CategoryList