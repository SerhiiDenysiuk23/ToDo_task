import React, {useEffect, useState} from 'react';
import {Category} from "../types/category";
import {ToDo} from "../types/toDo";
import {useTypedSelector} from "../hooks/useTypedSelector";
import {useAction} from "../hooks/useAction";
import getResource from "../api/core";
import {editToDo} from "../api/queries";

interface PropType {
    toDo: ToDo
}

const ToDoItemBodyEdit = ({toDo}: PropType) => {
    const [state, setState] = useState<ToDo>(toDo)

    const stateCategory = useTypedSelector(state => state.category)
    const {fetchCategories} = useAction()
    useEffect(() => {
        fetchCategories()
    }, [])

    return (
        <>
            <td>
                <input
                    type="text"
                    value={state.text}
                    onChange={e => setState({
                        ...state, text: e.target.value
                    })}/>
            </td>
            <td>
                <textarea
                    onChange={e => setState({
                        ...state, description: e.target.value
                    })}>
                    {state.description}
                </textarea></td>
            <td>
                <label>Category: </label>
                <select onChange={e => setState({
                    ...state, categoryId: e.target.value
                })}>
                    {stateCategory.categoryList.map((item: Category) =>
                        <option selected={toDo.categoryId == item.id}
                                value={item.id}>{item.name}</option>
                    )}
                </select>
            </td>
            <td>
                <label>Deadline: </label>
                <input
                    onChange={e => setState({
                        ...state, deadline: e.target.value
                    })}
                    type="datetime-local"
                    value={toDo.deadline}/>
            </td>
            <td>
                <button onClick={() => setState({
                    ...state, isComplete: !state.isComplete
                })}>
                    {state.isComplete ? "Complete" : "Not complete"}
                </button>
            </td>
            <td>
                <button onClick={() => window.location.reload()}>Cancel</button>
                <button
                    onClick={() => {
                        getResource(editToDo(state))
                        window.location.reload()
                    }}>
                    OK
                </button>
            </td>
        </>
    )
}


export default ToDoItemBodyEdit;