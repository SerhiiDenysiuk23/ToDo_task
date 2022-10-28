import React, {useEffect} from "react";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {useAction} from "../hooks/useAction";
import {ToDo} from "../types/toDo";
import ToDoItem from "../elements/ToDoItem";

const ToDoList = () => {
    const state = useTypedSelector(state => { return {todo: state.toDo, category: state.category}})
    const {fetchToDos} = useAction()
    useEffect(() => {
        fetchToDos()
    }, [])

    const {fetchCategories} = useAction()
    useEffect(() => {
        fetchCategories()
    }, [])

    const getCateg = (id: number | string | undefined) =>{
        console.log(id)
        const categ = state.category.categoryList.find(elem => elem.id == id)
        console.log(state)
        return categ != undefined ? categ : null
    }

    return (
        <section className="list">
            <table>
                <tbody>
                <tr>
                    <th>Text</th>
                    <th>Description</th>
                    <th>Category</th>
                    <th>Deadline</th>
                    <th>Complete</th>
                    <th/>
                </tr>
                {state.todo.toDoList.map(
                    (item: ToDo) =>
                    <ToDoItem
                        key={item.id}
                        toDo={item}
                        category={getCateg(item.categoryId)}/>
                    )
                }
                </tbody>
            </table>
        </section>
    )
}

export default ToDoList