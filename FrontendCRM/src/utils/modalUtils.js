export function resetModalOptions(formId) {
    
    document.getElementById(formId).reset();

    const formGroups = document.querySelectorAll(`#${formId} .form-group`);
    formGroups.forEach(group => {
        group.classList.remove('form-group-incorrect');
        group.classList.add('form-group-correct');
    });

    
    const formErrors = document.querySelectorAll(`#${formId} .form-input-error`);
    formErrors.forEach(error => {
        error.classList.remove('form-input-error-active');
        error.classList.add('form-input-error-inactive');
    });
}