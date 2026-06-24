export function getUserId(){
    return localStorage.getItem("pathya-user-id");
}

export function setUserId(id: number){
    localStorage.setItem("pathya-user-id", id.toString());
}

export function clearUserId(){
    localStorage.removeItem("pathya-user-id");
}