import { GET_TASK_STATUS } from "../constants/endpoints.js";

export const fetchTaskStatus = async() =>{
    try{
        const response = await fetch(GET_TASK_STATUS);
        if(!response.ok){
            throw new Error('Error al obtener los estados de tareas');
        }

        const taskStatus = await response.json();
        return taskStatus;
    } catch (error){
        console.error('Error al obtener los estados de tareas', error);
        return [];
    }
}