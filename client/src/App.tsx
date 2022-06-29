import React from 'react';
import getResource from "./api/core";
import {getCategoryList, getToDoList} from "./api/queries";
// import CreateToDo from "./components/CreateToDo";
import ToDoList from "./components/ToDoList"
import CategorySection from "./components/CategorySection";
import CreateToDo from "./components/CreateToDo";


function App() {
    // getResource(getCategoryList())
    return (
        <div className="App">
            <header>
              <CreateToDo/>
            </header>
            <ToDoList/>
            <CategorySection/>
        </div>
    );
}

export default App;
