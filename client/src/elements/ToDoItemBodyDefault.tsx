import React from 'react';
import {ToDo} from "../types/toDo";
import {Category} from "../types/category";

interface PropType {
    toDo: ToDo,
    category: Category | null
}

const ToDoItemBodyDefault = ({toDo, category}: PropType) => {

    return (
        <>
            <td>{toDo.text}</td>
            <td>{toDo.description}</td>
            <td>{category != null ? category.name : "No category"}</td>
            <td>{toDo.deadline === null ? "No Deadline" : toDo.deadline}</td>
            <td>
                {toDo.isComplete ? "Complete" : "Not complete"}
            </td>
        </>
    )
}

export default ToDoItemBodyDefault