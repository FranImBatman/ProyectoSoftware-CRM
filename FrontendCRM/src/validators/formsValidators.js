

export const validateForm = (e, fieldsValidated, fieldsValidationMap) => {
    console.log(e.target);
    const groupId = e.target.closest('.form-group').id;
    
    const input = e.target
    
    validateField(input, groupId, fieldsValidated, fieldsValidationMap);
    
    
}

const validateField = (input, group, fieldsValidated, fieldsValidationMap) => {
    
    const fieldKey = fieldsValidationMap[group];

    if(input.value.length > 0){
        fieldsValidated[fieldKey] = true;
        document.getElementById(`${group}`).classList.remove('form-group-incorrect');
        document.getElementById(`${group}`).classList.add('form-group-correct');
        document.querySelector(`#${group} .form-input-error`).classList.remove('form-input-error-active');
        document.querySelector(`#${group} .form-input-error`).classList.add('form-input-error-inactive');
    } else {
        fieldsValidated[fieldKey] = false;
        document.getElementById(`${group}`).classList.add('form-group-incorrect');
        document.getElementById(`${group}`).classList.remove('form-group-correct');
        document.querySelector(`#${group} .form-input-error`).classList.remove('form-input-error-inactive');
        document.querySelector(`#${group} .form-input-error`).classList.add('form-input-error-active');
    }
}






    





