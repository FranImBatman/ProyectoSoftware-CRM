import {resetModalOptions } from "../utils/modalUtils.js";

export function closeModalAddInteraction(){
    var modalInteraction = document.querySelector('.add-interaction-modal');
    var modalProject = document.querySelector('.project-details-modal');
    var overlay = document.getElementById('mid-overlay');
    modalInteraction.classList.remove('show');
    modalProject.classList.remove('dim');
   
    setTimeout(function(){
        modalInteraction.style.display = 'none';
        overlay.style.display = 'none';
    }, 500);

    resetModalOptions('dataInteraction');
}

export function openModalAddInteraction(){
    var modalInteraction = document.querySelector('.add-interaction-modal');
    var modalProject = document.querySelector('.project-details-modal');
    var overlay = document.getElementById('mid-overlay');
    modalProject.classList.add('dim');
    modalInteraction.style.display = 'block';
    overlay.style.display = 'block';
    setTimeout(function(){
        modalInteraction.classList.add('show');
    }, 500);

}