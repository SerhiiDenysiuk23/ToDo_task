import React, {useState} from 'react';
import getResource from "../api/core";
import {createCategory} from "../api/queries";

const CreateCategory = () => {
    const [stateCategory, setStateCategory] = useState<string>("")
    return (
        <div className="create">
            <input onChange={event => setStateCategory(event.target.value)} type="text"
                   placeholder="Name"/>
            <button onClick={() => {
                if (stateCategory != "")
                    getResource(createCategory(stateCategory));
                window.location.reload();
            }}>Create
            </button>
        </div>
    );
};

export default CreateCategory;