
export const classLoadIcons = {
    project: '.loader-icon-project',
    task: '.loader-icon-task',
    interaction: '.loader-icon-interaction'
}

export function showLoading(form){
    
    const loader = document.querySelector(form);
    const overlay = document.getElementById('overlay-load');
    overlay.style.display = 'block';
    loader.classList.add('show');
    
}

export function hideLoading(form){
    
    const loader = document.querySelector(form);
    const overlay = document.getElementById('overlay-load');
    overlay.style.display = 'none';
    loader.classList.remove('show');
}  

