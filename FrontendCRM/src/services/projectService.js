import { GET_PROJECTS, POST_PROJECTS, GET_PROJECTS_BY_ID, POST_TASKS, POST_INTERACTIONS, PUT_TASK } from "../constants/endpoints.js";
import { HTTP_METHODS } from "../constants/consts.js";

export const fetchProjects = async() =>{
    try{
        const response = await fetch(GET_PROJECTS);
        if(!response.ok){
            throw new Error('Error al obtener los proyectos');
        }

        const projects = await response.json();
        
        return projects;
       
    } catch(error){
        return error;
    }
}

export const fetchProjectById = async(projectId) =>{
    try{
        console.log('id recibida', projectId);
        const url = GET_PROJECTS_BY_ID.replace('*', projectId);
        const response = await fetch(url);

        if(!response.ok){
            throw new Error('Error al obtener el proyecto');
        }
        return await response.json();
    } catch(error){
        return error;
    }
}

export const createProject = async(projectData) =>{
    try{
        const response = await fetch(POST_PROJECTS, {
            method: HTTP_METHODS.POST,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(projectData),
        });
        
        if(!response.ok){
            const errorData = await response.json();
            const errorMessage = errorData.message;
            throw new Error(errorMessage);
        }

        return await response.json();
    } catch(error){
        throw error;
    }
}

export const addTask = async(projectId, taskData) =>{
    try{
        const url = POST_TASKS.replace('{id}', projectId);
        const response = await fetch(url, {
            method: HTTP_METHODS.POST,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(taskData),
        });
        if(!response.ok){
            const errorData = await response.json();
            const errorMessage = errorData.message;
            throw new Error(errorMessage);
        }
        return await response.json();
    } catch (error){
        throw error;
    }
}

export const addInteraction = async(projectId, interactionData) =>{
    try{
        const url = POST_INTERACTIONS.replace('{id}', projectId);
        const response = await fetch(url, {
            method: HTTP_METHODS.POST,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(interactionData),
        });
        if(!response.ok){
            const errorData = await response.json();
            const errorMessage = errorData.message;
            throw new Error(errorMessage);
        }
        return await response.json();
    } catch (error){
        error;
    }
}

export const updateTask = async(taskId, taskData) =>{
    try{
        const url = PUT_TASK.replace('{id}', taskId);
        const response = await fetch(url, {
            method: HTTP_METHODS.PUT,
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(taskData),
        });
        if(!response.ok){
            const errorData = await response.json();
            const errorMessage = errorData.message;
            throw new Error(errorMessage);
        }
        return await response.json();
    } catch (error){
        error;
    }
}