import React, {useState} from "react";
import {ToDo} from "../types/toDo";
import ToDoItemBodyDefault from "./ToDoItemBodyDefault";
import ToDoItemBodyEdit from "./ToDoItemBodyEdit";
import ToDoItemBodyDelete from "./ToDoItemBodyDelete";

interface Prop {
    toDo: ToDo
}

enum eventVariant {
    DEFAULT = "DEFAULT",
    EDIT = "EDIT",
    DELETE = "DELETE"
}

interface IToDoItemState {
    eventVar: string,
    toDo: ToDo
}

const ToDoItem = ({toDo}: Prop) => {
    const [state, setState] = useState<IToDoItemState>({eventVar: eventVariant.DEFAULT, toDo: toDo})

    switch (state.eventVar) {
        case eventVariant.DEFAULT:
        default:
            return (
                <tr>
                    <ToDoItemBodyDefault toDo={toDo}/>
                    <td>
                        <button
                            className="editToDo"
                            onClick={() => setState({...state, eventVar: eventVariant.EDIT})}
                        >✎
                        </button>
                        <button
                            className="deleteToDo"
                            onClick={() => setState({...state, eventVar: eventVariant.DELETE})}>×
                        </button>
                    </td>
                </tr>
            )
        case eventVariant.EDIT:
            return (
                <tr>
                    <ToDoItemBodyEdit toDo={toDo}/>
                </tr>
            )
        case eventVariant.DELETE:
            return (
                <tr>
                    <ToDoItemBodyDelete id={toDo.id}/>
                </tr>
            )
    }

}

export default ToDoItem