import {ToDo} from "../types/toDo";

export const getToDoList = () => JSON.stringify({
    query: `query GetToDoList {
      todolist {
        id,
        text,
        description,
        deadline,
        isComplete,
        categoryId
      }
    }`
})

export const createToDo = (toDo: ToDo) => {
    return JSON.stringify({
        query: `mutation CreateToDo($toDo: toDoInput!) {
          createToDo(toDo: $toDo) {
            text
            description
            deadline
            isComplete
            categoryId
          }
        }`,
        variables: {toDo}
    })
}

export const deleteToDo = (id: number | string) => {
    return JSON.stringify({
        query: `mutation DeleteToDo($toDoId: ID!) {
              deleteToDo(toDoId: $toDoId)
            }`,
        variables: {"toDoId": id}
    });
}

export const editToDo = (toDo: ToDo) => {
    return JSON.stringify({
        query: `mutation EditToDo($toDo: toDoInput!) {
          updateToDo(toDo: $toDo) {
            id
            text
            description
            deadline
            isComplete
            categoryId
          }
        }`,
        variables: {toDo}
    })
}

export const getCategoryList = () => {
    return JSON.stringify({
        query: `query CategoryList {
          categories {
            id
            name
          }
        }`
    })
}

export const getCategoryItem = (categoryId: number | string) => {
    return JSON.stringify({
        query: `query CategoryItem($categoryId: ID!){
          category(categoryId: $categoryId){
            id
            name
          }
        }`,
        variables: {categoryId}
    })
}

export const createCategory = (name: string) => {
    return JSON.stringify({
        query: `mutation CreateCategory($category: categoryInput!) {
          createCategory(category: $category) {
            name
          }
        }`,
        variables: {"category": {name}}
    })
}

export const deleteCategory = (categoryId: string | number) => {
    return JSON.stringify({
        query: `mutation DeleteCategory($categoryId: ID!) {
          deleteCategory(categoryId: $categoryId)
        }`,
        variables: {categoryId}
    })
}