import React from 'react';
import CreateToDo from "../components/CreateToDo";
import ToDoList from "../components/ToDoList";

const ToDo = () => {
    return (
        <>
            <h1>To Do</h1>
            <CreateToDo/>
            <ToDoList/>
        </>
    );
};

export default ToDo;