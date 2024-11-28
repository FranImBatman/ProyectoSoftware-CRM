import { GET_USERS } from "../constants/endpoints.js";

export const fetchUsers = async() =>{
    try{
        const response = await fetch(GET_USERS);
        if(!response.ok){
            throw new Error('Error al obtener los usuarios');
        }

        const users = await response.json();
        return users;
    } catch (error) {
        console.error('Error al obtener los usuarios', error);
        return [];
    }
}