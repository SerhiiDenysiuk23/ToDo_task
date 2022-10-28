import React from 'react';
import CreateCategory from "../components/CreateCategory";
import CategoryList from "../components/CategoryList";

const Category = () => {
    return (
        <>
            <h1>Categories</h1>
            <CreateCategory/>
            <CategoryList/>
        </>
    );
};

export default Category;