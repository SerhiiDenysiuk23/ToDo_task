import React from 'react';
import {Routes, Route, Link} from "react-router-dom";
import ToDo from "./pages/ToDo";
import Category from "./pages/Category";
import "./styles/create.scss"
import "./styles/lists.scss"

function App() {
    return (
        <div className="App">
            <nav>
                <Link className="navLink" to="/">To Do</Link>
                <Link className="navLink" to="/category">Category</Link>
            </nav>
            <Routes>
                <Route path="/" element={<ToDo/>}/>
                <Route path="/category" element={<Category/>}/>
            </Routes>
        </div>
    )
}

export default App;
