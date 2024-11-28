import { validateForm } from "./formsValidators.js"

    const submitInteraction = document.getElementById('dataInteraction');

    const interactionFormFields = [
        document.querySelector("[name=create-interaction-notes]"),
        document.querySelector("[name=create-interaction-date]"),
        document.querySelector("[name=create-interaction-type]")
    ]
    
    const interactionFieldsValidationMap = {
        'interaction-notes-group': 'interactionNotes',
        'interaction-date-group': 'date',
        'interaction-type-group': 'type'
    }
    
    
    
    export const interactionFieldsValidated = {
        interactionNotes: false,
        date: false,
        type: false,
    }
    
    interactionFormFields.forEach((field) =>{
        field.addEventListener('keyup', (e) => validateForm(e, interactionFieldsValidated, interactionFieldsValidationMap));
        field.addEventListener('blur', (e) => validateForm(e, interactionFieldsValidated, interactionFieldsValidationMap));
        field.addEventListener('change', (e) => validateForm(e, interactionFieldsValidated, interactionFieldsValidationMap));
        field.addEventListener('input', (e) => validateForm(e, interactionFieldsValidated, interactionFieldsValidationMap));
        field.addEventListener('submit', (e) => validateForm(e, interactionFieldsValidated, interactionFieldsValidationMap));
    })

    submitInteraction.addEventListener('submit', (e) => {
        interactionFormFields.forEach((field) => {
            validateForm({target: field}, interactionFieldsValidated, interactionFieldsValidationMap)
        })
    });
