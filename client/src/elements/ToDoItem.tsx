import React from "react";
import {ToDo} from "../types/toDo";

interface Prop{
    toDo: ToDo
}

const ToDoItem = (props: Prop) => {
    const idStr = props.toDo.id != undefined ? props.toDo.id.toString() : ""
    return (
        <tr>
            <td>{props.toDo.text}</td>
            <td>{props.toDo.description}</td>
            <td>{props.toDo.categoryId === null ? "No Category" : props.toDo.categoryId}</td>
            <td>{props.toDo.deadline === null ? "No Deadline" : props.toDo.deadline}</td>
            <td>
                {props.toDo.isComplete ? "Complete" : "Not complete"}
            </td>
            <td>
                {/*<a asp-controller="ToDo" asp-action="Edit" asp-route-id="@item.Id">Edit</a> |*/}
                <button className="editToDo" name={idStr}>✎</button>
                <button className="deleteToDo" name={idStr} >×</button>
                {/*<a asp-controller="ToDo" asp-action="Delete" asp-route-id="@item.Id">Delete</a>*/}
            </td>
        </tr>
    )
}

export default ToDoItem