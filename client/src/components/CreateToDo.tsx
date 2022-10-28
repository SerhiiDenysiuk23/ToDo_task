import * as React from "react";
import {useEffect, useState} from "react";
import {ToDo} from "../types/toDo";
import getResource from "../api/core";
import {createToDo} from "../api/queries";
import {Category} from "../types/category";
import {useAction} from "../hooks/useAction";
import {useTypedSelector} from "../hooks/useTypedSelector";

const CreateToDo = () => {
    const [state, setState] = useState<ToDo>({text:"", isComplete: false})

    const stateCategory = useTypedSelector(state => state.category)
    const {fetchCategories} = useAction()
    useEffect(() => {
        fetchCategories()
    }, [])

    return (
        <div className="create">
            <input onChange={event => setState({...state, text:event.target.value})} type="text" placeholder="Text"/>
            <textarea onChange={event => setState({...state, description:event.target.value})} placeholder="Description"/>

            <label>Category: </label>
            <select onChange={e => setState({
                ...state, categoryId: e.target.value
            })}>
                <option value=""/>
                {stateCategory.categoryList.map((item: Category) =>
                    <option key={item.id} value={item.id}>{item.name}</option>
                )}
            </select>

            <label>Deadline: </label>
            <input onChange={event => setState({...state, deadline:event.target.value})} type="datetime-local" placeholder="Deadline"/>
            <input onClick={() => {
                getResource(createToDo(state))
                window.location.reload()
            }} type="submit" value="Create"/>
        </div>)
}

export default CreateToDo