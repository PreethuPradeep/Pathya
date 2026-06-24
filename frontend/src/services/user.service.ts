import { api } from "@/lib/api";
import { CreateUser } from "@/types/CreateUser";


export async function createUser(
    request: CreateUser
){
    const response = await api.post("/users", request);
    return response.data;
}