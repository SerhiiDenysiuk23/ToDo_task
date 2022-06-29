import React, {useEffect, useState} from "react";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {useAction} from "../hooks/useAction";
import {Category} from "../types/category";
import getResource from "../api/core";
import {createCategory, deleteCategory} from "../api/queries";

const CategorySection = () => {
    const state = useTypedSelector(state => state.category)
    const {fetchCategories} = useAction()
    useEffect(() => {
        fetchCategories()
    }, [])

    const [stateCategory, setStateCategory] = useState<string>("")

    return(
    <>
        <header>
            <div className="create">
                <input onChange={event => setStateCategory(event.target.value)} type="text"
                       placeholder="Name"/>
                <button onClick={() => {
                    getResource(createCategory(stateCategory));
                    window.location.reload();
                }}>Create
                </button>
            </div>
        </header>
        <section className="list">
            <table>
                <tbody>
                {state.categoryList.map((item: Category) => <tr>
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

export default CategorySection