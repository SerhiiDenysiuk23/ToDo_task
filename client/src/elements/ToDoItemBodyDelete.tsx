import React, {useState} from 'react';
import {ToDo} from "../types/toDo";
import getResource from "../api/core";
import {deleteToDo} from "../api/queries";

interface PropType{
    id?: string | number
}

const ToDoItemBodyDelete = ({id}: PropType) => {
    const [message, setMessage] = useState<string>("Are you sure you want to delete this item?")

    return (
        <td colSpan={6}>
            {message}
            <button onClick={async () => {
                const msg = id != undefined ?
                    await getResource(deleteToDo(id)) :
                    "Error"
                setMessage(msg)
                window.location.reload()
            }}>
                Delete
            </button>
            <button onClick={() => window.location.reload()}>Cancel</button>
        </td>
    )
}

export default ToDoItemBodyDelete