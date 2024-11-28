import { validateForm } from "./formsValidators.js"

    const submitTask = document.getElementById('dataTask');   

    const taskFormFields = [
        document.querySelector("[name=create-task-name]"),
        document.querySelector("[name=create-task-due-date]"),
        document.querySelector("[name=create-task-user]"),
        document.querySelector("[name=create-task-status]") 
    ]
    
    const taskFieldsValidationMap = {
        'task-name-group': 'taskName',
        'task-due-date-group': 'dueDate',
        'task-user-group': 'user',
        'task-status-group': 'status'
    }
    
    
    
    export const taskFieldsValidated = {
        taskName: false,
        dueDate: false,
        user: false,
        status: false
    }
    
    taskFormFields.forEach((field) =>{
        field.addEventListener('keyup', (e) => validateForm(e, taskFieldsValidated, taskFieldsValidationMap));
        field.addEventListener('blur', (e) => validateForm(e, taskFieldsValidated, taskFieldsValidationMap));
        field.addEventListener('change', (e) => validateForm(e, taskFieldsValidated, taskFieldsValidationMap));
        field.addEventListener('input', (e) => validateForm(e, taskFieldsValidated, taskFieldsValidationMap));
    })

    submitTask.addEventListener('submit', (e) => {
        taskFormFields.forEach((field) => {
            validateForm({target: field}, taskFieldsValidated, taskFieldsValidationMap)
        })
    });



