import * as React from "react";
import "../styles/create/index.scss"
import CategorySelect from "../elements/CategorySelect";

const CreateToDo = () => {
    return <form method="post" className="create">
        <input name="Text" type="text" placeholder="Text"/>
        <textarea placeholder="Description"/>
        <CategorySelect/>
        <input type="datetime-local" placeholder="Deadline"/>
        <input type="submit" value="Safe"/>
    </form>
}

export default CreateToDo