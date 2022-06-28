import React, {useEffect} from "react";
import "../styles/toDoList/index.scss"
import {useTypedSelector} from "../hooks/useTypedSelector";
import {useAction} from "../hooks/useAction";
import {ToDo} from "../types/toDo";
import ToDoItem from "../elements/ToDoItem";

const ToDoList = () => {
    const state = useTypedSelector(state => state.toDo)
    const {fetchToDos} = useAction()
    useEffect(() => {
        fetchToDos()
    }, [])

    // console.log(state)

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
                    <th></th>
                </tr>
                {state.toDoList.map((item: ToDo) => <ToDoItem toDo={item}/>)}
                </tbody>
            </table>
        </section>
    )
}

export default ToDoList