import React from 'react';
import {ToDo} from "../types/toDo";

interface PropType{
    toDo: ToDo
}

const ToDoItemBodyDefault = ({toDo}:PropType) => {
    return (
        <>
            <td>{toDo.text}</td>
            <td>{toDo.description}</td>
            <td>{toDo.categoryId === null ? "No Category" : toDo.categoryId}</td>
            <td>{toDo.deadline === null ? "No Deadline" : toDo.deadline}</td>
            <td>
                {toDo.isComplete ? "Complete" : "Not complete"}
            </td>
        </>
    )
}

export default ToDoItemBodyDefault