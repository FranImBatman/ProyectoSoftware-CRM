import { GET_INTERACTION_TYPES } from "../constants/endpoints.js";

export const fetchInteractionTypes = async() =>{
    try{
        const response = await fetch (GET_INTERACTION_TYPES);
        if(!response.ok){
            throw new Error('Error al obtener los tipos de interaccion')
        }

        const interactionTypes = await response.json();
        return interactionTypes;
    } catch (error) {
        console.error('Error al obtener los tipos de interacion', error);
        return [];
    }
}