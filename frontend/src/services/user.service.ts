import { api } from "@/lib/api";
import { CreateUser } from "@/types/CreateUser";
import { User } from "@/types/User";


export async function createUser(
    request: CreateUser
){
    const response = await api.post("/users", request);
    return response.data;
}

export async function getUser(userId: number){
    const response = await api.get(`/users/${userId}`);
    return response.data;
}

export async function updateUser(userId: number, user: User){
    await api.put(`/users/${userId}`,user);
}