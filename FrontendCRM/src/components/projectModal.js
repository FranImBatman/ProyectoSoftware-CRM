import { resetModalOptions } from "../utils/modalUtils.js";
import { loadProjects } from "../controllers/projectControllers.js";

export function openModalAddProject(){
    var modal = document.querySelector('.add-project-window');
    var overlay = document.getElementById('overlay');
    
    modal.style.display = 'block';
    overlay.style.display = 'block';
    setTimeout(function(){
        modal.classList.add('show');
    }, 10);
}

export function closeModalAddProject(){
    var modal = document.querySelector('.add-project-window');
    var overlay = document.getElementById('overlay');

    modal.classList.remove('show');
    setTimeout(function(){
        modal.style.display = "none";
        overlay.style.display = "none";
    }, 500);

    resetProjectsDefaultView();
}


export function closeModalProject(){
    var modal = document.querySelector('.project-details-modal');
    var overlay = document.getElementById('overlay');

    modal.classList.remove('show');
    setTimeout(function(){
        modal.style.display = "none";
        overlay.style.display = "none";
    }, 500);

    
}

export function resetProjectsDefaultView(){
    document.getElementById('filter-campaign-type-select').selectedIndex = 0;
    document.getElementById('filter-client-select').selectedIndex = 0;
    document.getElementById('search-input').value = '';
    resetModalOptions('dataProject');
    loadProjects();
}

