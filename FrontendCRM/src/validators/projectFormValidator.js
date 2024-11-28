import { validateForm } from "./formsValidators.js";

    const submitProject = document.getElementById('dataProject');

    const projectFormFields = [
        document.querySelector("[name=create-project-name]"),
        document.querySelector("[name=create-project-start-date]"),
        document.querySelector("[name=create-project-end-date]"),
        document.querySelector("[name=create-project-client-select]"),
        document.querySelector("[name=create-project-campaign-select]")
    ];
    
    const projectFieldsValidationMap = {
        'project-name-group': 'projectName',
        'project-start-date-group': 'startDate',
        'project-end-date-group': 'endDate',
        'project-client-group': 'client',
        'project-campaign-type-group': 'campaignType'
    };
    
    export const projectFieldsValidated = {
        projectName: false,
        startDate: false, 
        endDate: false,
        client: false,
        campaignType: false
    }

    projectFormFields.forEach((field) => {
        field.addEventListener('keyup', (e) => validateForm(e, projectFieldsValidated, projectFieldsValidationMap));
        field.addEventListener('blur', (e) => validateForm(e, projectFieldsValidated, projectFieldsValidationMap));
        field.addEventListener('input', (e) => validateForm(e, projectFieldsValidated, projectFieldsValidationMap));
        field.addEventListener('change', (e) => validateForm(e, projectFieldsValidated, projectFieldsValidationMap));
    });

    submitProject.addEventListener('submit', (e) => {
        projectFormFields.forEach((field) => {
            validateForm({target: field}, projectFieldsValidated, projectFieldsValidationMap)
        })
    });
         
